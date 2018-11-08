using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace XiaoHuLuMvcCore.Controllers
{
    public class QuestionBankController : Controller
    {
        /// <summary>
        /// 题库管理
        /// </summary>
        /// <returns></returns>
        public IActionResult QuestionsManagement()
        {
            return View();
        }

        public IActionResult text()
        {
            return View();
        }

    }
}