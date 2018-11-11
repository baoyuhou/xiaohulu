using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using XiaoHuLuMvcCore.Models.Authority;
using XiaoHuLuMvcCore.Models.Authoritys;
using Newtonsoft.Json;
using XiaoHuLuMvcCore.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace XiaoHuLuMvcCore.Controllers
{
    public class UsersController : Controller
    {
        /// <summary>
        /// 显示用户和角色信息
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var result = WebApiHelper.GetApiResult("Get", "User", "GetUserList");

            var roleResult = WebApiHelper.GetApiResult("Get", "Role", "GetRoleList");
            ViewBag.roleResult =JsonConvert.DeserializeObject<List<Role>>(roleResult) ;
            return View(JsonConvert.DeserializeObject<List<UsersInfo>>(result));
        }

        /// <summary>
        /// 单条添加用户和角色信息
        /// </summary>
        /// <param name="usersInfo"></param>
        /// <returns></returns>
        public string UserAdd(UsersInfo usersInfo)
        {
            var result = WebApiHelper.GetApiResult("Post", "User", "UsersAdd",usersInfo);
            return result;
        }

        /// <summary>
        /// 后台首页
        /// </summary>
        /// <returns></returns>
        public IActionResult Login()
        {

            var result = WebApiHelper.GetApiResult("get", "Permissions", "GetJurisdictions");
            ViewBag.PerssionList = JsonConvert.DeserializeObject<List<Jurisdictions>>(result);          
            return View();
        }

    }
}