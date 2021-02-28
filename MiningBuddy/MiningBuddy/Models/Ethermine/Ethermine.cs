using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiningBuddy.Models.Interfaces;

namespace MiningBuddy.Models.Ethermine
{
    class Ethermine : IMiningPool
    {
        public string ApiUrl => "https://api.ethermine.org";
        public string MinerEndpoint => $"/miner/{Address}";
        public string PoolName => "Ethermine";
        public string Address { get; set; }
    }
}
