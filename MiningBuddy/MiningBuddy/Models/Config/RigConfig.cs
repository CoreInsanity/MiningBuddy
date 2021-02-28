using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiningBuddy.Models.Config
{
    class RigConfig
    {
        public string IP { get; set; }
        public int Port { get; set; }
        public string Name { get; set; }
        public string[] GraphicsCards { get; set; }
    }
}
