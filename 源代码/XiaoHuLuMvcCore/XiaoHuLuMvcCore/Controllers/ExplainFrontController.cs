using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace XiaoHuLuMvcCore.Controllers.Front
{
    public class ExplainFrontController : Controller
    {
        /// <summary>
        /// 考生首页
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 练习页面
        /// </summary>
        /// <returns></returns> 
        public IActionResult Practice()
        {
            return View();
        }
    }
}