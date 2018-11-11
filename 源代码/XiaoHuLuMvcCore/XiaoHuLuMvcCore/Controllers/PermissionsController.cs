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
        /// 显示权限信息
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var result = WebApiHelper.GetApiResult("Get", "Permissions", "GetJurisdictions");
            return View(JsonConvert.DeserializeObject<List<Jurisdictions>>(result));
        }

        /// <summary>
        /// 单条添加角色和权限信息
        /// </summary>
        /// <param name="jurisdictions"></param>
        /// <returns></returns>
        public IActionResult JurisAdd()
        {
            return View();
        }

        [HttpPost]
        public int JurisAdd(Jurisdictions jurisdictions)
        {
            var result = WebApiHelper.GetApiResult("Post", "Permissions", "JurisAdd", jurisdictions);

            return int.Parse(result);
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