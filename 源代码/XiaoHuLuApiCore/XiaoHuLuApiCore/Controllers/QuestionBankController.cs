﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IServices.IExaminationServices;
using Microsoft.AspNetCore.Mvc;

using Models.Examination;

namespace XiaoHuLuApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionBankController : ControllerBase
    {
        private readonly IQuestionBankServices _questionBankServices;
        public QuestionBankController(IQuestionBankServices questionBankServices)
        {
            _questionBankServices = questionBankServices;   
        }
        
        /// <summary>
        /// 单挑 添加题
        /// </summary>
        /// <returns></returns>
        [Route("ADD")]
        [HttpPost]
        public int ADD(QuestionBankinherit questionBankinherit)
        {
            var result = _questionBankServices.ADD(questionBankinherit);
            return result;
        }

        /// <summary>
        /// 批量添加题
        /// </summary>
        /// <param name="questionBankinherits"></param>
        /// <returns></returns>
        [Route("ADDList")]
        [HttpPost]
        public int ADDList(List<QuestionBankinherit> questionBankinherits)
        {
            var result = _questionBankServices.ADDList(questionBankinherits);
            return result;
        }

        /// <summary>
        /// 查询全部题库
        /// </summary>
        /// <returns></returns>
        [Route("GetQuestionBanks")]
        [HttpGet]
        public List<QuestionBankinherit> GetQuestionBanks()
        {
            var result = _questionBankServices.GetQuestionBanks();
            return result;
        }

        /// <summary>
        /// 根据题类型查找题
        /// </summary>
        /// <param name="typeOfExamId"></param>
        /// <returns></returns>
        [Route("GetQuestionBankinheritByTypeOfExam")]
        [HttpPost]
        public List<QuestionBankinherit> GetQuestionBankinheritByTypeOfExam(int typeOfExamId)
        {
            var result = _questionBankServices.GetQuestionBanksByTypeOfExam(typeOfExamId);
            return result;
        }

        /// <summary>
        /// 修改题库
        /// </summary>
        /// <param name="questionBankinherit"></param>
        /// <returns></returns>
        [Route("Update")]
        [HttpPost]
        public int Update(QuestionBankinherit questionBankinherit)
        {
            var result = _questionBankServices.Update(questionBankinherit);
            return result;
        }

        /// <summary>
        /// 根据Id返填题
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("UpdateById")]
        [HttpPost]
        public QuestionBankinherit UpdateById(int id)
        {
            var result = _questionBankServices.UpdateById(id);
            return result;
        }
    }
}