using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using XiaoHuLuMvcCore.Models;
using Newtonsoft.Json;


namespace XiaoHuLuMvcCore.Controllers
{
    public class ExplainController : Controller
    {
        /// <summary>
        /// 所有说明信息列表
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var result = WebApiHelper.GetApiResult("get", "Explain", "GetExplainList");
            return View(JsonConvert.DeserializeObject<List<Explain>>(result));
        }
    }
}