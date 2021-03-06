﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Examination
{
    public class TextTypeNuminherit
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

        /// <summary>
        /// 题型名称
        /// </summary>
        public string ExamType { get; set; }
    }
}
