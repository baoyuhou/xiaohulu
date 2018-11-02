using System;
using System.Collections.Generic;
using System.Text;

using Models;
using Models.Authority;
namespace IServices.IAuthority
{
   public interface IRoleServices
    {
        /// <summary>
        /// 获取角色集合
        /// </summary>
        /// <returns></returns>
        List<Role> GetRoleList(int userid = -1);

        /// <summary>
        /// 获取权限列表
        /// </summary>
        /// <returns></returns>
        List<Jurisdiction> GetJurisdictions();

        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="role"></param>
        /// <param name="ids"></param>
        /// <returns></returns>
        int Add(Role role, string ids);
        /// <summary>
        /// 角色删除
        /// </summary>
        /// <param name="roleid"></param>
        /// <returns></returns>
        int DeleteById(int roleid);

        /// <summary>
        /// 角色反添
        /// </summary>
        /// <param name="roleid"></param>
        /// <returns></returns>
        Role EditById(int roleid);

        /// <summary>
        /// 角色编辑
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        int Edit(Role role, string ids);

        /// <summary>
        /// 获取角色所对应的权限
        /// </summary>
        /// <param name="roleid"></param>
        /// <returns></returns>
        List<RoleanJurisdiction> GetRoleanJurisdictions(int roleid);
    }
}
