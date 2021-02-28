using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiningBuddy.Models.CDM
{
    class GPU
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public int PcieSlot { get; set; }
        public int Temperature { get; set; }
        public int FanSpeed { get; set; }
        public int PowerConsumption { get; set; }
    }
}
