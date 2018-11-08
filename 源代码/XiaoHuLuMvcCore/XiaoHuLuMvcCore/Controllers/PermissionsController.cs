using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using XiaoHuLuMvcCore.Models.Authoritys;
using Newtonsoft.Json;
using XiaoHuLuMvcCore.Models;
namespace XiaoHuLuMvcCore.Controllers
{
    public class nController : Controller
    {
        /// <summary>
        /// 显示全部信息
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var result = WebApiHelper.GetApiResult("Get", "Permissions", "GetJurisList");
            return View(JsonConvert.DeserializeObject<List<Jurisdictions>>(result));
        }
    }
}