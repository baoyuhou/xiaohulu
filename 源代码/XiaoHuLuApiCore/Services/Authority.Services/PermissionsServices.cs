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
        public int Add(Jurisdiction jurisdiction)
        {
            using (SqlSugarClient db = Educationcontext.GetClient())
            {
                var result = db.Insertable<Jurisdiction>(jurisdiction).ExecuteReturnIdentity();
                return result;
            }
        }

        /// <summary>
        /// 获取权限信息
        /// </summary>
        /// <returns></returns>
        public List<Jurisdiction> GetJurisdictions()
        {
            using (SqlSugarClient db = Educationcontext.GetClient())
            {
                var result = db.SqlQueryable<Jurisdiction>("select * from Jurisdiction where Level=0");
                var list = result.ToList();
                return list;
            }
        }
    }
}
