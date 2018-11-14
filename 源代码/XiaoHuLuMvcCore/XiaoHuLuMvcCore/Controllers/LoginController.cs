using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Mvc;
using XiaoHuLuMvcCore.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using XiaoHuLuMvcCore.Models.Authority;
using Microsoft.AspNetCore.Authentication;
using AutherationTest;
using Newtonsoft.Json;
using XiaoHuLuMvcCore.Models.Examination;

namespace XiaoHuLuMvcCore.Controllers
{
    public class LoginController : Controller
    {
        /// <summary>
        /// 登陆页
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

       [HttpPost]
        public async Task<string> IndexAsync(string name,string pwd)
        {
           
            //查看学生表里有没有匹配的人
            var result = WebApiHelper.GetApiResult("get", "Examination", "GetCandidate/?examNumber=" + name);
            if (string.IsNullOrEmpty(result))
            {
                //如果为空表示不是考生，开始查询是不是后台人员
                var roleResult = WebApiHelper.GetApiResult("get", "Examination", "GetUsersByNameAndPwd?name="+name+"&pwd="+pwd);
                if (string.IsNullOrEmpty(roleResult))
                {
                   
                    //如果为空表示不是后台人员，确定输入密码错误
                    return "3";
                }
               var  usersInfo = JsonConvert.DeserializeObject<UsersInfo>(roleResult);
                ///存入Redis
                await SaveRedisAsync<UsersInfo>(usersInfo);
                return "2";
            }
           var candidate = JsonConvert.DeserializeObject<Candidateinherit>(result);
            ///存入Redis
            await SaveRedisAsync<Candidateinherit>(candidate);
            return  "1";
        }

        /// <summary>
        /// 身份认证后存入Reids
        /// </summary>
        /// <param name="usersInfo"></param>
        /// <returns></returns>
        public async Task SaveRedisAsync<T>(T  t)
        {
            try
            {
                UsersInfo usersInfo = JsonConvert.DeserializeObject<UsersInfo>(JsonConvert.SerializeObject(t)); 
                //构造ClaimsIdentity 对象
                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                //创建 Claim 类型,传入 ClaimsIdentity 中
                identity.AddClaim(new Claim("keyhou", usersInfo.UserName));

                //创建ClaimsPrincipal对象,传入ClaimsIdentity 对象,调用HttpContext.SignInAsync完成登录
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

                //存储redis
                RedisHelper.Set<UsersInfo>(usersInfo.UserName, usersInfo);
            }
            catch
            {
                Candidate candidate = JsonConvert.DeserializeObject<Candidate>(JsonConvert.SerializeObject(t));
                //构造ClaimsIdentity 对象
                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                //创建 Claim 类型,传入 ClaimsIdentity 中
                identity.AddClaim(new Claim("key", candidate.Name));

                //创建ClaimsPrincipal对象,传入ClaimsIdentity 对象,调用HttpContext.SignInAsync完成登录
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

                //存储redis
                RedisHelper.Set<Candidate>(candidate.Name, candidate);
            }
          

            //取Redis
            //var user2 = RedisHelper.Get<ApplicationUser>(lookupUser.UserName);
        }

        /// <summary>
        /// 退出登录
        /// </summary>
        public void OutLogin()
        {
            RedisHelper.Remove(User.Claims.ToList().Where(m => m.Type == "keyhou").First().Value);
            HttpContext.SignOutAsync();
            
        }
    }
}