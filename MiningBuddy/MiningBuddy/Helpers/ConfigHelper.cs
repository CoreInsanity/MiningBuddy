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
        public static Config GetConfig()
        {
            if (!File.Exists(Constants.MiningBuddyConstants.CONFIGURATION)) return null;

            try
            {
                var plain = File.ReadAllText(Constants.MiningBuddyConstants.CONFIGURATION);
                return JsonConvert.DeserializeObject<Config>(plain);
            }
            catch
            {
                return null;
            }
        }
    }
}
