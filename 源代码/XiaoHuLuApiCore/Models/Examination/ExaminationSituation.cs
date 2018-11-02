using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Examination
{
    public class ExaminationSituation
    {
        /// <summary>
        /// 考试情况主键
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 准考证号码
        /// </summary>
        public string ExamNumber { get; set; }

        /// <summary>
        /// 题目Id外键
        /// </summary>
        public int QuestionBankId { get; set; }

        /// <summary>
        /// 作答选项
        /// </summary>
        public string Answer { get; set; }
    }
}
