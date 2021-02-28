using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiningBuddy.Models;
using MiningBuddy.Helpers;

namespace MiningBuddy
{
    public partial class CDMDumpViewer : Form
    {
        private CDMHelper CDM { get; }
        public CDMDumpViewer(Models.Config.RigConfig rigConf)
        {
            InitializeComponent();
            CDM = new CDMHelper(rigConf);
        }

        private void CDMDumpViewer_Load(object sender, EventArgs e)
        {
            var refreshTimer = new Timer();
            refreshTimer.Interval = 30000;
            refreshTimer.Tick += Refresh;
            refreshTimer.Start();

            Refresh(null, null);
        }
        private void Refresh(object sender, EventArgs e)
        {
            HtmlBrowser.DocumentText = CDM.GetPlainDump();
            
        }
        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HtmlBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            HtmlBrowser.Document.Window.ScrollTo(0, HtmlBrowser.Document.Window.Size.Height+100000);
        }
    }
}
