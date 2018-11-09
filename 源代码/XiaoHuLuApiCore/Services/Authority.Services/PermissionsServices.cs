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
        //实例化权限从表
        public SimpleClient<JurisdictionInfo> SimpleClient = new SimpleClient<JurisdictionInfo>(Educationcontext.GetClient());

        //实例化权限表
        public SimpleClient<Jurisdiction> simpleClient = new SimpleClient<Jurisdiction>(Educationcontext.GetClient());

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
                //三表联查
                var result = db.SqlQueryable<JurisdictionInfo>("select * from role a,jurisdiction b,roleandjurisdiction c where a.Id=c.RolesId and b.Id=c.JurisdictionId ");
                return result.ToList();
            }
        }

        /// <summary>
        /// 单条添加角色权限
        /// </summary>
        /// <param name="jurisdictionInfo"></param>
        /// <returns></returns>
        public int JurisAdd(JurisdictionInfo jurisdictionInfo)
        {
            Jurisdiction jurisdiction = new Jurisdiction();
            jurisdiction.Name = jurisdictionInfo.Name;
            jurisdiction.Level = jurisdictionInfo.Level;
            jurisdiction.Father = jurisdictionInfo.Father;
            jurisdiction.Child = jurisdictionInfo.Child;
            var result = simpleClient.Insert(jurisdiction);
            if (result)
            {
                SqlSugarClient sqlSugarClient = Educationcontext.GetClient();
                var db = sqlSugarClient.SqlQueryable<Jurisdiction>("select Id from Jurisdiction order by Id").Max(s => s.Id);
                RoleanJurisdiction roleanJurisdiction = new RoleanJurisdiction();
                roleanJurisdiction.RolesId = db;
                roleanJurisdiction.JurisdictionId = jurisdictionInfo.JurisdictionId;
                var a = simpleClient.Insert(jurisdiction);
                if (a)
                {
                    return 1;
                }
            }
            return 0;
        }

        public Users Login(string name, string pwd)
        {
            throw new NotImplementedException();
        }
    }
}
