using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Examination
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
        public string ExamNumberId { get; set; }

        /// <summary>
        /// 考试总时长
        /// </summary>
        public double LongExam { get; set; }

        /// <summary>
        /// 所用时长
        /// </summary>
        public double TimeUsed { get; set; }

        /// <summary>
        /// 剩余时长
        /// </summary>
        public double RemainderLength { get; set; }

        /// <summary>
        /// 答题进度
        /// </summary>
        public string ProgressOfAnswer { get; set; }
    }
}
