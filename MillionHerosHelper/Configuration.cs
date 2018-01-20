using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MillionHerosHelper
{
    static class Config
    {
        public static string OCR_API_KEY { get; set; }
        public static string OCR_SECRET_KEY { get; set; }

        public static int CutX { get; set; }
        public static int CutY { get; set; }
        public static int CutWidth { get; set; }
        public static int CutHeight { get; set; }


        public static void LoadConfig()
        {
            OCR_API_KEY = INIOperation.ReadValue("config.ini", "BaiDuOCR", "API_KEY", "0kEPZddCBO5cUD0Lf1yTN91O");
            OCR_SECRET_KEY = INIOperation.ReadValue("config.ini", "BaiDuOCR", "SECRET_KEY", "fEkXWR4CINttqCQVAQejX5cXgQKrVbnW");

            string _CutX = INIOperation.ReadValue("config.ini", "CutScreenShot", "StartX", "80");
            string _CutY = INIOperation.ReadValue("config.ini", "CutScreenShot", "StartY", "270");
            string _CutWidth = INIOperation.ReadValue("config.ini", "CutScreenShot", "Width", "900");
            string _CutHeight = INIOperation.ReadValue("config.ini", "CutScreenShot", "Heigh", "980");

            Int32.TryParse(_CutX, out int temp);
            CutX = temp;
            Int32.TryParse(_CutY, out temp);
            CutY = temp;
            Int32.TryParse(_CutWidth, out temp);
            CutWidth = temp;
            Int32.TryParse(_CutHeight, out temp);
            CutHeight = temp;
        }

        public static void SaveConfig()
        {
            INIOperation.WriteValue("config.ini", "BaiDuOCR", "API_KEY", OCR_API_KEY);
            INIOperation.WriteValue("config.ini", "BaiDuOCR", "SECRET_KEY", OCR_SECRET_KEY);

            INIOperation.WriteValue("config.ini", "CutScreenShot", "StartX", CutX.ToString());
            INIOperation.WriteValue("config.ini", "CutScreenShot", "StartY", CutY.ToString());
            INIOperation.WriteValue("config.ini", "CutScreenShot", "Width", CutWidth.ToString());
            INIOperation.WriteValue("config.ini", "CutScreenShot", "Heigh", CutHeight.ToString());
        }
    }
}
