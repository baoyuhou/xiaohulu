using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XiaoHuLuMvcCore.Models.Authoritys
{
    /// <summary>
    /// 角色权限从表
    /// </summary>
    public class JurisdictionInfo
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public int Id { get; set; }

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
        /// 权限路径
        /// </summary>
        public string Url { get; set; }

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
