using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using XiaoHuLuMvcCore.Models.Authoritys;
using Newtonsoft.Json;
using XiaoHuLuMvcCore.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace XiaoHuLuMvcCore.Controllers
{
    public class PermissionsController : Controller
    {
        /// <summary>
        /// 显示角色和权限信息
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var result = WebApiHelper.GetApiResult("Get", "Role", "GetRoleList");

            var jurisResult = WebApiHelper.GetApiResult("Get", "Permissions", "GetJurisdictions");
            ViewBag.jurisResult = JsonConvert.DeserializeObject<List<Jurisdictions>>(jurisResult);
            return View(JsonConvert.DeserializeObject<List<JurisdictionInfo>>(result));
        }

        /// <summary>
        /// 单条添加角色和权限信息
        /// </summary>
        /// <param name="jurisdictionInfo"></param>
        /// <returns></returns>
        public string RolesAdd(JurisdictionInfo jurisdictionInfo)
        {
            var result = WebApiHelper.GetApiResult("Post", "Role", "RoleAdd");
            return result;
        }

        public void GetRoleViewBag()
        {
            var jurisResult = WebApiHelper.GetApiResult("Get", "Permissions", "GetJurisdictions");
            List<Jurisdictions> list = JsonConvert.DeserializeObject<List<Jurisdictions>>(jurisResult);
            var linq = from s in list
                       select new SelectListItem
                       {
                           Text = s.Level.ToString(),
                           Value = s.Id.ToString()
                       };
            ViewBag.roleviewbag = linq.ToList();
        }
    }
}