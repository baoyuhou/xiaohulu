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
        int Add(JurisdictionInfo jurisdictionInfo);
        
        /// <summary>
        /// 获取角色列表
        /// </summary>
        /// <returns></returns>
        List<JurisdictionInfo> GetRoles();

        /// <summary>
        /// 修改角色
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        int Edit(Role role);

        /// <summary>
        /// 反填角色信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Role EditById(int id);

        /// <summary>
        /// 获取权限信息
        /// </summary>
        /// <returns></returns>
        List<Jurisdiction> GetJurisdictions(); 
    }
}
