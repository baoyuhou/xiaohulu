using System;
using System.Collections.Generic;
using System.Text;

using Models;
using Models.Authority;
namespace IServices.IAuthority
{
    /// <summary>
    /// 权限接口层
    /// </summary>
    public interface IPermissionsServices
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        Users Login(string name, string pwd);

        /// <summary>
        /// 根据角色和权限获取列表
        /// </summary>
        /// <param name="YHID"></param>
        /// <returns></returns>
        List<JurisdictionInfo> GetPermissions();
        /// <summary>
        /// 修改权限
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        int Edit(Jurisdiction jurisdiction);

        /// <summary>
        /// 反填权限信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Jurisdiction EditById(int id);

    }
}
