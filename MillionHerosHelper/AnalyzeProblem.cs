using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Threading;
using System.Text.RegularExpressions;

namespace MillionHerosHelper
{
    static class AnalyzeProblem
    {
        /// <summary>
        /// 分析答案
        /// </summary>
        /// <param name="problem">问题</param>
        /// <param name="answerArr">选项</param>
        /// <returns></returns>
        public static AnalyzeResult Analyze(string problem, string[] answerArr)
        {
            problem = RemoveUselessInfo(problem);

            string problemData = "";
            int problemCnt = BaiduHelper.StatisticsKeyword(problem, out problemData);

            double[] pmiRank = CalculateRank.CalculatePMIRank(problem, answerArr, problemCnt);
            double[] cntRank = CalculateRank.CalculateCountRank(problem, answerArr, pmiRank, problemData);
            double[] sumRank = new double[answerArr.Length];

            int maxIndex = 0;
            int minIndex = 0;
            for (int i=0; i<answerArr.Length; i++)
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
            ar.SumRank = sumRank;
            return ar;
        }

        private static string problemData;//问题数据
        private static int problemCnt;//问题在文本库中出现的次数
        private static int[] answerCnt;//答案在文本库中出现的次数
        private static int[] problemAndAnswerCnt;//问题+答案在文本库中出现的次数
        /// <summary>
        /// 分析答案
        /// </summary>
        /// <param name="problem">问题</param>
        /// <param name="answerArr">选项</param>
        /// <returns></returns>
        public static AnalyzeResult AnalyzeNew(string problem, string[] answerArr)
        {
            bool oppose = Regex.IsMatch(problem, "不是|不属于");//是否存在相反的关键词
            //移除部分干扰搜索的关键字
            problem = RemoveUselessInfo(problem);

            Thread[] workThread = new Thread[1 + answerArr.Length * 2];//工作线程

            workThread[0] = new Thread(new ParameterizedThreadStart(WorkThread));
            WorkArgs args;

            args.Type = TaskType.GetProblemData;
            args.Index = -1;
            args.Text = problem;
            workThread[0].Start(args);//多线程获取问题信息

            answerCnt = new int[answerArr.Length];
            for (int i = 0; i < answerArr.Length; i++) 
            {
                args.Type = TaskType.AnswerCnt;
                args.Index = i;
                args.Text = answerArr[i];
                workThread[i + 1] = new Thread(new ParameterizedThreadStart(WorkThread));
                workThread[i + 1].Start(args);//多线程获取答案在文本库中的出现次数
            }

            problemAndAnswerCnt = new int[answerArr.Length];
            for (int i = 0; i < answerArr.Length; i++) 
            {
                args.Type = TaskType.ProblemAndAnswerCnt;
                args.Index = i;
                args.Text = problem + " " + "\"" + answerArr[i] + "\"";
                workThread[i + 1 + answerArr.Length] = new Thread(new ParameterizedThreadStart(WorkThread));
                workThread[i + 1 + answerArr.Length].Start(args);//多线程获取答案在文本库中的出现次数
            }

            while(true)
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
                problemCnt = BaiduHelper.StatisticsKeyword(args.Text, out problemData);
            }
            else
            {
                int[] arr = (args.Type == TaskType.AnswerCnt) ? answerCnt : problemAndAnswerCnt;
                arr[args.Index] = BaiduHelper.StatisticsKeyword(args.Text);
            }
        }
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
