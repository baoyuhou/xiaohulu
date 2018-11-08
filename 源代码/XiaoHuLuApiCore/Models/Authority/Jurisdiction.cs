using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Authority
{
    /// <summary>
    /// 权限表
    /// </summary>
   public class Jurisdiction
    {
        /// <summary>
        /// 主键id
        /// </summary>
        public int JurisId { get; set; }

        /// <summary>
        /// 权限名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 权限级别
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// 父级权限
        /// </summary>
        public int Father { get; set; }
        /// <summary>
        /// 子级权限
        /// </summary>
        public int Child { get; set; }
    }
}
