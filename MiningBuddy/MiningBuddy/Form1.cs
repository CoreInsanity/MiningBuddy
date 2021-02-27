using MiningBuddy.Helpers;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var bitvavo = new BitvavoHelper("api", "secret");
            var deposit = bitvavo.GetValue<Models.Bitvavo.Deposit>(new Dictionary<string, string>() { { "symbol", "ETH" } });
        }
    }
}
