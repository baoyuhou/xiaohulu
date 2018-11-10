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

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="questionBank"></param>
        /// <returns></returns>
        public int ADDQuestionBank(QuestionBankinherit questionBankinherit)
        {
            //long size = files.Sum(f => f.Length);
            //var fileFolder = Path.Combine("Photo");
            //if (!Directory.Exists(fileFolder))
            //    Directory.CreateDirectory(fileFolder);
            //foreach (var formFile in files)
            //{
            //    if (formFile.Length > 0)
            //    {
            //        var fileName = DateTime.Now.ToString("yyyyMMddHHmmss") +
            //                       Path.GetExtension(formFile.FileName);
            //        var filePath = Path.Combine(fileFolder, fileName);

            //        using (var stream = new FileStream(filePath, FileMode.Create))
            //        {
            //            formFile.CopyToAsync(stream);
            //        }
            //    }
            //}

            var result = WebApiHelper.GetApiResult("post", "QuestionBank", "ADD", questionBankinherit);
            if (result!=null)
            {
                return 1;
            }
            return 0;
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

    }
}