using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace MillionHerosHelper
{
    public static class CalculateRank
    {
        /// <summary>
        /// 计算PMI
        /// </summary>
        /// <param name="strA">字符串A在库中出现的次数</param>
        /// <param name="strB">字符串B在库中出现的次数</param>
        /// <param name="strAB">字符串AB同时在库中出现的次数</param>
        public static double GetPMI(int strA, int strB, int strAB)
        {
            return (double)strAB / strA / strB / Math.Log(2);
        }
        
        private static double GetPMI_New(int strA, int strB, int strAB)//更加准确
        {
            return (double)strAB * strAB / strA / strB;
        }


        private static int[] answerCnt;//答案在库中出现次数
        private static int[] problemAndAnswerCnt;//问题+答案在库中出现的次数

        /// <summary>
        /// 根据PMI计算一个相关度权值
        /// </summary>
        /// <param name="problem">问题</param>
        /// <param name="answer">答案</param>
        /// <param name="problemData">问题在库中的出现次数</param>
        /// <returns></returns>
        public static double[] CalculatePMIRank(string problem, string[] answer, int problemCnt = -1)
        {
            if (problemCnt == -1)
            {
                problemCnt = BaiduHelper.StatisticsKeyword(problem);
            }

            Thread[] workThreads = new Thread[answer.Length * 2];

            answerCnt = new int[answer.Length];
            for (int i = 0; i < answer.Length; i++) 
            {
                //answerCnt[i] = BaiduHelper.StatisticsKeyword(answer[i]);
                workThreads[i] = new Thread(new ParameterizedThreadStart(StatisticsWorkThread));
                workThreads[i].Start(new object[] { ArrType.AnswerCnt, i, answer[i] });
            }

            problemAndAnswerCnt = new int[answer.Length];

            for (int i=0; i<answer.Length; i++)
            {
                //problemAndAnswerCnt[i] = BaiduHelper.StatisticsKeyword(problem + " " + "\"" + answer[i] + "\"");
                workThreads[i + answer.Length] = new Thread(new ParameterizedThreadStart(StatisticsWorkThread));
                workThreads[i + answer.Length].Start(new object[] { ArrType.ProblemAndAnswerCnt, i, problem + " " + "\"" + answer[i] + "\"" });
            }

            while(true)
            {
                bool allExited = true;
                for (int i = 0; i < workThreads.Length; i++) 
                {
                    if(workThreads[i].IsAlive)
                    {
                        allExited = false;
                        break;
                    }
                }

                if(allExited)
                {
                    break;
                }
                else
                {
                    Thread.Sleep(100);
                }
            }

            double[] pmiRank = new double[answer.Length];
            for(int i=0; i<pmiRank.Length; i++)
            {
                pmiRank[i] = GetPMI_New(problemCnt, answerCnt[i], problemAndAnswerCnt[i]);
            }

            return pmiRank;
        }

        private static void StatisticsWorkThread(object args)
        {
            int type = (int)((object[])args)[0];
            int index = (int)((object[])args)[1];
            string keyword = (string)((object[])args)[2];

            int[] arr = (type == (int)ArrType.AnswerCnt) ? answerCnt : problemAndAnswerCnt;

            arr[index] = BaiduHelper.StatisticsKeyword(keyword);
            Thread.CurrentThread.Abort();
        }

        /// <summary>
        /// 计算PMI权值
        /// </summary>
        /// <param name="problemCnt">问题在文本库中出现的次数</param>
        /// <param name="answerCnt">答案在文本库中出现的次数</param>
        /// <param name="problemAndAnswerCnt">问题+答案在文本库中出现的次数</param>
        /// <returns></returns>
        public static double[] CalculatePMIRank(int problemCnt, int[] answerCnt, int[] problemAndAnswerCnt)
        {

            double[] pmiRank = new double[answerCnt.Length];
            for (int i = 0; i < pmiRank.Length; i++)
            {
                pmiRank[i] = GetPMI_New(problemCnt, answerCnt[i], problemAndAnswerCnt[i]);
            }

            return pmiRank;
        }

        /// <summary>
        /// 根据出现次数计算一个权值
        /// </summary>
        /// <param name="problem">问题</param>
        /// <param name="answer">答案</param>
        /// <param name="pmiRank">pmi权值的数组,用于参考</param>
        /// <param name="problemData">问题的数据,用于重复利用节省时间</param>
        /// <returns>权值数组</returns>
        public static double[] CalculateCountRank(string problem, string[] answer, double[] pmiRank, string problemData = "")
        {
            if (problemData == "")
            {
                BaiduHelper.StatisticsKeyword(problem, out problemData);
            }

            double pmiSum = 0;
            foreach (double val in pmiRank)
            {
                pmiSum += val;
            }

            int[] answerCnt = new int[answer.Length];//每个答案出现次数
            int sum = 0;//总次数
            for (int i = 0; i < answer.Length; i++)
            {
                if (Regex.IsMatch(answer[i], "^[0-9]*$")) //若为数字则不启用此权重
                {
                    for (int i2 = 0; i2 < answer.Length; i2++)
                    {
                        answerCnt[i2] = 1;
                    }
                    sum = answer.Length;
                    break;
                }

                int p = problemData.IndexOf(answer[i]);
                int cnt = 0;
                while (p != -1)
                {
                    sum++;
                    cnt++;
                    p = problemData.IndexOf(answer[i], p + answer[i].Length);
                }
                if (cnt == 0)
                {
                    cnt++;
                    sum++;
                }
                answerCnt[i] = cnt;
            }

            double[] countRank = new double[answer.Length];
            for (int i = 0; i < answer.Length; i++)
            {
                countRank[i] = pmiSum * ((double)answerCnt[i] / sum);
                System.Diagnostics.Debug.Write("debug:" + answer[i] + ":" + answerCnt[i].ToString() + "  ");
            }
            System.Diagnostics.Debug.WriteLine("");
            return countRank;
        }
    }
}
