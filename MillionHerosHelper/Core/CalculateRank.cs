using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace MillionHerosHelper
{
    static class CalculateRank
    {
        public static double GetPMI(int strA, int strB, int strAB)
        {
            return (double)strAB / strA / strB / Math.Log(2);
        }
        
        private static double GetPMI_New(int strA, int strB, int strAB)//更加准确
        {
            return (double)strAB * strAB / strA / strB;
        }

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
        /// <param name="pmiRank">pmi权值的数组,用于参考</param>
        /// <param name="problemData">问题的数据,用于重复利用节省时间</param>
        /// <returns>权重数组</returns>
        public static double[] CalculateCountRank(string problem, string[] answer, double[] pmiRank, string problemData = "")
        {
            if (problemData == "")
            {
                SearchEngine.StatisticsKeyword(problem, out problemData);
            }

            double pmiSum = 0;//pmi权值和
            foreach (double val in pmiRank)
            {
                pmiSum += val;
            }

            int[] answerCnt = new int[answer.Length];//每个答案出现次数
            int sum = 0;//总次数
            for (int i = 0; i < answer.Length; i++)
            {
                if (Regex.IsMatch(answer[i], "^[0-9]*$")) //若为数字则不启用此权重算法
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
