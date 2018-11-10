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
        /// 单条添加角色和权限信息
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        int Add(JurisdictionInfo jurisdictionInfo);

        /// <summary>
        /// 获取角色信息9
        /// </summary>
        /// <returns></returns>
        List<Role> GetRoles();

        /// <summary>
        /// 获取角色权限列表
        /// </summary>
        /// <returns></returns>
        List<JurisdictionInfo> GetJurisdictionInfos();
    }
}
