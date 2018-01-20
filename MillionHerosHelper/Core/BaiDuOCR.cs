using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;
using Baidu.Aip.Ocr;

namespace MillionHerosHelper
{
    static class BaiDuOCR
    {
        private static Ocr OCR;

        public static void InitBaiDuOCR(string api_key, string secret_key)
        {
            OCR = new Ocr(api_key, secret_key);
        }

        public static string Recognize(byte[] image)
        {
            try
            {
                if (OCR == null)
                {
                    InitBaiDuOCR(Config.OCR_API_KEY, Config.OCR_SECRET_KEY);
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
            catch(ArgumentNullException)
            {
                throw new APIException("OCR文本识别错误,可能是网络连接异常或API调用次数达到上限");
            }
        }

    }
}
