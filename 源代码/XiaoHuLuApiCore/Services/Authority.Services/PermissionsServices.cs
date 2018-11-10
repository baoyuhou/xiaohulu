using System;
using System.Collections.Generic;
using System.Text;

using Models;
using Models.Authority;
using IServices.Authority.IServices;
using SqlSugar;
namespace Services.Authority.Services
{
    public class PermissionsServices : IPermissionsServices
    {
        /// <summary>
        /// 获取权限信息
        /// </summary>
        /// <returns></returns>
        public List<Jurisdiction> GetJurisdictions()
        {
            using (SqlSugarClient db = Educationcontext.GetClient())
            {
                var result = db.SqlQueryable<Jurisdiction>("select * from Jurisdiction");
                return result.ToList();
            }
        }
    }
}
