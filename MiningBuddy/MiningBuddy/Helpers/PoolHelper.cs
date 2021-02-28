using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MiningBuddy.Models.Interfaces;
using MiningBuddy.Models;
using Newtonsoft.Json;

namespace MiningBuddy.Helpers
{
    class PoolHelper
    {
        private WebClient PoolClient { get; set; }
        private IMiningPool Pool { get; set; }
        public bool IsInitialized { get; private set; }

        public void Init<T>(string address) where T : IMiningPool, new()
        {
            PoolClient = new WebClient();

            Pool = new T();
            Pool.Address = address;
            PoolClient.BaseAddress = Pool.ApiUrl;

            IsInitialized = true;
        }
        public IMiningPoolWorker GetWorkerData<T>(string workerName) where T : IMiningPoolWorker, new()
        {
            if (!IsInitialized) throw new Exception("Pool is not initialized");

            var worker = new T();
            worker.WorkerName = workerName;

            var plainData = PoolClient.DownloadString(Pool.MinerEndpoint + worker.StatisticsEndpoint);

            var workerModel = JsonConvert.DeserializeObject<Models.Ethermine.SearchResult>(plainData).Data;

            return workerModel;
        }
    }
}
