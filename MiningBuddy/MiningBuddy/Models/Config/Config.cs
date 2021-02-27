using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiningBuddy.Models;
using Newtonsoft.Json;

namespace MiningBuddy.Models.Config
{
    class Config
    {
        public string Address { get; set; }
        public BitvavoConfig Bitvavo { get; set; }
    }
}
