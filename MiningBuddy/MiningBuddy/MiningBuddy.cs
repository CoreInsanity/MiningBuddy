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
using MiningBuddy.Models.CDM;

namespace MiningBuddy
{
    public partial class MiningBuddy : Form
    {
        private Rig SelectedRig { get; set; }
        private Config Config { get; }
        private BitvavoHelper Bitvavo { get; }
        public MiningBuddy()
        {
            Config = ConfigHelper.GetConfig();
            Bitvavo = new BitvavoHelper(Config.Bitvavo);

            InitializeComponent();
        }
        private void MiningBuddy_Load(object sender, EventArgs e)
        {
            InitUI();
            InitTimers();
        }

        #region UI stuff
        private void InitUI()
        {
            MiningBuddyVersionLabel.Text = $"MiningBuddy {Config.AppVersion}";
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
        }

        private void EveryFiveMinuteJobs(object sender, EventArgs e)
        {
            CheckBitvavoStatus();
        }
        private void EveryMinuteJobs(object sender, EventArgs e)
        {
            RefreshRigStatus();
        }

        private void CheckBitvavoStatus()
        {
            if (!Bitvavo.IsConfigured)
            {
                BitvavoStatusLabel.Text = Constants.BitvavoConstants.BITVAVODISCONNECTED;
                BitvavoStatusLabel.ForeColor = Color.OrangeRed;
                return;
            }
            var bitAddress = Bitvavo.GetValue<Models.Bitvavo.Deposit>(new Dictionary<string, string>() { { "symbol", "ETH" } }).Address;
            if (bitAddress != Config.Address)
            {
                BitvavoStatusLabel.Text = Constants.BitvavoConstants.BITVAVOADDRESSMISMATCH;
                BitvavoStatusLabel.ForeColor = Color.Red;

                MessageBox.Show($"Bitvavo reports an ethereum address mismatch\n\nConfig: {Config.Address}\nBitvavo: {bitAddress}", "MiningBuddy Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            BitvavoStatusLabel.Text = Constants.BitvavoConstants.BITVAVOCONNECTED;
            BitvavoStatusLabel.ForeColor = Color.Green;
        }
        private void RefreshRigStatus()
        {
            var selRigConf = Config.Rigs.FirstOrDefault(r => r.Name.Equals(RigSelectComboBox.SelectedItem.ToString()));
            RigNameLabel.Text = selRigConf.Name.ToUpper();
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
            GraphicsCardLabel.Text = $"{rig.GPUs[0].Name} ({rig.GPUs[0].Temperature}°C)";
        }
        #endregion

        
    }
}
