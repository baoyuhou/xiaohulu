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
        /// 获取权限列表
        /// </summary>
        /// <param name="YHID"></param>
        /// <returns></returns>
        List<Jurisdiction> GetPermissions(int YHID = -1);

        /// <summary>
        /// 权限添加
        /// </summary>
        /// <param name="permissions"></param>
        /// <returns></returns>
        int Add(Jurisdiction permissions);

        /// <summary>
        /// 权限修改
        /// </summary>
        /// <param name="permissions"></param>
        /// <returns></returns>
        int UpdateById(Jurisdiction permissions);

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
        Jurisdiction EditById(int id);
    }
}
