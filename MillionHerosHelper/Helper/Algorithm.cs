using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MillionHerosHelper
{
    static class Algorithm
    {
        /// <summary>
        /// 初始化KMP算法的Next数组
        /// </summary>
        public static int[] InitKMPNext(string objStr)
        {
            int[] next = new int[objStr.Length + 1];
            next[0] = -1;
            int i = 0;
            int j = -1;
            while (i < objStr.Length)
            {
                if (j == -1 || objStr[i] == objStr[j])
                    next[++i] = ++j;
                else
                    j = next[j];
            }

            return next;
        }
        /// <summary>
        /// KMP字符串查找算法
        /// </summary>
        /// <param name="next">Next数组</param>
        /// <returns></returns>
        public static int KMPSearch(string sourceStr, string objStr, int[] next, int startP = 0)
        {
            int i = startP;
            int j = 0;
            while (i < sourceStr.Length && j < objStr.Length)
            {
                if (j == -1 || sourceStr[i] == objStr[j])
                {
                    i++;
                    j++;
                }
                else
                {
                    j = next[j];
                }
            }

            if (j == objStr.Length)
                return i - j;
            else
                return -1;
        }
    }
}
