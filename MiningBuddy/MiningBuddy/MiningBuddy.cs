using MiningBuddy.Helpers;
using MiningBuddy.Models.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiningBuddy.Models.Interfaces;
using MiningBuddy.Constants;

namespace MiningBuddy
{
    public partial class MiningBuddy : Form
    {
        private Config Config { get; }
        private BitvavoHelper Bitvavo { get; set; }
        private IMiningPool PoolStatistics { get; set; }
        private PoolHelper PoolHelper { get; set; }

        public MiningBuddy()
        {
            Config = ConfigHelper.GetConfig();
            InitHelpers();
            InitializeComponent();
        }
        private void MiningBuddy_Load(object sender, EventArgs e)
        {
            InitUI();
            InitTimers();
        }

        private void InitHelpers()
        {
            //Init Bitvavo
            Bitvavo = new BitvavoHelper(Config.Bitvavo);

            //Init Pool
            PoolHelper = new PoolHelper();
            switch (Config.PoolName.ToLower())
            {
                case "ethermine":
                    PoolHelper.Init<Models.Ethermine.Ethermine>(Config.Address);
                    break;
                default:
                    throw new ArgumentException("This pool is unknown, please fix");
            }
        }

        #region UI stuff
        private void InitUI()
        {
            MiningBuddyVersionLabel.Text = MiningBuddyConstants.APPVERSION;
            EthAddressLabel.Text += Config.Address;

            RigSelectComboBox.Items.AddRange(Config.Rigs.Select(r => r.Name).ToArray());
            RigSelectComboBox.SelectedIndex = 0;
        }
        private void CloseButton_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void RefreshButton_Click(object sender, EventArgs e)
        {
            RefreshRigStatus();
        }
        private void RigSelectComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshRigStatus();
            RefreshPoolStatus();
        }

        /// <summary>
        /// Mouse drag moves form
        /// </summary>
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        private void MiningBuddy_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        #endregion

        #region Recurring stuff
        private void InitTimers()
        {
            var twoHourTimer = new Timer();
            twoHourTimer.Interval = 7200000;
            twoHourTimer.Tick += TwoHourJobs;
            twoHourTimer.Start();

            var fiveMinTimer = new Timer();
            fiveMinTimer.Interval = 300000;
            fiveMinTimer.Tick += EveryFiveMinuteJobs;
            fiveMinTimer.Start();

            var singleMinTimer = new Timer();
            singleMinTimer.Interval = 60000;
            singleMinTimer.Tick += EveryMinuteJobs;
            singleMinTimer.Start();

            //Trigger manually
            EveryFiveMinuteJobs(null, null);
            CalculateEarnings(); //Won't actually calculate, but will keep a reference in memory
        }

        private void TwoHourJobs(object sender, EventArgs e)
        {
            //Calculate our earnings over the past 2 hours
            CalculateEarnings();
        }
        private void EveryFiveMinuteJobs(object sender, EventArgs e)
        {
            //Check eth address in Bitvavo
            CheckBitvavoStatus();

            //Fetch data about current rig from the pool
            RefreshPoolStatus();
        }
        private void EveryMinuteJobs(object sender, EventArgs e)
        {
            //Fetch the rig status
            RefreshRigStatus();
        }

