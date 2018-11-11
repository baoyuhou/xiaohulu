using Models;
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

        /// <summary>
        ///添加说明信息
        /// </summary>
        /// <returns></returns>
        long AddExplain(Explain explain);

        /// <summary>
        /// 反填信息
        /// </summary>
        /// <returns></returns>
        Explain GetExplainById(int id);

        /// <summary>
        /// 修改说明信息
        /// </summary>
        /// <returns></returns>
        int UpdExplain(Explain explain);

        /// <summary>
        /// 获取今天是不是考试过了
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool GetTypeByUid(string id);


    }
}
