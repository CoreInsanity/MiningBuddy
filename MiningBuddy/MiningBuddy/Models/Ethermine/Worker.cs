using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiningBuddy.Models.Interfaces;
using Newtonsoft.Json;

namespace MiningBuddy.Models.Ethermine
{
    class Worker : IMiningPoolWorker
    {
        [JsonIgnore]
        public string StatisticsEndpoint => $"/worker/{WorkerName}/currentStats";
        [JsonIgnore]
        public string WorkerName { get; set; }
        public double? ReportedHashrate { get; set; }
        public double? CurrentHashrate { get; set; }
        public double? AverageHashrate { get; set; }
        public int? ValidShares { get; set; }
        public int? InvalidShares { get; set; }
        public int? StaleShares { get; set; }

        public string HashRateToString(double? hashRate)
        {
            if (!hashRate.HasValue)
                return "0 MH/s";

            return $"{Math.Round(hashRate.Value / 1000000.0, 2)} MH/s";
        }
    }
}
