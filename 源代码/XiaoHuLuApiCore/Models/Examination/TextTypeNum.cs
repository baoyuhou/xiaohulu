using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Examination
{
    public class TextTypeNum
    {
        /// <summary>
        /// 题量表主键
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 题型外键
        /// </summary>
        public int TextTypeId { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int Num { get; set; }
    }
}
