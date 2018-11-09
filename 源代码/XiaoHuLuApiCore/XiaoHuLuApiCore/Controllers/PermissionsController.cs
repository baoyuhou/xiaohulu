using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Models;
using Models.Authority;
using IServices.IAuthority;
namespace XiaoHuLuApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionsController : ControllerBase
    {
        private readonly IPermissionsServices _permissionsServices;
        public PermissionsController(IPermissionsServices permissionsServices)
        {
            _permissionsServices = permissionsServices;
        }

        /// <summary>
        /// 获取用户角色信息
        /// </summary>
        /// <returns></returns>
        [Route("GetJurisList")]
        [HttpGet]
        public List<JurisdictionInfo> GetJurisList()
        {
            var jurisList = _permissionsServices.GetPermissions();
            return jurisList;
        }

        /// <summary>
        /// 单条添加角色权限
        /// </summary>
        /// <param name="jurisdictionInfo"></param>
        /// <returns></returns>
        [Route("RandJAdd")]
        [HttpPost]
        public int RandJAdd(JurisdictionInfo jurisdictionInfo)
        {
            var result = _permissionsServices.JurisAdd(jurisdictionInfo);
            return result;
        }
    }
}