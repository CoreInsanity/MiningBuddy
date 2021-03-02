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
        public IMiningPool Pool { get; private set; }
        public bool IsInitialized { get; private set; }

        public void Init<T>(string address) where T : IMiningPool, new()
        {
            PoolClient = new WebClient();

            Pool = new T();
            Pool.Address = address;
            PoolClient.BaseAddress = Pool.ApiUrl;

            IsInitialized = true;
        }
        public IMiningPool GetPoolStatistics<T>() where T : IMiningPool
        {
            if (!IsInitialized) throw new Exception("Pool is not initialized");

            var plainData = PoolClient.DownloadString(Pool.MinerEndpoint + Pool.StatisticsEndpoint);

            var poolStatModel = JsonConvert.DeserializeObject<dynamic>(plainData);

            //Todo: detect whether the model has a data property or not
            //if (((object)poolStatModel).GetType().GetProperty("data") != null)
                return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(poolStatModel.data));
            //else
                //return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(poolStatModel));
        }
        public IMiningPoolWorker GetWorkerData<T>(string workerName) where T : IMiningPoolWorker, new()
        {
            if (!IsInitialized) throw new Exception("Pool is not initialized");

            var worker = new T();
            worker.WorkerName = workerName;

            var plainData = PoolClient.DownloadString(Pool.MinerEndpoint + worker.StatisticsEndpoint);

            var workerModel = JsonConvert.DeserializeObject<dynamic>(plainData);

            //Todo: detect whether the model has a data property or not
            //if (((object)workerModel).GetType().GetProperty("data") != null)
            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(workerModel.data));
            //else
                //return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(workerModel));
        }
    }
}
