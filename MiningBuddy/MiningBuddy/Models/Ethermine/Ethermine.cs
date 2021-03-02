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
        public string StatisticsEndpoint => "/currentStats";
        public string PoolName => "Ethermine";
        public string Address { get; set; }

        public double? Time { get; set; }
        public double? LastSeen { get; set; }
        public double? ReportedHashrate { get; set; }
        public double? CurrentHashrate { get; set; }
        public double? ValidShares { get; set; }
        public double? InvalidShares { get; set; }
        public double? StaleShares { get; set; }
        public double? AverageHashrate { get; set; }
        public int? ActiveWorkers { get; set; }
        public long? Unpaid { get; set; }
        public double? Unconfirmed { get; set; }
        public double? CoinsPerMin { get; set; }
        public double? UsdPerMin { get; set; }
        public double? BtcPerMin { get; set; }
    }
}
