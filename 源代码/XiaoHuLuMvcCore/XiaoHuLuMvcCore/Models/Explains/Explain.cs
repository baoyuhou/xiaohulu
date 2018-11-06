using System;
using System.Collections.Generic;
using System.Text;

namespace XiaoHuLuMvcCore.Models
{
    /// <summary>
    /// 说明表
    /// </summary>
    public class Explain
    {
        public int Id { get; set; }

        /// <summary>
        /// 说明内容
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 说明地址
        /// </summary>
        public string Address { get; set; }
    }
}
