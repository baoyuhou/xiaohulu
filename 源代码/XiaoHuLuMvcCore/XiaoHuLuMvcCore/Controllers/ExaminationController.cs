using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using XiaoHuLuMvcCore.Models.Examination;
using Newtonsoft.Json;
using XiaoHuLuMvcCore.Models;
namespace XiaoHuLuMvcCore.Controllers
{
    public class ExaminationController : Controller
    {
        /// <summary>
        /// 显示全部考生信息
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var result = WebApiHelper.GetApiResult("Get", "Examination", "GetCandidateList");
            return View(JsonConvert.DeserializeObject<List<Candidateinherit>>(result));
        }
    }
}