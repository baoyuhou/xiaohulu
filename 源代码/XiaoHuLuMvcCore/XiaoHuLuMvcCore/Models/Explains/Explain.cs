using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace XiaoHuLuMvcCore.Models
{
    /// <summary>
    /// 说明表
    /// </summary>
    public class Explain
    {
        [Display(Name = "序号")]
        public int Id { get; set; }

        /// <summary>
        /// 说明内容
        /// </summary>
        [Display(Name = "说明内容")]
        public string Description { get; set; }

        /// <summary>
        /// 说明地址
        /// </summary>
        [Display(Name = "说明地址")]
        public string Address { get; set; }
    }
}
