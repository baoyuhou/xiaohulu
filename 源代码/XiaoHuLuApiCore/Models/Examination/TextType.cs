using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Examination
{
    public class TextType
    {
        /// <summary>
        /// 题型表主键
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 题型名称
        /// </summary>
        public string ExamType { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public int Enable { get; set; }
);
    }
}
