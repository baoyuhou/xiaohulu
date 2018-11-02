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
        public int Add(Users user)
        {
            using (SqlSugarClient db = Educationcontext.GetClient())
            {
                var result = db.Insertable(user).ExecuteCommand();
                return result;
            }
        }

        public List<UsersInfo> GetUsersList()
        {
            throw new NotImplementedException();
        }

        public int Update(Users user)
        {
            throw new NotImplementedException();
        }

        public int UpdateById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
