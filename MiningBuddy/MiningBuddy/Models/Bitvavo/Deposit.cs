using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiningBuddy.Models.Bitvavo
{
    class Deposit : IBitvavo
    {
        [JsonIgnore]
        public string EndPoint => "deposit";
        [JsonIgnore]
        public string[] RequiredParams => new string[] { "symbol" };
        [JsonProperty("address")]
        public string Address { get; set; }
        [JsonProperty("paymentId")]
        public string PaymentID { get; set; }
    }
}
