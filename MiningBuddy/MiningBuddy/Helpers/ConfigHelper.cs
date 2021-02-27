using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MiningBuddy.Models.Config;
using Newtonsoft.Json;

namespace MiningBuddy.Helpers
{
    class ConfigHelper
    {
        private const string CONFIG = "configuration.json";
        public static Config GetConfig()
        {
            var plain = File.ReadAllText(CONFIG);
            return JsonConvert.DeserializeObject<Config>(plain);
        }
    }
}
