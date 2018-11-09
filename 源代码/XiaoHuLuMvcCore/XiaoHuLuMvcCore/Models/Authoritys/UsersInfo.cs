using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XiaoHuLuMvcCore.Models.Authority
{
    public class UsersInfo
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 用户密码
        /// </summary>
        public int Password { get; set; }

        /// <summary>
        /// 角色Id
        /// </summary>
        public string RoleName { get; set; }
    }
}
