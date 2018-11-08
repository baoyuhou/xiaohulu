using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using XiaoHuLuMvcCore.Models;

namespace XiaoHuLuMvcCore.Controllers
{
    public class ExplainController : Controller
    {
        /// <summary>
        /// 显示所有说明信息
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var result = WebApiHelper.GetApiResult("get","explain", "GetExplainList");
            return View(JsonConvert.DeserializeObject<List<Explain>>(result));
        }

        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Details(int id)
        {
            var result = WebApiHelper.GetApiResult("get","explain", "GetExplainById?id=" + id);
            return View(JsonConvert.DeserializeObject< Explain>(result));
        }

        /// <summary>
        /// 添加一个新的说明信息
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public int Create(Explain explain)
        {
            var result = WebApiHelper.GetApiResult("post","explain", "Addexplain",explain);
            return int.Parse(result);
        }

        /// <summary>
        /// 反填要修改的信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Edit(int id)
        {
            var result = WebApiHelper.GetApiResult("get","explain", "GetExplainById?id="+id);
            return View(JsonConvert.DeserializeObject<Explain>(result));
        }
        [HttpPost]
        public int Edit(Explain explain)
        {
            var result = WebApiHelper.GetApiResult("post","explain", "UpdExplain", explain);
            return int.Parse(result);
        }

    }
}