using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Authority
{
    /// <summary>
    /// 角色权限从表
    /// </summary>
    public class JurisdictionInfo
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// 角色名
        /// </summary>
        public string RoleName { get; set; }
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
        /// <summary>
        /// 角色id
        /// </summary>
        public int RolesId { get; set; }

        /// <summary>
        /// 权限id
        /// </summary>
        public int JurisdictionId { get; set; }
    }
}
