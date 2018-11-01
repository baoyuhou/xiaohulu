using System;
using System.Collections.Generic;
using System.Text;

namespace Models.QuestionBank
{
    public class TestTime
    {
        /// <summary>
        /// 考试时间主键
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 准考证号码
        /// </summary>
        public int ExamNumberId { get; set; }

        /// <summary>
        /// 考试总时长
        /// </summary>
        public int LongExam { get; set; }

        /// <summary>
        /// 所用时长
        /// </summary>
        public int TimeUsed { get; set; }

        /// <summary>
        /// 剩余时长
        /// </summary>
        public int RemainderLength { get; set; }

        /// <summary>
        /// 答题进度
        /// </summary>
        public int ProgressOfAnswer { get; set; }
    }
}
