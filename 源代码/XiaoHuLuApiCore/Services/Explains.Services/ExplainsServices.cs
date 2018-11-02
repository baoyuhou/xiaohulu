using System;
using System.Collections.Generic;
using System.Text;
using Models;
using SqlSugar;

namespace Services
{
    public class ExplainsServices : IServices.ExplainsIServices
    {
       
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
    }
}
