using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MiningBuddy.Helpers
{
    class CryptographyHelper
    {
        public static string CalcHmacSha256(string input, string key)
        {
            using (var sha256Hash = new HMACSHA256(Encoding.UTF8.GetBytes(key)))
            {
                var bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
                var builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                    builder.Append(bytes[i].ToString("x2"));

                return builder.ToString();
            }
        }
    }
}
