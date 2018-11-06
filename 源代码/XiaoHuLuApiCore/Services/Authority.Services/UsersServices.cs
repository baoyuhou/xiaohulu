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
        public int Add(UsersInfo usersInfo)
        {
            throw new NotImplementedException();
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


        public int Update(UsersInfo usersInfo)
        {
            throw new NotImplementedException();
        }

        UsersInfo IUserServices.UpdateById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
