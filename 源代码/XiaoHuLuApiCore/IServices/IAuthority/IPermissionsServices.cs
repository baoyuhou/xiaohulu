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
        User Login(string name, string pwd);

        /// <summary>
        /// 获取权限列表
        /// </summary>
        /// <param name="YHID"></param>
        /// <returns></returns>
        List<Permissions> GetPermissions(int YHID = -1);

        /// <summary>
        /// 权限添加
        /// </summary>
        /// <param name="permissions"></param>
        /// <returns></returns>
        int Add(Permissions permissions);

        /// <summary>
        /// 权限修改
        /// </summary>
        /// <param name="permissions"></param>
        /// <returns></returns>
        int UpdateById(Permissions permissions);

        /// <summary>
        /// 权限删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DeleteByid(int id);

        /// <summary>
        /// 权限反填
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Permissions EditById(int id);
    }
}
