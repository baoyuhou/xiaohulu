using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Models;
using Models.Authority;
using IServices.Authority.IServices;
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
        /// 获取权限信息
        /// </summary>
        /// <returns></returns>
        [Route("GetJurisdictions")]
        [HttpGet]
        public List<Jurisdiction> GetJurisdictions()
        {
            var jurisList = _permissionsServices.GetJurisdictions();
            return jurisList;
        }

        /// <summary>
        /// 添加权限信息
        /// </summary>
        /// <param name="jurisdiction"></param>
        /// <returns></returns>
        [Route("JurisAdd")]
        [HttpPost]
        public int JurisAdd(Jurisdiction jurisdiction)
        {
            return _permissionsServices.Add(jurisdiction);
        }
    }
}