using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiningBuddy.Models.Interfaces;
using MiningBuddy.Models.Config;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using System.IO;

namespace MiningBuddy
{
    public partial class Settings : Form
    {
        private Config OriginalConfig { get; }
        public Settings(Config config)
        {
            OriginalConfig = config;

            if (OriginalConfig == null)
                MessageBox.Show("Please fill in these settings before starting MiningBuddy", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);

            InitializeComponent();

            PoolComboBox.DataSource = GetSupportedPools();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            if (!VerifyAndSaveChanges())
            {
                MessageBox.Show("Not all required fields are filled in.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.Close();
        }



        private List<string> GetSupportedPools()
        {
            var type = typeof(IMiningPool);
            return AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p))
                .Select(p => p.Name)
                .Where(p => !p.Equals("IMiningPool"))
                .ToList();
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
        private void HeadingBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            if (OriginalConfig == null) return;

            EmailTextbox.Text = OriginalConfig.Email?.Address;
            SmtpTextbox.Text = OriginalConfig.Email?.SMTP;
            SmtpPortTextbox.Text = OriginalConfig.Email?.Port.ToString();

            BitvavoApiTextbox.Text = OriginalConfig.Bitvavo?.ApiKey;

            AddressTextbox.Text = OriginalConfig.Address;
            PoolComboBox.SelectedItem = OriginalConfig.PoolName;

            if (OriginalConfig.TopMost.HasValue) TopMostCheckbox.Checked = OriginalConfig.TopMost.Value;
        }
        private bool VerifyAndSaveChanges()
        {
            var config = new Config()
            {
                Address = AddressTextbox.Text,
                PoolName = PoolComboBox.SelectedValue.ToString(),
                Bitvavo = new BitvavoConfig(),
                Email = new Email()
            };

            config.Address = AddressTextbox.Text;
            config.PoolName = PoolComboBox.SelectedValue.ToString();

            config.Email.Address = EmailTextbox.Text;
            config.Email.SMTP = SmtpTextbox.Text;
            if(!string.IsNullOrEmpty(SmtpPortTextbox.Text)) config.Email.Port = Convert.ToInt32(SmtpPortTextbox.Text);

            config.Bitvavo.ApiKey = BitvavoApiTextbox.Text;
            if (!string.IsNullOrEmpty(BitvavoSecretTextbox.Text)) config.Bitvavo.SecretKey = Helpers.CryptographyHelper.Base64Encode(BitvavoSecretTextbox.Text);
            else config.Bitvavo.SecretKey = OriginalConfig?.Bitvavo?.SecretKey;

            config.TopMost = TopMostCheckbox.Checked;

            //Remove when rigmanager is available
            config.Rigs = OriginalConfig.Rigs;

            //Check required properties
            if (string.IsNullOrEmpty(config.Address) || string.IsNullOrEmpty(config.PoolName)) return false;

            //Serialize and write to file
            var plainJson = JsonConvert.SerializeObject(config);
            File.WriteAllText(Constants.MiningBuddyConstants.CONFIGURATION, plainJson, Encoding.UTF8);

            return true;
        }

        private void SmtpPortTextbox_TextChanged(object sender, EventArgs e)
        {
            SmtpPortTextbox.Text = Regex.Replace(SmtpPortTextbox.Text, "[^0-9.]", "");
        }
    }
}
