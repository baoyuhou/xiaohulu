using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using XiaoHuLuMvcCore.Models.Examination;
using Newtonsoft.Json;
using XiaoHuLuMvcCore.Models;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;

namespace XiaoHuLuMvcCore.Controllers
{
    public class UsersFrontController : Controller
    {
        /// <summary>
        /// 显示全部考生信息
        /// </summary>
        /// <returns></returns>
        public IActionResult Index(string examNumber)
        {
            examNumber = HttpContext.Session.GetString("candidate");
           
            return View(JsonConvert.DeserializeObject<Candidateinherit>(examNumber));
        }
    }
}