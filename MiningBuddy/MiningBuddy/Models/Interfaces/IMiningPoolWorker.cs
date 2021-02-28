using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiningBuddy.Models.Interfaces
{
    interface IMiningPoolWorker
    {
        string StatisticsEndpoint { get; }
        string WorkerName { get; set; }
        double? ReportedHashrate { get; set; }
        double? CurrentHashrate { get; set; }
        double? AverageHashrate { get; set; }
        int? ValidShares { get; set; }
        int? InvalidShares { get; set; }
        int? StaleShares { get; set; }

        string HashRateToString(double? hashRate);
    }
}
