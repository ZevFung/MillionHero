using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace MillionHerosHelper
{
    class ProcessHelper
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

    }
}
