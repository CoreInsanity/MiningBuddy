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
using MiningBuddy.Models.Config;
using MiningBuddy.Constants;
using System.IO;

namespace MiningBuddy.Helpers
{
    class BitvavoHelper
    {
        private WebClient Client { get; }
        private BitvavoConfig Config { get; }
        public bool IsConfigured { get; private set; }
        public BitvavoHelper(BitvavoConfig config = null)
        {
            if (config == null)
                config = ConfigHelper.GetConfig().Bitvavo;

            Client = new WebClient();
            Config = config;

            ConfigureClient();
        }
        private void ConfigureClient()
        {
            if (IsConfigured) return;
            if (String.IsNullOrEmpty(Config?.ApiKey) || String.IsNullOrEmpty(Config?.SecretKey)) return;

            Client.BaseAddress = BitvavoConstants.APIURL;
            Client.Headers.Add(BitvavoConstants.APIKEYHEADER, Config.ApiKey);
            Client.Headers.Add(BitvavoConstants.SIGHEADER, "NOVAL");
            Client.Headers.Add(BitvavoConstants.TIMESTAMPHEADER, "NOVAL");

            IsConfigured = true;
        }
        private void UpdateHeaders(string method, string url, string body = "")
        {
            var timestamp = Math.Round((DateTime.Now.ToUniversalTime() - new DateTime(1970, 1, 1)).TotalMilliseconds);
            var sig = CryptographyHelper.CalcHmacSha256($"{timestamp}{method.Trim()}/v2/{url.Trim()}{body}", Config.SecretKey);

            Client.Headers.Set(BitvavoConstants.TIMESTAMPHEADER, timestamp.ToString());
            Client.Headers.Set(BitvavoConstants.SIGHEADER, sig);
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
        public T GetValue<T>(Dictionary<string, string> queryParams) where T : IBitvavo, new()
        {
            if (!IsConfigured) throw new Exception("What are u doing mate?");

            var endpoint = new T().EndPoint + ParamsToString(queryParams);

            UpdateHeaders("GET", endpoint);

            var plainJson = string.Empty;

            //This try-catch is for debugging purposes, will be removed later on
            try
            {
                plainJson = Client.DownloadString(endpoint);
            }
            catch (WebException ex)
            {
                var stream = ex.Response.GetResponseStream();
                using (var sr = new StreamReader(stream))
                {
                    var result = sr.ReadToEnd();
                }
            }

            return JsonConvert.DeserializeObject<T>(plainJson);
        }
    }
}