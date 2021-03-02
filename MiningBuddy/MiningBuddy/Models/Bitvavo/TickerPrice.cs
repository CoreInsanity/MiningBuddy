using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiningBuddy.Models.Bitvavo
{
    class TickerPrice : IBitvavo
    {
        [JsonIgnore]
        public string EndPoint => "ticker/price";
        [JsonIgnore]
        public string[] RequiredParams => new string[] { "market" };

        public string Market { get; set; }
        public double? Price { get; set; }
    }
}
