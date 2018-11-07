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
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServicesl;
        public UserController(IUserServices userServices)
        {
            _userServicesl = userServices;
        }

        /// <summary>
        /// 获取用户角色信息
        /// </summary>
        /// <returns></returns>
        [Route("GetUserList")]
        [HttpGet]
        public List<UsersInfo> GetUserList()
        {
            var userList = _userServicesl.GetUsersList();
            return userList;
        }

    }
}