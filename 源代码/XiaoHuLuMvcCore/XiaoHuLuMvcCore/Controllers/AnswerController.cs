using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;
using XiaoHuLuMvcCore.Models;
using XiaoHuLuMvcCore.Models.Examination;
using XiaoHuLuMvcCore.Models.Authority;
using AutherationTest;

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
            ///获取考试题
            var texttypelist = WebApiHelper.GetApiResult("Get", "Answer", "GetTextTypeList");
            ViewBag.texttype = JsonConvert.DeserializeObject<List<TextType>>(texttypelist);
            var result = WebApiHelper.GetApiResult("Get", "Answer", "GetAnswerModelList");
            //获取登陆人信息
            var examNumber = User.Claims.First(m => m.Type == "key").Value;
            var user = RedisHelper.Get<Candidate>(examNumber);
            //UsersInfo usersInfo = JsonConvert.DeserializeObject<UsersInfo>(HttpContext.Session.GetString("candidate"));
            //说明显示
            var explain = WebApiHelper.GetApiResult("get", "explain", "GetExplainById?id=" + user.ID);
            ViewBag.explain = JsonConvert.DeserializeObject<Explain>(explain).Description;

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