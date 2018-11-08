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
        //实例化
        public SimpleClient<UsersInfo> UsersInfoDB = new SimpleClient<UsersInfo>(Educationcontext.GetClient());

        //
        public SimpleClient<Users> UsersDB = new SimpleClient<Users>(Educationcontext.GetClient());

        /// <summary>
        /// 单条添加用户
        /// </summary>
        /// <param name="usersInfo"></param>
        /// <returns></returns>
        public int Add(UsersInfo usersInfo)
        {
            Users users = new Users();
            users.UserName = usersInfo.UserName;
            users.Password = usersInfo.Password;
             var result = UsersDB.Insert(users);
            if (result)
            {
                SqlSugarClient sqlSugarClient = Educationcontext.GetClient();
               var  db = sqlSugarClient.SqlQueryable<Users>("select UserId from Users order by UserId  ").Max(s=>s.Id);

                UserandRole userandRole = new UserandRole();
                userandRole.UsersId = db;
                userandRole.RolesId = usersInfo.RolesId;
                var a = UsersDB.Insert(users);
                if (a)
                {
                    return 1;
                }
            }
            return 0;
        }
   
        /// <summary>
        /// 显示全部信息
        /// </summary>
        /// <returns></returns>
        public List<UsersInfo> GetUsersList()
        {
            using (SqlSugarClient db = Educationcontext.GetClient())
            {
                var result = db.SqlQueryable<UsersInfo>("select a.Id,a.UserName,a.`Password`,b.RoleName,c.UsersId,c.RolesId from Users a,Role b,UserandRole c where a.Id=c.UsersId and b.Id=c.RolesId");
                return result.ToList();
            }
        }

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="usersInfo"></param>
        /// <returns></returns>
        public int Edit(UsersInfo usersInfo)
        {
            var result = Convert.ToInt32(UsersInfoDB.Update(usersInfo));
            return result;
        }

        public Users EditById(int id)
        {
            var result = UsersDB.GetSingle(m => m.Id == id);
            return result;
        }
    }
}
