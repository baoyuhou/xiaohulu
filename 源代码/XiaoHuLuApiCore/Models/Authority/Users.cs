using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Authority
{
    /// <summary>
    /// 用户表
    /// </summary>
   public class Users
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 用户密码
        /// </summary>
        public int Password { get; set; }
    }
}
