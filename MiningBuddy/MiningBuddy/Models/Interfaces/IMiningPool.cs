using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiningBuddy.Models.Interfaces
{
    interface IMiningPool
    {
        string ApiUrl { get; }
        string MinerEndpoint { get; }
        string StatisticsEndpoint { get; }
        string PoolName { get; }
        string Address { get; set; }

        double? Time { get; set; }
        double? LastSeen { get; set; }
        double? ReportedHashrate { get; set; }
        double? CurrentHashrate { get; set; }
        double? ValidShares { get; set; }
        double? InvalidShares { get; set; }
        double? StaleShares { get; set; }
        double? AverageHashrate { get; set; }
        int? ActiveWorkers { get; set; }
        long? Unpaid { get; set; }
        double? Unconfirmed { get; set; }
        double? CoinsPerMin { get; set; }
        double? UsdPerMin { get; set; }
        double? BtcPerMin { get; set; }
    }
}
