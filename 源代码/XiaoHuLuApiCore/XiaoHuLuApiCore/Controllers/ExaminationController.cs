using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Models;
using Models.Examination;
using IServices.Examination.IServices;
namespace XiaoHuLuApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExaminationController : ControllerBase
    {
        private readonly IExamineeServices _examineeServices;
        public ExaminationController(IExamineeServices examineeServices)
        {
            _examineeServices = examineeServices;
        }   
        
        /// <summary>
        /// 获取全部考生信息
        /// 获取考生信息
        /// </summary>
        /// <returns></returns>
        [Route("GetCandidateList")]
        [HttpGet]
        public List<Candidate> GetCandidateList()
        {
            var CandidateList = _examineeServices.GetCandidates();
            return CandidateList;
        }

        /// <summary>
        /// 根据准考证号码进行查询
        /// </summary>
        /// <param name="examNumber">准考证号码</param>
        /// <returns></returns>
        [Route("GetCandidate")]
        [HttpGet]
        public Candidateinherit GetCandidate(string examNumber)
        {
            var candidate = _examineeServices.GetCandidatesByExamNumber(examNumber);
            return candidate;
        }

        
    }
}