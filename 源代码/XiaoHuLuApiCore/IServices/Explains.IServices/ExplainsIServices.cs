using System;
using System.Collections.Generic;
using System.Text;

namespace IServices
{
   public interface ExplainsIServices
    {
        /// <summary>
        /// 获取所有说明信息
        /// </summary>
        /// <returns></returns>
        IList<Models.Explain> GetExplainList();
    }
}