        private void CheckBitvavoStatus()
        {
            if (!Bitvavo.IsConfigured)
            {
                BitvavoStatusLabel.Text = BitvavoConstants.BITVAVODISCONNECTED;
                BitvavoStatusLabel.ForeColor = Color.OrangeRed;
                return;
            }
            var bitAddress = Bitvavo.GetValue<Models.Bitvavo.Deposit>(new Dictionary<string, string>() { { "symbol", "ETH" } }).Address;
            if (bitAddress != Config.Address)
            {
                BitvavoStatusLabel.Text = BitvavoConstants.BITVAVOADDRESSMISMATCH;
                BitvavoStatusLabel.ForeColor = Color.Red;

                MessageBox.Show($"Bitvavo reports an ethereum address mismatch\n\nConfig: {Config.Address}\nBitvavo: {bitAddress}", "MiningBuddy Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            BitvavoStatusLabel.Text = BitvavoConstants.BITVAVOCONNECTED;
            BitvavoStatusLabel.ForeColor = Color.Green;
        }
        private void CalculateEarnings()
        {
            //Todo: make this more dynamic, dont limit to ethermine
            var newStats = PoolHelper.GetPoolStatistics<Models.Ethermine.Ethermine>();

            PoolEarningsLabel.Text = $"Unknown";

            if (PoolStatistics != null && PoolStatistics.Unpaid.HasValue)
            {
                var earnings = (newStats.Unpaid.Value - PoolStatistics.Unpaid.Value) * 0.000000000000000001;
                var ethPrice = Bitvavo.GetValue<Models.Bitvavo.TickerPrice>(new Dictionary<string, string>() { { "market", "ETH-EUR" } }).Price;

                earnings = Math.Round(earnings * ethPrice.Value, 3);

                PoolEarningsLabel.Text = $"{earnings} EUR/2h ({DateTime.Now.ToString("HH:mm")})";
            }

            PoolStatistics = newStats;
        }
        private void RefreshPoolStatus()
        {
            IMiningPoolWorker worker;

            //Todo: make this more dynamic, dont limit to ethermine
            worker = PoolHelper.GetWorkerData<Models.Ethermine.Worker>(RigSelectComboBox.SelectedItem.ToString());


            MiningPoolNameLabel.Text = PoolHelper.Pool.PoolName;
            PoolAverageMiningSpeedLabel.Text = $"Average {worker.HashRateToString(worker.AverageHashrate)}";
            PoolCurrentMiningSpeedLabel.Text = $"Current {worker.HashRateToString(worker.CurrentHashrate)}";
            PoolReportedMiningSpeedLabel.Text = $"Reported {worker.HashRateToString(worker.ReportedHashrate)}";
            PoolAcceptedSharesLabel.Text = $"{worker.ValidShares} ({worker.StaleShares} Stales)";
            PoolIncorrectSharesLabel.Text = worker.InvalidShares.ToString();
        }
        private void RefreshRigStatus()
        {
            var selRigConf = Config.Rigs.FirstOrDefault(r => r.Name.Equals(RigSelectComboBox.SelectedItem.ToString()));
            RigNameLabel.Text = selRigConf.Name.ToUpper();
            IPLabel.Text = $"{selRigConf.IP}:{selRigConf.Port}";
            var cdm = new CDMHelper(selRigConf);
            var rig = cdm.GetRealtimeRigData(out bool alive);

            if (alive)
                RigStatusPanel.BackColor = Color.Green;
            else
            {
                RigStatusPanel.BackColor = Color.OrangeRed;
                MiningPoolLabel.Text = String.Empty;
                AcceptedSharesLabel.Text = String.Empty;
                RejectedSharesLabel.Text = String.Empty;
                IncorrectSharesLabel.Text = String.Empty;
                MaxFoundDifficultyLabel.Text = String.Empty;
                AverageMiningSpeedLabel.Text = String.Empty;
                EffectiveMiningSpeedLabel.Text = String.Empty;
                ReportedMiningSpeedLabel.Text = String.Empty;
                GraphicsCardLabel.Text = String.Empty;
                ViewDumpLabel.Text = String.Empty;
                GPUTemperatureLabel.Text = String.Empty;
                GPUFanSpeedLabel.Text = String.Empty;
                GPUPowerConsumptionLabel.Text = String.Empty;

                ViewDumpLabel.Enabled = false;

                RigNameLabel.Text += " (OFFLINE)";

                return;
            }

            MiningPoolLabel.Text = rig.Pool;
            AcceptedSharesLabel.Text = $"{rig.AcceptedShares} ({rig.AcceptedStales} Stales)";
            RejectedSharesLabel.Text = $"{rig.RejectedShares} ({rig.RejectedStales} Stales)";
            IncorrectSharesLabel.Text = rig.IncorrectShares.ToString();
            MaxFoundDifficultyLabel.Text = rig.MaxDifficultyOfFoundShare;
            AverageMiningSpeedLabel.Text = $"Average {rig.AverageSpeed}";
            EffectiveMiningSpeedLabel.Text = $"Effective {rig.EffectiveSpeed}";
            ReportedMiningSpeedLabel.Text = $"Reported {rig.PoolReportedSpeed}";
            GraphicsCardLabel.Text = rig.GPUs[0].Name;
            ViewDumpLabel.Text = "View dump";
            GPUTemperatureLabel.Text = $"{rig.GPUs[0].Temperature}°C";
            GPUFanSpeedLabel.Text = $"{rig.GPUs[0].FanSpeed}%";
            GPUPowerConsumptionLabel.Text = $"{rig.GPUs[0].PowerConsumption}W";

            ViewDumpLabel.Enabled = true;
        }

        #endregion

        private void ViewDumpLabel_Click(object sender, EventArgs e)
        {
            var viewer = new CDMDumpViewer(Config.Rigs.FirstOrDefault(r => r.Name.Equals(RigSelectComboBox.SelectedItem.ToString())));
            viewer.ShowDialog();
        }

        private void MiningBuddyVersionLabel_Click(object sender, EventArgs e)
        {
            MessageBox.Show(MiningBuddyConstants.ABOUT, MiningBuddyConstants.NOTIFICATION, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void GraphicsCardLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
