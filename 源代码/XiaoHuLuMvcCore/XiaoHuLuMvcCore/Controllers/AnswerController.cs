using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;
using XiaoHuLuMvcCore.Models;
using XiaoHuLuMvcCore.Models.Examination;

namespace XiaoHuLuMvcCore.Controllers
{
    public class AnswerController : Controller
    {
        /// <summary>
        /// 显示答题
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var texttypelist = WebApiHelper.GetApiResult("Get", "Answer", "GetTextTypeList");
            ViewBag.texttype = JsonConvert.DeserializeObject<List<TextType>>(texttypelist);
            var result = WebApiHelper.GetApiResult("Get", "Answer", "GetAnswerModelList");
            return View(JsonConvert.DeserializeObject<List<AnswerModel>>(result));
        }

        /// <summary>
        /// 考试交卷页面
        /// </summary>
        /// <returns></returns>
        public IActionResult End()
        {
            return View();
        }
    }
}