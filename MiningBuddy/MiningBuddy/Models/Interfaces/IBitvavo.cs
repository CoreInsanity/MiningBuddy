using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiningBuddy.Models
{
    interface IBitvavo
    {
        string EndPoint { get; }
        string[] RequiredParams { get; }
    }
}
