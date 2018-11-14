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
using AutherationTest;

namespace XiaoHuLuMvcCore.Controllers
{
    public class UsersFrontController : Controller
    {
        /// <summary>
        /// 显示全部考生信息
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
           var  examNumber = User.Claims.First(m => m.Type == "key").Value;
            var user = RedisHelper.Get<Candidate>(examNumber);
            return View(user);
        }
    }
}