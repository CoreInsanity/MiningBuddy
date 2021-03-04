using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiningBuddy.Models.Config
{
    public class Email
    {
        public string Address { get; set; }
        public int Port { get; set; }
        public string SMTP { get; set; }
    }
}
