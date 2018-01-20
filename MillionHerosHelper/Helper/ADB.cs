using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MillionHerosHelper
{
    static class ADB
    {
        public static bool CheckConnect()
        {
            string res = RunADBCommand("adb devices");
            try
            {
                if (res.IndexOf("device", 25) == -1)
                    return false;
                else
                    return true;
            }
            catch
            {
                return false;
            }

        }

        public static byte[] GetScreenshot()
        {
            if (!Directory.Exists("screenshort"))
            {
                Directory.CreateDirectory("screenshort");
            }

            string folder = AppDomain.CurrentDomain.BaseDirectory + "screenshort\\";
            string fileName = DateTime.Now.ToFileTime().ToString() + ".png";

            
            RunADBCommand("adb shell screencap -p /sdcard/" + fileName);
            RunADBCommand("adb pull /sdcard/" + fileName + " " + folder + fileName);
            RunADBCommand("adb shell rm /sdcard/" + fileName);

            byte[] image = File.ReadAllBytes(folder + fileName);
            File.Delete(folder + fileName);
            return image;
        }

        public static string GetScreenshotPath()
        {
            if (!Directory.Exists("screenshort"))
            {
                Directory.CreateDirectory("screenshort");
            }

            string folder = AppDomain.CurrentDomain.BaseDirectory + "screenshort\\";
            string fileName = DateTime.Now.ToFileTime().ToString() + ".png";

            RunADBCommand("adb shell screencap -p /sdcard/" + fileName);
            RunADBCommand("adb pull /sdcard/" + fileName + " " + folder + fileName);
            RunADBCommand("adb shell rm /sdcard/" + fileName);

            return folder + fileName;
        }

        public static string RunADBCommand(string command)
        {
            return ProcessHelper.RunProcessAndGetOutPut("cmd.exe", @"/c " + command, AppDomain.CurrentDomain.BaseDirectory + @"ADB");
        }
    }
}
