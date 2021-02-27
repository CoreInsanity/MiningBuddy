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

namespace MiningBuddy
{
    public partial class MiningBuddy : Form
    {
        

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
            EthAddressLabel.Text += Config.Address;
        }
        private void CloseButton_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        #endregion

        #region Recurring stuff
        private void InitTimers()
        {
            var fiveMinTimer = new Timer();
            fiveMinTimer.Interval = 300000;
            fiveMinTimer.Tick += EveryFiveMinuteJobs;
            fiveMinTimer.Start();

            //Trigger manually
            EveryFiveMinuteJobs(null, null);
        }

        private void EveryFiveMinuteJobs(object sender, EventArgs e)
        {
            CheckBitvavoStatus();
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
        #endregion
    }
}
