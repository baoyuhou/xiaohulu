using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using XiaoHuLuMvcCore.Models;

namespace XiaoHuLuMvcCore.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

       [HttpPost]
        public string Index(string name,string pwd)
        {
            //查看学生表里有没有匹配的人
            var result = WebApiHelper.GetApiResult("get", "Examination", "GetCandidate/?examNumber=" + name);
            if (string.IsNullOrEmpty(result))
            {
                //如果为空表示不是考生，开始查询是不是后台人员
                var roleResult = WebApiHelper.GetApiResult("get", "Examination", "GetUsersByNameAndPwd?name="+name+"&pwd="+pwd);
                if (string.IsNullOrEmpty(roleResult))
                {
                    //如果为空表示不是后台人员，确定输入密码错误
                    return "3";
                }
                return "2";
            }
            return  "1";
        }
    }
}