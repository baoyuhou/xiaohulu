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
        /// <summary>
        /// 
        /// </summary>
        public SimpleClient<Role> RoleDB = new SimpleClient<Role>(Educationcontext.GetClient());


        ///角色、权限从表
        public SimpleClient<JurisdictionInfo> SimpleClient = new SimpleClient<JurisdictionInfo>(Educationcontext.GetClient());

        /// <summary>
        /// 单条添加用户角色数据
        /// </summary>
        /// <param name="jurisdictionInfo"></param>
        /// <returns></returns>
        public int Add(JurisdictionInfo jurisdictionInfo)
        {
            //实例化角色表
            Role role = new Role();
            role.RoleName = jurisdictionInfo.RoleName;
            var result = RoleDB.Insert(role);
            //如果为true
            if (result)
            {
                SqlSugarClient sqlSugarClient = Educationcontext.GetClient();
                //排序查询最大值
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

        /// <summary>
        /// 获取角色和权限信息
        /// </summary>
        /// <returns></returns>
        public List<JurisdictionInfo> GetJurisdictionInfos()
        {
            using (SqlSugarClient db = Educationcontext.GetClient())
            {
                var result = db.SqlQueryable<JurisdictionInfo>("SELECT a.Id,a.RoleName,b.`Name`,b.`level`,b.Url,c.RolesId,c.JurisdictionId FROM role a,jurisdiction b,roleandjurisdiction c WHERE a.Id=c.RolesId AND b.Id=c.JurisdictionId");
                return result.ToList();
            }
        }

        /// <summary>
        /// 获取角色信息
        /// </summary>
        /// <returns></returns>
        public List<Role> GetRoles()
        {
            using (SqlSugarClient db = Educationcontext.GetClient())
            {
                var result = db.SqlQueryable<Role>("select * from Role");
                return result.ToList(); ;
            }
        }
    }
}
