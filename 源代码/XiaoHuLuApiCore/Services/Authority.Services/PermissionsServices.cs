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
        public List<Jurisdiction> GetPermissions()
        {
            using (SqlSugarClient db = Educationcontext.GetClient())
            {
                var JurisList = db.Queryable<Jurisdiction>().ToList();
                return JurisList as List<Jurisdiction>;
            }
        }

        public Users Login(string name, string pwd)
        {
            throw new NotImplementedException();
        }
    }
}
