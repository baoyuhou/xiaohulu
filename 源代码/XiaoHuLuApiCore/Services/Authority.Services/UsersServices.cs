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
        public SimpleClient<Users> UsersDB = new SimpleClient<Users>(Educationcontext.GetClient());
        /// <summary>
        /// 单条添加用户
        /// </summary>
        /// <param name="usersInfo"></param>
        /// <returns></returns>
        public int Add(UsersInfo usersInfo)
        {
            Users users = new Users();
            users.Name = usersInfo.Name;
            users.Password = usersInfo.Password; 
            var result = UsersDB.Insert(users);
            if (result)
            {
                SqlSugarClient sqlSugarClient = Educationcontext.GetClient();

                var db = sqlSugarClient.SqlQueryable<Users>("select Id from Users order by Id DESC limit 1").First();
                var userid = db.Id;
                UserandRole userandRole = new UserandRole();
                userandRole.UserId = userid;
                userandRole.RoleId = usersInfo.RoleId;
                var a = UsersDB.Insert(users);
                if (a)
                {
                    return 1;
                }
            }
        }
   
        /// <summary>
        /// 显示全部信息
        /// </summary>
        /// <returns></returns>
        public List<UsersInfo> GetUsersList()
        {
            using (SqlSugarClient db = Educationcontext.GetClient())
            {
                var InfoList = db.Queryable<UsersInfo>().ToList();
                return InfoList as List<UsersInfo>;
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
