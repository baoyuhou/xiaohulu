using System;
using System.Collections.Generic;
using System.Text;
using Models;
using SqlSugar;

namespace Services.Explains.Services
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
                var explainList = sqlsc.Queryable<Explain>();
                return explainList as IList<Explain>;
            }
        }
    }
}
