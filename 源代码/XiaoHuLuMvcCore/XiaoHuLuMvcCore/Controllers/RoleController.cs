using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using XiaoHuLuMvcCore.Models.Authority;
using XiaoHuLuMvcCore.Models.Authoritys;
using Newtonsoft.Json;
using XiaoHuLuMvcCore.Models;
namespace XiaoHuLuMvcCore.Controllers
{
    public class RoleController : Controller
    {
        /// <summary>
        /// 显示角色和权限信息
        /// </summary>
        /// <returns></returns>
        public IActionResult RoleIndex()
        {
            var result = WebApiHelper.GetApiResult("Get", "Role", "GetJurisdictionInfos");

            var jurisresult=WebApiHelper.GetApiResult("Get", "Permissions", "GetJurisdictions");
            ViewBag.jurisresult = JsonConvert.DeserializeObject<List<Jurisdictions>>(jurisresult);
            return View(JsonConvert.DeserializeObject<List<JurisdictionInfo>>(result));
        }

        /// <summary>
        /// 单条添加角色和权限信息
        /// </summary>
        /// <param name="jurisdictionInfo"></param>
        /// <returns></returns>
        public string RolesAdd(JurisdictionInfo jurisdictionInfo)
        {
            var result = WebApiHelper.GetApiResult("Post", "Role", "RoleAdd",jurisdictionInfo);
            return result;
        }
    }
} 