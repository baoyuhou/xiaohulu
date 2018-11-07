using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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
        /// 单条添加用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        int Add(UsersInfo usersInfo);

        /// <summary>
        /// 根据用户和角色获取列表
        /// </summary>
        /// <returns></returns>
        List<UsersInfo> GetUsersList();

        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        int Edit(UsersInfo usersInfo);

        /// <summary>
        /// 反填用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Users EditById(int id);
    }
}
