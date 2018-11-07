using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Examination;

using IServices.IAnswerServices;

namespace XiaoHuLuApiCore.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        private readonly IAnswer answer;
        public AnswerController(IAnswer _answer)
        {
            answer = _answer;
        }
        /// <summary>
        /// 显示题
        /// </summary>
        /// <param name="Id">查询编号</param>
        /// <returns></returns>
        [HttpGet]
        public List<AnswerModel> GetAnswerModelList(int Id)
        {
            var answermodellist = answer.GetAnswerModelList(Id);
            return answermodellist;
        }
    }
}