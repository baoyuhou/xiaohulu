using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Models;
using Models.Examination;
using IServices.Examination.IServices;
using Models.Authority;

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
        /// 单条数据添加考生信息
        /// </summary>
        /// <param name="candidateinherit"></param>
        /// <returns></returns>
        [Route("CandidateAdd")]
        [HttpPost]
        public int CandidateAdd(Candidateinherit candidateinherit)
        {
            var candidateAdd = _examineeServices.ADD(candidateinherit);
            return candidateAdd;
        }

        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="candidates"></param>
        /// <returns></returns>
        [Route("ADDList")]
        [HttpPost]
        public int ADDList(List<Candidate> candidates)
        {
            var result = _examineeServices.ADDList(candidates);
            return result;
        }

        /// <summary>
        /// 获取全部考生信息
        /// 获取考生信息
        /// </summary>
        /// <returns></returns>
        [Route("GetCandidateList")]
        [HttpGet]
        public List<Candidateinherit> GetCandidateList()
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
        public Candidate GetCandidate(string examNumber)
        {
            var candidate = _examineeServices.GetCandidatesByExamNumber(examNumber);
            return candidate;
        }
        
        /// <summary>
        /// 修改考生信息
        /// </summary>
        /// <param name="candidate"></param>
        /// <returns></returns>
        [Route("Update")]
        [HttpPut]
        public int Update(Candidate candidate)
        {
            var result = _examineeServices.Update(candidate);
            return result;
        }

        /// <summary>
        /// 根据id返填修改的题
        /// </summary>
        /// <param name="candidateId"></param>
        /// <returns></returns>
        [Route("CandidateAdd")]
        [HttpPost]
        public int CandidateAdd(Candidate candidate)
        {
            var candidateAdd = _examineeServices.ADD(candidate);
            return candidateAdd;
        }

        /// <summary>
        /// 根据id找出考生的信息
        /// </summary>
        /// <param name="candidateId"></param>
        /// <returns></returns>
        [Route("GetCandidateinheritById")]
        [HttpPut]
        public Candidateinherit GetCandidateinheritById(int candidateId)
        {
            var result = _examineeServices.UpdateById(candidateId);
            return result;
        }

        /// <summary>
        ///根据名称和密码找出后台人员的信息 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        [Route("GetUsersByNameAndPwd")]
        [HttpGet]
        public Users GetUsersByNameAndPwd(string name,string pwd)
        {
            return _examineeServices.GetUsersByNameAndPwd(name,pwd);
        }
    }
}