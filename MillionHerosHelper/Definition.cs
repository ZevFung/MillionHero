using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MillionHerosHelper
{

    /// <summary>
    /// 分析结果
    /// </summary>
    public struct AnalyzeResult
    {
        /// <summary>
        /// 最可能为正确的答案索引,从0开始
        /// </summary>
        public int Index;
        /// <summary>
        /// PMI算法的权重
        /// </summary>
        public double[] PMIRank;
        /// <summary>
        /// 计数算法的权重
        /// </summary>
        public double[] CntRank;
        /// <summary>
        /// 总权重
        /// </summary>
        public double[] SumRank;
    }
    /// <summary>
    /// 用于多线程传递任务类型
    /// </summary>
    public enum TaskType
    {
        AnswerCnt = 0,
        ProblemAndAnswerCnt = 1,
        GetProblemData
    }

    public struct WorkArgs
    {
        /// <summary>
        /// 工作类型
        /// </summary>
        public TaskType Type;
        /// <summary>
        /// 数组元素索引
        /// </summary>
        public int Index;
        /// <summary>
        /// 内容
        /// </summary>
        public string Text;
    }

    public class APIException : ApplicationException
    {
        public APIException(string message) : base(message) { }
    }

    public class ADBException : ApplicationException
    {
        public ADBException(string message) : base(message) { }
    }

    public class OCRException : ApplicationException
    {
        public OCRException(string message) : base(message) { }
    }

    public class TimeLimitException : ApplicationException
    {
        public TimeLimitException(string message) : base(message) { }
    }
}
