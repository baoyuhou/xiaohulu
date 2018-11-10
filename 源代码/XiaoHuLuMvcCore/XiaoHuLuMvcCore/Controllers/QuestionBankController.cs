using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Models.QuestionBank;
using XiaoHuLuMvcCore.Models;
using Newtonsoft.Json;
using XiaoHuLuMvcCore.Models.Examination;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Hosting;

namespace XiaoHuLuMvcCore.Controllers
{
    public class QuestionBankController : Controller
    {
        /// <summary>
        /// 题库管理
        /// </summary>
        /// <returns></returns>
        public IActionResult QuestionsManagement()
        {
            return View();
        }

        /// <summary>
        /// 显示题库
        /// </summary>
        /// <returns></returns>
        public string GetQuestionBank()
        {
            var questionBankList = WebApiHelper.GetApiResult("Get", "QuestionBank", "GetQuestionBanks");
            return questionBankList;
        }

        private readonly IHostingEnvironment _hostingEnvironment;

        public QuestionBankController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="questionBank"></param>
        /// <returns></returns>
        public void ADDQuestionBank(QuestionBankinherit questionBankinherit)
        {
            long size = 0;
            var files = Request.Form.Files;
            foreach (var file in files)
            {
                //var fileName = file.FileName;
                var fileName = ContentDispositionHeaderValue
                                .Parse(file.ContentDisposition)
                                .FileName
                                .Trim('"');
                fileName = _hostingEnvironment.WebRootPath + $@"\{fileName}";
                size += file.Length;
                using (FileStream fs = System.IO.File.Create(fileName))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }
                questionBankinherit.Photo = fileName;
                var result = WebApiHelper.GetApiResult("post", "QuestionBank", "ADD", questionBankinherit);
            }
        }
        
        /// <summary>
        /// 绑定题类型下拉框
        /// </summary>
        /// <returns></returns>
        public string GetTextType()
        {
            var result = WebApiHelper.GetApiResult("get", "QuestionBank", "GetTextType");
            return result;
        }

        /// <summary>
        /// 显示题型所显示题量
        /// </summary>
        /// <returns></returns>
        public IActionResult GetTextTypeNum()
        {
            var result = WebApiHelper.GetApiResult("get", "QuestionBank", "TextTypeNums");
            return View(result);
        }

        /// <summary>
        /// 显示题型所显示题量
        /// </summary>
        /// <returns></returns>
        public void UpdateTextType()
        {
            var result = WebApiHelper.GetApiResult("get", "QuestionBank", "UpdateTextTypeNum");
            if (result != null)
            {
                Response.WriteAsync("<script>alert('修改成功!')</script>");
            }
        }
    }
}