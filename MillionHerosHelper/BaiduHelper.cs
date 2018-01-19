using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Diagnostics;
using System.IO;
using System.Web;

namespace MillionHerosHelper
{
    public static class BaiduHelper
    {
        public static int StatisticsKeyword(string keyword)
        {

            Debug.WriteLine("1");
            const string strStart = "百度为您找到相关结果约";
            const string strEnd = "个";
            int[] next = Algorithm.InitKMPNext(strStart);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            string data = GetSearchString("http://www.baidu.com/s?wd=" + System.Web.HttpUtility.UrlEncode(keyword));
            //Debug.WriteLine(data);

            int p = data.IndexOf(strStart);

            if (p == -1)
                return 0;
            int p2 = data.IndexOf(strEnd, p);
            if (p2 == -1)
                return 0;

            string countStr = data.Substring(p + strStart.Length, p2 - p - strStart.Length);
            countStr = countStr.Replace(",", "");

            int count;
            Int32.TryParse(countStr, out count);

            sw.Stop();
            Debug.WriteLine("耗时:" + sw.ElapsedMilliseconds);
            sw = null;

            return count;
        }

        public static int StatisticsKeyword(string keyword, out string sourceData)
        {
            const string strStart = "百度为您找到相关结果约";
            const string strEnd = "个";
            string data = GetSearchString("http://www.baidu.com/s?wd=" + System.Web.HttpUtility.UrlEncode(keyword));
            sourceData = data;
            int p = data.IndexOf(strStart);
            if (p == -1)
                return 1000000;
            int p2 = data.IndexOf(strEnd, p);
            if (p2 == -1)
                return 1000000;

            string countStr = data.Substring(p + strStart.Length, p2 - p - strStart.Length);
            countStr = countStr.Replace(",", "");

            int count;
            Int32.TryParse(countStr, out count);

            return count;
        }


        private static string GetSearchString(string url)
        {
            try
            {
                WebClient wc = new WebClient();
                wc.Proxy = null;
                wc.Credentials = CredentialCache.DefaultCredentials;
                wc.Encoding = Encoding.UTF8;
                return wc.DownloadString(url);
            }
            catch
            {
                return "";
            }
        }
    }
}
