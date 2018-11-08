using System;
using System.Collections.Generic;
using System.Text;

using Models;
using Models.Authority;
using IServices.IAuthority;
using SqlSugar;
namespace Services.Authority.Services
{
    public class PermissionsServices : IPermissionsServices
    {
        public int Edit(Jurisdiction jurisdiction)
        {
            throw new NotImplementedException();
        }

        public Jurisdiction EditById(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取角色权限信息
        /// </summary>
        /// <returns></returns>
        public List<JurisdictionInfo> GetPermissions()
        {
            using (SqlSugarClient db = Educationcontext.GetClient())
            {
                var result = db.SqlQueryable<JurisdictionInfo>("select * from role,jurisdiction,roleandjurisdiction where role.RoleId=roleandjurisdiction.RolesId and jurisdiction.JurisId=roleandjurisdiction.JurisdictionId ");
                return result.ToList();
            }
        }

        public Users Login(string name, string pwd)
        {
            throw new NotImplementedException();
        }
    }
}
