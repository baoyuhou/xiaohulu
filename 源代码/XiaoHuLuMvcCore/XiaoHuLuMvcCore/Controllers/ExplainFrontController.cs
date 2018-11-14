using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using XiaoHuLuMvcCore.Models.Examination;
using XiaoHuLuMvcCore.Models;
using AutherationTest;
using Microsoft.AspNetCore.Authorization;

namespace XiaoHuLuMvcCore.Controllers.Front
{
    public class ExplainFrontController : Controller
    {
        /// <summary>
        /// 考生首页
        /// </summary>
        /// <returns></returns>
        /// 
        [Authorize]
        public IActionResult Index()
        {
            //取出登陆人的名字
            var candidateName = User.Claims.First(m => m.Type == "key").Value;
            //根据key值取出Redis的数据
            var candidate = RedisHelper.Get<Candidate>(candidateName);
            ViewBag.CandidateName = candidate.Name;
            ViewBag.CandidateId = candidate.ID;
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

        /// <summary>
        /// 获取考生今天是不是考试过了？
        /// </summary>
        /// <returns></returns>
        public string GetTypeByUid(string id)
        {
            var result = WebApiHelper.GetApiResult("get", "Explain", "GetTypeByUid?id=" + id);
            return result;
        }
    }
}