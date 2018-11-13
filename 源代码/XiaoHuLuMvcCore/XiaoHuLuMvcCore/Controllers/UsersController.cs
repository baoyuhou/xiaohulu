using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using XiaoHuLuMvcCore.Models.Authority;
using Newtonsoft.Json;
using XiaoHuLuMvcCore.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using XiaoHuLuMvcCore.Models.Authoritys;
using Microsoft.AspNetCore.Authorization;

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
        [Authorize]
        public IActionResult Login()
        {
            //判断是否登陆
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                var result = WebApiHelper.GetApiResult("get", "Permissions", "GetJurisdictions");
                ViewBag.PerssionList = JsonConvert.DeserializeObject<List<Jurisdictions>>(result);
                //取出KEy值也就是名字
                ViewBag.Name = User.Claims.ToList().Where(m => m.Type == "key").First().Value;
            }
            return View();
        }

        /// <summary>
        /// 反填修改的信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Edit(int id)
        {
            var result = WebApiHelper.GetApiResult("get", "User", "GetInfoById?Id=" + id);
            var roleResult = WebApiHelper.GetApiResult("Get", "Role", "GetRoleList");
            ViewBag.roleResult = JsonConvert.DeserializeObject<List<Role>>(roleResult);
            return View(JsonConvert.DeserializeObject<UsersInfo>(result));
        }

        [HttpPost]
        public int Edit(UsersInfo usersInfo)
        {
            var result = WebApiHelper.GetApiResult("put", "User", "EditInfoById",usersInfo);
            return int.Parse(result);
        }
    }
}