using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiningBuddy.Models.CDM
{
    class Rig
    {
        public string RigName { get; set; } //Fetch from config
        public string Pool { get; set; }
        public int AcceptedShares { get; set; }
        public int AcceptedStales { get; set; }
        public int RejectedShares { get; set; }
        public int RejectedStales { get; set; }
        public int IncorrectShares { get; set; }
        public string MaxDifficultyOfFoundShare { get; set; }
        public string AverageSpeed { get; set; }
        public string EffectiveSpeed { get; set; }
        public string PoolReportedSpeed { get; set; }
        public List<GPU> GPUs { get; set; }
    }
}
