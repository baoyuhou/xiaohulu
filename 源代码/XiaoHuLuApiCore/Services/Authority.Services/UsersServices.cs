using System;
using System.Collections.Generic;
using System.Text;

using Models.Authority;
using Models;
using IServices.IAuthority;
using SqlSugar;

namespace Services.Authority.Services
{
    public class UsersServices : IUserServices
    {
        //实例化用户从表
        public SimpleClient<UsersInfo> UsersInfoDB = new SimpleClient<UsersInfo>(Educationcontext.GetClient());

        //实例化用户表
        public SimpleClient<Users> UsersDB = new SimpleClient<Users>(Educationcontext.GetClient());

        /// <summary>
        /// 单条添加用户角色信息
        /// </summary>
        /// <param name="usersInfo"></param>
        /// <returns></returns>
        public int Add(UsersInfo usersInfo)
        {
            //实例化用户表
            Users users = new Users();
            users.UserName = usersInfo.UserName;
            users.Password = usersInfo.Password;
            var result = UsersDB.Insert(users);
            //如果result为true
            if (result)
            {
                SqlSugarClient sqlSugarClient = Educationcontext.GetClient();
               var  db = sqlSugarClient.SqlQueryable<Users>("select Id from Users order by Id  ").Max(s=>s.Id);
                //实例化用户角色表
                UserandRole userandRole = new UserandRole();
                userandRole.UsersId = db;
                var num = usersInfo.RoleName.Substring(0, usersInfo.RoleName.LastIndexOf(',')).Split(',');
             
                var usersdb = 0;
                foreach (var item in num)
                {
                    userandRole.RolesId = int.Parse(item);
                    usersdb += sqlSugarClient.Insertable<UserandRole>(userandRole).ExecuteCommand();
                }
                if (usersdb== num.Length)
                {
                    return 1;
                }
            }
            return 0;
        }

        /// <summary>
        /// 编辑修改信息
        /// </summary>
        /// <param name="usersInfo"></param>
        /// <returns></returns>
        public int EditById(UsersInfo usersInfo)
        {
            using (SqlSugarClient db = Educationcontext.GetClient())
            {
                var result = db.Updateable<UsersInfo>(usersInfo).ExecuteCommand();
                return result;
            }
        }

        /// <summary>
        /// 反填信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UsersInfo GetUsersInfoById(int id)
        {
            using (SqlSugarClient db = Educationcontext.GetClient())
            {
                var result = db.SqlQueryable<UsersInfo>("select a.Id,a.UserName,a.`Password`,b.RoleName,c.UsersId,c.RolesId from Users a,Role b,UserandRole c where a.Id="+id).First();
                return result;
            }
        }

        /// <summary>
        /// 获取用户角色信息
        /// </summary>
        /// <returns></returns>
        public List<UsersInfo> GetUsersList()
        {
            using (SqlSugarClient db = Educationcontext.GetClient())
            {
                //三表联查
                var result = db.SqlQueryable<UsersInfo>("select a.Id,a.UserName,a.`Password`,b.RoleName,c.UsersId,c.RolesId from Users a,Role b,UserandRole c where a.Id=c.UsersId and b.Id=c.RolesId");
                return result.ToList();
            }
        }
    }
}
