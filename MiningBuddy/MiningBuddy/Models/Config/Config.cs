﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiningBuddy.Models;
using Newtonsoft.Json;

namespace MiningBuddy.Models.Config
{
    public class Config
    {
        public string Address { get; set; }
        public string PoolName { get; set; }
        public BitvavoConfig Bitvavo { get; set; }
        public RigConfig[] Rigs { get; set; }
        public Email Email { get; set; }
        public bool? TopMost { get; set; }
    }
}
