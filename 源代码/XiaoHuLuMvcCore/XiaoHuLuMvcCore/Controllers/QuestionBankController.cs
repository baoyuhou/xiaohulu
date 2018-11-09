using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Models.QuestionBank;
using XiaoHuLuMvcCore.Models;
using Newtonsoft.Json;
using XiaoHuLuMvcCore.Models.Examination;

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
        public int ADDQuestionBank(QuestionBank questionBank)
        {
            var result = WebApiHelper.GetApiResult("post", "QuestionBank", "ADD", questionBank);
            if (result!=null)
            {
                return 1;
            }
            return 0;
        }

    }
}