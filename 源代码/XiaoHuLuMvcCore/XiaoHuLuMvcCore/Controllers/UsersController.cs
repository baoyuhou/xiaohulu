using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using XiaoHuLuMvcCore.Models.Authority;
using Newtonsoft.Json;
using XiaoHuLuMvcCore.Models;
namespace XiaoHuLuMvcCore.Controllers
{
    public class UsersController : Controller
    {
        /// <summary>
        /// 显示全部信息
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var result = WebApiHelper.GetApiResult("Get", "User", "GetUserList");
            return View(JsonConvert.DeserializeObject<List<UsersInfo>>(result));
        }

        /// <summary>
        /// 单条添加用户信息
        /// </summary>
        /// <param name="usersInfo"></param>
        /// <returns></returns>
        public IActionResult UserAdd(UsersInfo usersInfo)
        {
            var result = WebApiHelper.GetApiResult("Post", "User", "UsersAdd",usersInfo);
            return View(usersInfo);
        }
    }
}