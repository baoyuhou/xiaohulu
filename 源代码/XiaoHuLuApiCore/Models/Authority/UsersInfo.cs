using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Authority
{
    /// <summary>
    /// 用户从表
    /// </summary>
    public class UsersInfo:Users
    {
        /// <summary>
        /// 角色名
        /// </summary>
        public int RoleId { get; set; }
    }
}
