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
        //角色、权限从表
        public SimpleClient<JurisdictionInfo> SimpleClient = new SimpleClient<JurisdictionInfo>(Educationcontext.GetClient());
        public int Add(JurisdictionInfo jurisdictionInfo)
        {
            Role role = new Role();
            role.RoleName = jurisdictionInfo.RoleName;
            var result = RoleDB.Insert(role);
            if (result)
            {
                SqlSugarClient sqlSugarClient = Educationcontext.GetClient();
                var db = sqlSugarClient.SqlQueryable<Role>("select Id from Role order by Id").Max(s => s.Id);
                RoleanJurisdiction roleanJurisdiction = new RoleanJurisdiction();
                roleanJurisdiction.RolesId = db;
                var num = jurisdictionInfo.Name.Substring(0, jurisdictionInfo.Name.LastIndexOf(',')).Split(',');
                var roledb = 0;
                foreach (var item in num)
                {
                    roleanJurisdiction.JurisdictionId = int.Parse(item);
                    roledb += sqlSugarClient.Insertable<RoleanJurisdiction>(roleanJurisdiction).ExecuteCommand();
                }
                if (roledb == num.Length)
                {
                    return 1;
                }
            }
            return 0;
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
