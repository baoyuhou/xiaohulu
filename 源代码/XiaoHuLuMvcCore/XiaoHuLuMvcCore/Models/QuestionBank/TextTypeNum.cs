using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models.QuestionBank
{
    public class TextTypeNum
    {
        /// <summary>
        /// 题量主键
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 题型外键
        /// </summary>
        public int TextTypeId { get; set; }

        /// <summary>
        /// 题量
        /// </summary>
        public int Num { get; set; }

    }
}
