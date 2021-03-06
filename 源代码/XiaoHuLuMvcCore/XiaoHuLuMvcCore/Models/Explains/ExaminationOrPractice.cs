﻿using System;
using System.Collections.Generic;
using System.Text;

namespace XiaoHuLuMvcCore.Models
{
    /// <summary>
    /// 练习Or考试表
    /// </summary>
   public class ExaminationOrPractice
    {
        public int Id { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        public string UId { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public bool Flag { get; set; }
    }
}
