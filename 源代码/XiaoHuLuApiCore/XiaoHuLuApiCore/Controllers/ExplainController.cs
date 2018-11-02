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
    }
}

