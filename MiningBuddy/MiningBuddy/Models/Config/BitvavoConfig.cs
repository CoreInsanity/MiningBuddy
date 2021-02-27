using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiningBuddy.Models.Config
{
    class BitvavoConfig
    {
        private string secretKey;

        public string ApiKey { get; set; }
        [JsonProperty("encodedSecretKey")]
        public string SecretKey
        {
            get 
            {
                var bts = Convert.FromBase64String(secretKey);
                return Encoding.UTF8.GetString(bts);
            }
            set
            {
                secretKey = value;
            }
        }
    }
}
