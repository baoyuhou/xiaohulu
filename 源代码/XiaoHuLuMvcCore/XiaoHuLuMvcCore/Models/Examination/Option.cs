using System;
using System.Collections.Generic;
using System.Text;

namespace XiaoHuLuMvcCore.Models.Examination
{
    public class Option
    {
        /// <summary>
        /// 选项表主键
        /// </summary>
        public int Id { get; set; }

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
