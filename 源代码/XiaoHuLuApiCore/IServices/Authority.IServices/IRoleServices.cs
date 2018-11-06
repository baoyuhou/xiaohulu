using System;
using System.Collections.Generic;
using System.Text;

using Models;
using Models.Authority;
namespace IServices.IAuthority
{
    /// <summary>
    /// 角色接口层
    /// </summary>
   public interface IRoleServices
    {
        /// <summary>
        /// 单条添加角色
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        int Add(Role role);
    }
}
