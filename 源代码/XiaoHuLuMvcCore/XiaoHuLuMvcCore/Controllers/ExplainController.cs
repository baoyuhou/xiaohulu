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
            return View();
        }

        public string GetList()
        {
            var result = WebApiHelper.GetApiResult("get", "Explain", "GetExplainList");
            return result;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Explain explain)
        {
            var result = WebApiHelper.GetApiResult("post", "Explain", "Addexplain",explain);
            if (result!=null||result!="" )
            {
                if (int.Parse(result)>0)
                {
                    return View("index");
                }
            }
            return View(explain);
        }
    }
}