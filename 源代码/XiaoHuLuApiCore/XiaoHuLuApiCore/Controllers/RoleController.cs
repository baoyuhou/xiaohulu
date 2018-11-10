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
    public class RoleController : ControllerBase
    {
        private readonly IRoleServices _roleServices;
        public RoleController(IRoleServices roleServices)
        {
            _roleServices = roleServices;
        }

        /// <summary>
        /// 获取角色信息
        /// </summary>
        /// <returns></returns>
        [Route("GetRoleList")]
        [HttpGet]
        public List<Role> GetRoleList()
        {
            var roleList = _roleServices.GetRoles();
            return roleList;
        }

        /// <summary>
        /// 获取角色和权限信息
        /// </summary>
        /// <returns></returns>
        [Route("GetRoleList")]
        [HttpGet]
        public List<JurisdictionInfo> GetJurisdictionInfos()
        {
            var roleList = _roleServices.GetJurisdictionInfos();
            return roleList;
        }

        /// <summary>
        /// 单条添加角色和权限
        /// </summary>
        /// <param name="jurisdictionInfo"></param>
        /// <returns></returns>
        [Route("RoleAdd")]
        [HttpPost]
        public int RoleAdd(JurisdictionInfo jurisdictionInfo)
        {
            var roleAdd = _roleServices.Add(jurisdictionInfo);
            return roleAdd;
        }
    }
}