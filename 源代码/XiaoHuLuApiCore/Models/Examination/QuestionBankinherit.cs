using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Examination
{
    public class QuestionBankinherit
    {
        /// <summary>
        /// 题库主键
        /// </summary>
        //public int Id { get; set; }

        /// <summary>
        /// 题目
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// 正确答案
        /// </summary>
        public string Answer { get; set; }

        /// <summary>
        /// 附件图片
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 题类型外键
        /// </summary>
        public int TypeOfExam { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public int Enable { get; set; }

        /// <summary>
        /// 题目外键
        /// </summary>
        public int QuestionBankId { get; set; }

        /// <summary>
        /// 答案A
        /// </summary>
        public string AnswerA { get; set; }

        /// <summary>
        /// 答案B
        /// </summary>
        public string AnswerB { get; set; }

        /// <summary>
        /// 答案C
        /// </summary>
        public string AnswerC { get; set; }

        /// <summary>
        /// 答案D
        /// </summary>
        public string AnswerD { get; set; }

        /// <summary>
        /// 答案E
        /// </summary>
        public string AnswerE { get; set; }
    }
}
