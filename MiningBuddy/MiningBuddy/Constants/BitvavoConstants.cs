using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiningBuddy.Constants
{
    class BitvavoConstants
    {
        //UI
        public const string BITVAVODISCONNECTED = "Bitvavo DISCONNECTED";
        public const string BITVAVOCONNECTED = "Bitvavo CONNECTED";
        public const string BITVAVOADDRESSMISMATCH = "Bitvavo MISMATCH";

        //API
        public const string APIURL = @"https://api.bitvavo.com/v2/";
        public const string APIKEYHEADER = "Bitvavo-Access-Key";
        public const string SIGHEADER = "Bitvavo-Access-Signature";
        public const string TIMESTAMPHEADER = "Bitvavo-Access-Timestamp";
    }
}
