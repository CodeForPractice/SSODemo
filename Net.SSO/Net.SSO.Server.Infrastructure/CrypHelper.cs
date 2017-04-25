using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Net.SSO.Server.Infrastructure
{
    public static class CrypHelper
    {
        public static string ToMD5Hash(byte[] bytes)
        {
            StringBuilder hash = new StringBuilder();
            MD5 md5 = MD5.Create();

            md5.ComputeHash(bytes)
                  .ToList()
                  .ForEach(b => hash.AppendFormat("{0:x2}", b));

            return hash.ToString();
        }

        public static string ToMD5Hash(string inputString)
        {
            return ToMD5Hash(Encoding.UTF8.GetBytes(inputString));
        }

        public static string GetNonce()
        {
            byte[] bytes = new byte[16];
            using (var rngProvider = new RNGCryptoServiceProvider())
            {
                rngProvider.GetBytes(bytes);
            }
            return ToMD5Hash(bytes);
        }
    }
}
