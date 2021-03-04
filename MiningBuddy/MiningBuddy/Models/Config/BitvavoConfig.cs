using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiningBuddy.Models.Config
{
    public class BitvavoConfig
    {
        private string secretKey;

        public string ApiKey { get; set; }
        [JsonProperty("encodedSecretKey")]
        public string SecretKey
        {
            get => Helpers.CryptographyHelper.Base64Decode(secretKey);
            set
            {
                secretKey = value;
            }
        }
    }
}
