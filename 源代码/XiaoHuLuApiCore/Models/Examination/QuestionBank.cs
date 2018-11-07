using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Examination
{
    public class QuestionBank
    {
        /// <summary>
        /// 题库主键
        /// </summary>
        public int Id { get; set; }
        
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
        public string Photo { get; set; }

        /// <summary>
        /// 题类型外键
        /// </summary>
        public int TypeOfExam { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public int Enable { get; set; }
    }
}
