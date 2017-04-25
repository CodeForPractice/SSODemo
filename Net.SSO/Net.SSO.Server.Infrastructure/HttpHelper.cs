using System;
using System.IO;
using System.Net;
using System.Text;

namespace Net.SSO.Server.Infrastructure
{
    public class HttpHelper
    {
        public static string Get(string url)
        {
            string result = string.Empty;
            Uri uri = new Uri(url);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = "Get";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();
            return retString;
        }
    }
}