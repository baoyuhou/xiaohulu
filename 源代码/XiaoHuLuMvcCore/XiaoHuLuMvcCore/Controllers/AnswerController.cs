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
            var result = WebApiHelper.GetApiResult("Get", "Answer", "GetAnswerModelList");
            return View(JsonConvert.DeserializeObject<List<AnswerModel>>(result));
        }
    }
}