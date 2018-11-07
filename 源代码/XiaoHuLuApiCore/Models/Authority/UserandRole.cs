using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Authority
{
    /// <summary>
    /// 用户角色表
    /// </summary>
   public class UserandRole
    {
        /// <summary>
        /// 主键id
        /// </summary>
        public int AssociatedId { get; set; }

        /// <summary>
        /// 用户id
        /// </summary>
        public int UsersId { get; set; }

        /// <summary>
        /// 角色id
        /// </summary>
        public int RolesId { get; set; }
    }
}
