using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace MillionHerosHelper
{
    static class AnalyzeProblem
    {
        /// <summary>
        /// 搜索答案
        /// </summary>
        /// <param name="problem">问题题干</param>
        /// <param name="answerArr">待判断选项</param>
        /// <returns>选项索引,从0开始</returns>
        public static int SearchAnswer(string problem, params string[] answerArr)
        {
            problem = RemoveUselessInfo(problem);
            Debug.WriteLine(problem);
            int problemCnt = BaiduHelper.StatisticsKeyword(problem);
            int[] answerCnt = new int[answerArr.Length];
            for (int i = 0; i < answerArr.Length; i++) 
            {
                answerCnt[i] = BaiduHelper.StatisticsKeyword(answerArr[i]);
            }

            double[] pmiArr = new double[answerArr.Length];
            for (int i = 0; i < answerArr.Length; i++) 
            {
                int problemAndAnswerCnt = BaiduHelper.StatisticsKeyword(problem + " " + answerArr[i]);
                pmiArr[i] = CalculateRank.GetPMI(problemCnt, answerCnt[i], problemAndAnswerCnt);
                Debug.Write(pmiArr[i] + " ");
            }

            Debug.WriteLine("");

            int index = 0;
            for (int i = 0; i < answerArr.Length; i++) 
            {
                if(pmiArr[i]>pmiArr[index])
                {
                    index = i;
                }
            }
            return index;
        }

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
            for (int i=0; i<answerArr.Length; i++)
            {
                sumRank[i] = pmiRank[i] + cntRank[i];
                if (sumRank[i] > sumRank[maxIndex]) 
                {
                    maxIndex = i;
                }
            }

            AnalyzeResult ar;
            ar.CntRank = cntRank;
            ar.PMIRank = pmiRank;
            ar.Index = maxIndex;
            ar.SumRank = sumRank;
            return ar;
        }

        public static string RemoveUselessInfo(string str)
        {
            string[] dic = new string[] {"“","”","\"","以下","下列","哪个","哪项","选项"};
            string res = str;
            foreach(string key in dic)
            {
                res = res.Replace(key, "");
            }
            res = res.Replace("？", "?");
            return res;
        }
    }
}
