﻿using SqlSugar;
using System;
using System.Linq;

namespace Models
{
    public class Educationcontext
    {
        public static SqlSugarClient GetClient()
        {
            SqlSugarClient db = new SqlSugarClient(
             new ConnectionConfig()
             {
                 ConnectionString = "Database=education;Data Source=169.254.83.207;Port=3306;User Id=root;Password=123456;Charset=utf8;TreatTinyAsBoolean=false;",
                 DbType = DbType.MySql,
                 IsAutoCloseConnection = true
             }
             );
            db.Aop.OnLogExecuting = (sql, pars) =>
            {
                Console.WriteLine(sql + "\r\n" + db.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value)));
                Console.WriteLine();
            };
            return db;
        }

    }
}
