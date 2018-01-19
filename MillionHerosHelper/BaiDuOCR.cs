using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;
using Baidu.Aip.Ocr;

namespace MillionHerosHelper
{
    public static class BaiDuOCR
    {
        private const string API_KEY = "xxx";
        private const string SECRET_KEY = "xxx";
        private static Ocr OCR;

        public static void InitBaiDuOCR(string api_key, string secret_key)
        {
            OCR = new Ocr(api_key, secret_key);
        }
        public static string get(byte[] image)
        {
            if (OCR == null)
            {
                InitBaiDuOCR(API_KEY, SECRET_KEY);
            }

            JObject res = OCR.GeneralBasic(image);

            JToken[] arr = res["words_result"].ToArray();
            StringBuilder sb = new StringBuilder();
            foreach (JToken item in arr)
            {
                sb.AppendLine(item["words"].ToString());
            }
            return sb.ToString();
        }

    }
}
