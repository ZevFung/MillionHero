using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace MillionHerosHelper
{
    static class ProcessHelper
    {
        public static string RunProcessAndGetOutPut(string fileName, string args, string workingDirectory = "")
        {
            try
            {
                Process run = new Process();
                run.StartInfo.FileName = fileName;
                run.StartInfo.Arguments = args;
                if (String.IsNullOrEmpty(workingDirectory))//设置工作目录
                {
                    run.StartInfo.UseShellExecute = true;
                }
                else
                {
                    run.StartInfo.UseShellExecute = false;
                    run.StartInfo.WorkingDirectory = workingDirectory;
                }

                run.StartInfo.RedirectStandardInput = true;
                run.StartInfo.RedirectStandardOutput = true;
                run.StartInfo.RedirectStandardError = true;
                run.StartInfo.CreateNoWindow = true;

                run.Start();
                string res = run.StandardOutput.ReadToEnd();
                run.WaitForExit();
                run.Close();
                return res;
            }
            catch
            {
                return "error";
            }
        }
        /// <summary>
        /// 运行程序并取得标准输出流的bytes
        /// </summary>
        public static byte[] RunProcessAndGetOutPutBytes(string fileName, string args, string workingDirectory = "")
        {
            try
            {
                Process run = new Process();
                run.StartInfo.FileName = fileName;
                run.StartInfo.Arguments = args;
                if (String.IsNullOrEmpty(workingDirectory))//设置工作目录
                {
                    run.StartInfo.UseShellExecute = true;
                }
                else
                {
                    run.StartInfo.UseShellExecute = false;
                    run.StartInfo.WorkingDirectory = workingDirectory;
                }

                run.StartInfo.RedirectStandardInput = true;
                run.StartInfo.RedirectStandardOutput = true;
                run.StartInfo.RedirectStandardError = true;
                run.StartInfo.CreateNoWindow = true;

                run.Start();

                Stream stream = run.StandardOutput.BaseStream;
                MemoryStream memoryStream = new MemoryStream();
                stream.CopyTo(memoryStream);
                memoryStream.Seek(0, SeekOrigin.Begin);
                byte[] res = new byte[memoryStream.Length];
                memoryStream.Read(res, 0, (int)memoryStream.Length);
                memoryStream.Close();

                run.WaitForExit();
                run.Close();
                return res;
            }
            catch
            {
                return new byte[0];
            }
        }

    }
}
