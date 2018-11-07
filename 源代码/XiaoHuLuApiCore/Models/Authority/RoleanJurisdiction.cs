using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    /// <summary>
    /// 角色权限表
    /// </summary>
    public class RoleanJurisdiction
    {
        /// <summary>
        /// 主键id
        /// </summary>
        public int RandjId { get; set; }

        /// <summary>
        /// 角色id
        /// </summary>
        public int RolesId { get; set; }

        /// <summary>
        /// 权限id
        /// </summary>
        public int  JurisdictionId{ get; set; }
    }
}
