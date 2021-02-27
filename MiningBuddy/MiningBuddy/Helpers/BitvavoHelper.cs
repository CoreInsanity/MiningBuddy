using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MiningBuddy.Models.Bitvavo;
using MiningBuddy.Models;
using Newtonsoft.Json;
using System.IO;

namespace MiningBuddy.Helpers
{
    class BitvavoHelper
    {
        private WebClient Client { get; }
        private string SecretKey { get; }

        private const string APIURL = @"https://api.bitvavo.com/v2/";
        private const string APIKEYHEADER = "Bitvavo-Access-Key";
        private const string SIGHEADER = "Bitvavo-Access-Signature";
        private const string TIMESTAMPHEADER = "Bitvavo-Access-Timestamp";
        public BitvavoHelper(string apiKey, string secretKey)
        {
            Client = new WebClient();
            Client.BaseAddress = APIURL;
            Client.Headers.Add(APIKEYHEADER, apiKey);
            Client.Headers.Add(SIGHEADER, "NOVAL");
            Client.Headers.Add(TIMESTAMPHEADER, "NOVAL");

            SecretKey = secretKey;
        }
        private void UpdateHeaders(string method, string url, string body = "")
        {
            var timestamp = Math.Round((DateTime.Now.ToUniversalTime() - new DateTime(1970, 1, 1)).TotalMilliseconds);
            var sig = CryptographyHelper.CalcHmacSha256($"{timestamp}{method.Trim()}/v2/{url.Trim()}{body}", SecretKey);

            Client.Headers.Set(TIMESTAMPHEADER, timestamp.ToString());
            Client.Headers.Set(SIGHEADER, sig);
        }
        private string ParamsToString(Dictionary<string, string> queryParams)
        {
            string paramString = "?";
            foreach (var param in queryParams)
                paramString += $"{param.Key}={param.Value}&";

            if (paramString == "?")
                return "";
            else
                return paramString.Remove(paramString.Length - 1, 1);
        }
        public object GetValue<T>(Dictionary<string, string> queryParams) where T : IBitvavo, new()
        {
            var endpoint = new T().EndPoint + ParamsToString(queryParams);

            UpdateHeaders("GET", endpoint);
            var plainJson = Client.DownloadString(endpoint);

            return JsonConvert.DeserializeObject<T>(plainJson);
        }
    }
}
