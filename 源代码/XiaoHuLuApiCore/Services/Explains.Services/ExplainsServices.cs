﻿using System;
using System.Collections.Generic;
using System.Text;
using Models;
using SqlSugar;

namespace Services
{
    /// <summary>
    /// 说明管理
    /// </summary>
    public class ExplainsServices : IServices.ExplainsIServices
    {
        /// <summary>
        /// 添加说明信息
        /// </summary>
        /// <param name="explain"></param>
        /// <returns></returns>
        public long AddExplain(Explain explain)
        {
            using (SqlSugarClient sqlsc = Educationcontext.GetClient())
            {
                var  result = sqlsc.Insertable(explain).ExecuteReturnIdentity();
                return result;
            }
        }

        /// <summary>
        /// 获取说明信息根据Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Explain GetExplainById(int id)
        {
            using (SqlSugarClient sqlsc = Educationcontext.GetClient())
            {
                var result = sqlsc.Queryable<Explain>().First(s=>s.Id==id);
                return result;
            }
        }

        /// <summary>
        /// 获取所有说明信息
        /// </summary>
        /// <returns></returns>
        public IList<Explain> GetExplainList()
        {
            using (SqlSugarClient sqlsc=Educationcontext.GetClient())
            {
                var explainList = sqlsc.Queryable<Explain>().ToList();
                return explainList as IList<Explain>;
            }
        }

        /// <summary>
        /// 获取今天用户是不是考试过了
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool GetTypeByUid(string id)
        {
            using (SqlSugarClient sqlsc=Educationcontext.GetClient())
            {
                ExaminationOrPractice result = sqlsc.Queryable<ExaminationOrPractice>().First(s=>s.UId==id);
                return result.Flag;
            } 
        }

        /// <summary>
        /// 修改说明信息
        /// </summary>
        /// <param name="explain"></param>
        /// <returns></returns>
        public int UpdExplain(Explain explain)
        {
            using (SqlSugarClient sqlsc = Educationcontext.GetClient())
            {
                var result = sqlsc.Updateable(explain).ExecuteCommand();
                return result;
            }
        }
    }
}
