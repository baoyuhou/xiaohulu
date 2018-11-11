using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace XiaoHuLuMvcCore.Controllers.Front
{
    public class ExplainFrontController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}