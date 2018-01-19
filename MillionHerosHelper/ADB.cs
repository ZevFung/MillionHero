using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MillionHerosHelper
{
    public static class ADB
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

        /// <summary>
        /// 获取屏幕截图,请确保手机已经连接
        /// </summary>
        /// <returns>返回图片路径(临时)</returns>
        public static byte[] GetScreenshort()
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
            System.Diagnostics.Debug.WriteLine(folder + fileName);
            byte[] image = File.ReadAllBytes(folder + fileName);
            File.Delete(folder + fileName);
            return image;
        }

        public static string RunADBCommand(string command)
        {
            return ProcessHelper.RunProcessAndGetOutPut("cmd.exe", @"/c " + command, AppDomain.CurrentDomain.BaseDirectory + @"ADB");
        }
    }
}
