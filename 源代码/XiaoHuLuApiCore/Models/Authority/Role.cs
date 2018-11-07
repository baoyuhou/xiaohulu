using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Authority
{
    /// <summary>
    /// 角色表
    /// </summary>
    public class Role
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// 角色名
        /// </summary>
        public string RoleName { get; set; }
    }
}
