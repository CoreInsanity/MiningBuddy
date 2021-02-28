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
        string PoolName { get; }
        string Address { get; set; }
    }
}
