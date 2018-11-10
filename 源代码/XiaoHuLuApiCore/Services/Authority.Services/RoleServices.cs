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
        //角色表
        public SimpleClient<Role> RoleDB = new SimpleClient<Role>(Educationcontext.GetClient());
        //角色从表
        public SimpleClient<JurisdictionInfo> SimpleClient = new SimpleClient<JurisdictionInfo>(Educationcontext.GetClient());
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

        /// <summary>
        /// 获取权限信息
        /// </summary>
        /// <returns></returns>
        public List<Jurisdiction> GetJurisdictions()
        {
            using (SqlSugarClient db = Educationcontext.GetClient())
            {
                var result = db.SqlQueryable<Jurisdiction>("select * from Jurisdiction");
                return result.ToList(); ;
            }
        }

        /// <summary>
        /// 获取角色信息
        /// </summary>
        /// <returns></returns>
        public List<JurisdictionInfo> GetRoles()
        {
            using (SqlSugarClient db = Educationcontext.GetClient())
            {
                var result = db.SqlQueryable<JurisdictionInfo>("SELECT a.Id,a.RoleName,b.`Name`,b.`level`,b.Url,c.RolesId,c.JurisdictionId FROM role a,jurisdiction b,roleandjurisdiction c WHERE a.Id=c.RolesId AND b.Id=c.JurisdictionId");
                return result.ToList();
            }
        }
    }
}
