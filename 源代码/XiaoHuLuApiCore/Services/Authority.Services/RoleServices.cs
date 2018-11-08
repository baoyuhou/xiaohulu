using System;
using System.Collections.Generic;
using System.Text;

using Models;
using Models.Authority;
using IServices.IAuthority;
using SqlSugar;

namespace Services.Authority
{
    public class RoleServices : IRoleServices
    {
        public SimpleClient<Role> RoleDB = new SimpleClient<Role>(Educationcontext.GetClient());
        public int Add(Role role)
        {
            var result = Convert.ToInt32(RoleDB.Insert(role));
            return result;
        }

        public int Edit(Role role)
        {
            var result = Convert.ToInt32(RoleDB.Update(role));
            return result;
        }

        public Role EditById(int id)
        {
            var result = RoleDB.GetSingle(m => m.Id == id);
            return result;
        }
    }
}
