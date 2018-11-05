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
        /// 添加用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        int Add(Users user);

        /// <summary>
        /// 查看全部
        /// </summary>
        /// <returns></returns>
        List<UsersInfo> GetUsersList();

        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        int Update(Users user);

        /// <summary>
        /// 反填用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int UpdateById(int id);
    }
}
