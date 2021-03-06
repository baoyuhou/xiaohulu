﻿using System;
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
        private readonly IUserServices _userServices;
        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        /// <summary>
        /// 获取用户角色信息
        /// </summary>
        /// <returns></returns>
        [Route("GetUserList")]
        [HttpGet]
        public List<UsersInfo> GetUserList()
        {
            var userList = _userServices.GetUsersList();
            return userList;
        }

        /// <summary>
        /// 单条添加用户和角色信息
        /// </summary>
        /// <param name="usersInfo"></param>
        /// <returns></returns>
        [Route("UsersAdd")]
        [HttpPost]
        public int UsersAdd(UsersInfo usersInfo)
        {
            var useradd = _userServices.Add(usersInfo);
            return useradd;
        }

        /// <summary>
        /// 反填信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("GetInfoById")]
        [HttpGet]
        public UsersInfo GetInfoById(int id)
        {
            return _userServices.GetUsersInfoById(id);
        }

        /// <summary>
        /// 编辑修改信息
        /// </summary>
        /// <param name="usersInfo"></param>
        /// <returns></returns>
        [Route("EditInfoById")]
        [HttpPut]
        public int EditInfoById(UsersInfo usersInfo)
        {
            return _userServices.EditById(usersInfo);
        }
    }
}