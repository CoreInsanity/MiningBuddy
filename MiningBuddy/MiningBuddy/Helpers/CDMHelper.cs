using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MiningBuddy.Models.CDM;
using MiningBuddy.Models.Config;

namespace MiningBuddy.Helpers
{
    class CDMHelper
    {
        private RigConfig Config { get; }
        private WebClient CdmClient { get; }
        public CDMHelper(RigConfig config)
        {
            Config = config;
            CdmClient = new WebClient();
            CdmClient.BaseAddress = $"http://{Config.IP}:{Config.Port}";
        }
        public Rig GetRealtimeRigData(out bool alive)
        {
            alive = false;
            string data;
            try
            {
                data = GetRawData();
            }
            catch
            {
                return null;
            }

            alive = true;
            return ParseRigInfoFromPhoenix(data);
        }
        public string GetPlainDump()
        {
            return CdmClient.DownloadString("");
        }
        private string GetRawData()
        {
            var response = CdmClient.DownloadString("");
            if (string.IsNullOrEmpty(response)) return null;
            response = Regex.Replace(response, "<[^>]*>", "");
            var split = response.Split('*');
            response = split[split.Count() - 1];
            return response.Replace("\r", "");
        }

        //Wot is regex?
        private Rig ParseRigInfoFromPhoenix(string rawOutput)
        {
            var rig = new Rig()
            {
                RigName = Config.Name,
                GPUs = new List<GPU>()
            };

            foreach (var line in rawOutput?.Split('\n'))
            {
                //This is about the rig
                if (line.StartsWith("Eth:"))
                {
                    if (line.Contains("Mining ETH on"))
                        rig.Pool = line.Split(new string[] { " on " }, StringSplitOptions.None)[1].Split(new string[] { " for " }, StringSplitOptions.None)[0];
                    else if (line.Contains("Accepted shares"))
                    {
                        rig.AcceptedShares = Convert.ToInt32(line.Split(new string[] { "Accepted shares " }, StringSplitOptions.None)[1].Split(new string[] { " (" }, StringSplitOptions.None)[0]);
                        rig.AcceptedStales = Convert.ToInt32(line.Split(new string[] { " (" }, StringSplitOptions.None)[1].Split(new string[] { " stales" }, StringSplitOptions.None)[0]);
                        rig.RejectedShares = Convert.ToInt32(line.Split(new string[] { "rejected shares " }, StringSplitOptions.None)[1].Split(new string[] { " (" }, StringSplitOptions.None)[0]);
                        rig.RejectedStales = Convert.ToInt32(line.Split(new string[] { " (" }, StringSplitOptions.None)[2].Split(new string[] { " stales" }, StringSplitOptions.None)[0]);
                    }
                    else if (line.Contains("Incorrect shares"))
                        rig.IncorrectShares = Convert.ToInt32(line.Split(new string[] { "Incorrect shares " }, StringSplitOptions.None)[1].Split(new string[] { " (" }, StringSplitOptions.None)[0]);
                    else if (line.Contains("Maximum difficulty"))
                        rig.MaxDifficultyOfFoundShare = line.Split(new string[] { "share: " }, StringSplitOptions.None)[1];
                    else if (line.Contains("Average speed"))
                        rig.AverageSpeed = line.Split(new string[] { "): " }, StringSplitOptions.None)[1];
                    else if (line.Contains("Effective speed"))
                    {
                        rig.EffectiveSpeed = line.Split(new string[] { "Effective speed: " }, StringSplitOptions.None)[1].Split(';')[0];
                        rig.PoolReportedSpeed = line.Split(new string[] { "at pool: " }, StringSplitOptions.None)[1];
                    }
                }
                //This is about a GPU
                else if (line.StartsWith("GPU"))
                {
                    if (line.StartsWith("GPUs power")) continue;

                    var gpuNo = line.Split(':')[0];
                    var gpu = rig.GPUs.FirstOrDefault(g => g.ID.Equals(gpuNo));
                    if (gpu == null) gpu = new GPU();

                    gpu.ID = gpuNo;

                    if (line.Contains("VRAM"))
                    {
                        gpu.Name = line.Split(new string[] { $"{gpuNo}: " }, StringSplitOptions.None)[1].Split(new string[] { " (" }, StringSplitOptions.None)[0];
                        gpu.PcieSlot = Convert.ToInt32(line.Split(new string[] { "(pcie " }, StringSplitOptions.None)[1].Split(')')[0]);
                    }
                    else if (line.Contains("%"))
                    {
                        gpu.Temperature = Convert.ToInt32(line.Split(new string[] { $"{gpuNo}: " }, StringSplitOptions.None)[1].Split('C')[0]);
                        gpu.FanSpeed = Convert.ToInt32(line.Split(new string[] { "C " }, StringSplitOptions.None)[1].Split('%')[0]);
                        gpu.PowerConsumption = Convert.ToInt32(line.Split(new string[] { "% " }, StringSplitOptions.None)[1].Split('W')[0]);
                    }

                    rig.GPUs.RemoveAll(g => g.ID.Equals(gpuNo));
                    rig.GPUs.Add(gpu);
                }
            }
            return rig;
        }
    }
}
