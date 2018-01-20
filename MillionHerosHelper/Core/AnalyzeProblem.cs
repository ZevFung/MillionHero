using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Threading;

namespace MillionHerosHelper
{
    static class AnalyzeProblem
    {
        private static string problemData;
        private static int problemCnt;
        private static int[] answerCnt;
        private static int[] problemAndAnswerCnt;

        public static AnalyzeResult Analyze(string problem, string[] answerArr)
        {
            bool oppose = Regex.IsMatch(problem, "不是|不属于");//是否存在否定关键词

            //移除部分干扰搜索的关键字
            problem = RemoveUselessInfo(problem);

            #region 多线程获取信息
            Thread[] workThread = new Thread[1 + answerArr.Length * 2];//工作线程

            workThread[0] = new Thread(new ParameterizedThreadStart(WorkThread));
            WorkArgs args;

            args.Type = TaskType.GetProblemData;
            args.Index = -1;
            args.Text = problem;
            workThread[0].Start(args);

            answerCnt = new int[answerArr.Length];
            for (int i = 0; i < answerArr.Length; i++) 
            {
                args.Type = TaskType.AnswerCnt;
                args.Index = i;
                args.Text = answerArr[i];
                workThread[i + 1] = new Thread(new ParameterizedThreadStart(WorkThread));
                workThread[i + 1].Start(args);
            }

            problemAndAnswerCnt = new int[answerArr.Length];
            for (int i = 0; i < answerArr.Length; i++) 
            {
                args.Type = TaskType.ProblemAndAnswerCnt;
                args.Index = i;
                args.Text = problem + " " + "\"" + answerArr[i] + "\"";
                workThread[i + 1 + answerArr.Length] = new Thread(new ParameterizedThreadStart(WorkThread));
                workThread[i + 1 + answerArr.Length].Start(args);
            }

            while(true)//等待所有线程执行完毕
            {
                bool allExited = true;
                for (int i = 0; i < workThread.Length; i++) 
                {
                    if(workThread[i].IsAlive)
                    {
                        allExited = false;
                        break;
                    }
                }

                if (allExited)
                    break;
                else
                    Thread.Sleep(50);
            }
            #endregion

            //计算权值
            double[] pmiRank = CalculateRank.CalculatePMIRank(problemCnt, answerCnt, problemAndAnswerCnt);
            double[] cntRank = CalculateRank.CalculateCountRank(problem, answerArr, pmiRank, problemData);
            double[] sumRank = new double[answerArr.Length];

            int maxIndex = 0;
            int minIndex = 0;
            for (int i = 0; i < answerArr.Length; i++)
            {
                sumRank[i] = pmiRank[i] + cntRank[i];
                if (sumRank[i] > sumRank[maxIndex])
                {
                    maxIndex = i;
                }

                if (sumRank[i] < sumRank[minIndex])
                {
                    minIndex = i;
                }
            }

            AnalyzeResult ar;
            ar.CntRank = cntRank;
            ar.PMIRank = pmiRank;
            ar.Index = maxIndex;
            if (oppose) 
            {
                ar.Index = minIndex;
            }
            ar.SumRank = sumRank;
            return ar;
        }

        private static void WorkThread(object arg)
        {
            WorkArgs args = (WorkArgs)arg;
            if(args.Type == TaskType.GetProblemData)
            {
                problemCnt = SearchEngine.StatisticsKeyword(args.Text, out problemData);
            }
            else
            {
                int[] arr = (args.Type == TaskType.AnswerCnt) ? answerCnt : problemAndAnswerCnt;
                arr[args.Index] = SearchEngine.StatisticsKeyword(args.Text);
            }
        }

        /// <summary>
        /// 移除无用信息
        /// </summary>
        public static string RemoveUselessInfo(string str)
        {
            string[] dic = new string[] { "“", "”", "\"", "以下", "下列", "哪个", "哪项", "选项", "不是", "不属于" };
            string res = str;
            foreach(string key in dic)
            {
                res = res.Replace(key, "");
            }
            res = res.Replace("？", "?");
            Debug.WriteLine(res);
            return res;
        }
    }
}
