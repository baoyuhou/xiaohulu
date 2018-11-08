using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using IServices;

namespace XiaoHuLuApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExplainController : ControllerBase
    {
        private readonly ExplainsIServices _explainsIServices;
         public ExplainController(ExplainsIServices explainsIServices)
        {
            _explainsIServices = explainsIServices; 
        }

        /// <summary>
        /// 获取所有说明信息
        /// </summary>
        [Route("GetExplainList")]
        public IList<Explain> GetExplainList()
        {
          var explainList=   _explainsIServices.GetExplainList();
            return explainList;
        }

        /// <summary>
        /// 添加说明信息
        /// </summary>
        /// <param name="explain"></param>
        /// <returns></returns>
        [Route("Addexplain")]
        [HttpPost]
        public long Addexplain(Explain explain)
        {
            return _explainsIServices.AddExplain(explain);
        }

        /// <summary>
        /// 反填说明信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("GetExplainById")]
        [HttpGet]
        public Explain GetExplainById(int id)
        {
            return _explainsIServices.GetExplainById(id);
        }

        /// <summary>
        /// 修改说明信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("UpdExplain")]
        [HttpPost]
        public int UpdExplain(Explain explain)
        {
            return _explainsIServices.UpdExplain(explain);
        }
    }
}

