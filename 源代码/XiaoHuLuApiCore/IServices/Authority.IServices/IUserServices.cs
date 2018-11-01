using System;
using System.Collections.Generic;
using System.Text;

using Models;
using Models.Authority;
namespace IServices.IAuthority
{
    /// <summary>
    /// 用户接口层
    /// </summary>
   public interface IUserServices
    {
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="roleid"></param>
        /// <returns></returns>
        int DeleteById(int roleid);
    }
}
