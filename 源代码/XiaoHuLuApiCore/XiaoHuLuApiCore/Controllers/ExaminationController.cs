﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Models;
using Models.Examination;
using IServices.Examination.IServices;
using Models.Authority;
using Newtonsoft.Json;

namespace XiaoHuLuApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExaminationController : ControllerBase
    {
        /// <summary>
        /// 实例化接口
        /// </summary>
        private readonly IExamineeServices _examineeServices;

        /// <summary>
        /// 控制反转
        /// </summary>
        /// <param name="examineeServices"></param>
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
        public int CandidateAdd(Candidate candidate)
        {
            var candidateAdd = _examineeServices.ADD(candidate);
            return candidateAdd;
        }

        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="candidates"></param>
        /// <returns></returns>
        [Route("ADDList")]
        [HttpPost]
        public int ADDList(object obj)
        {
            var result = _examineeServices.ADDList(JsonConvert.DeserializeObject<List<Candidate>>(obj.ToString()));
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
        public Candidateinherit GetCandidate(string examNumber)
        {
            var  candidate = _examineeServices.GetCandidatesByExamNumber(examNumber);
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
        /// 根据id返填修改的考生
        /// </summary>
        /// <param name="candidateId"></param>
        /// <returns></returns>
        [Route("CandidateAdd")]
        [HttpPost]
        public int UpdateCandidate(Candidate candidate)
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
        public Users GetUsersByNameAndPwd(string name, string pwd)
        {
            return _examineeServices.GetUsersByNameAndPwd(name, pwd);
        }

        /// <summary>
        /// 获取单位
        /// </summary>
        /// <returns></returns>
        [Route("GetCompanies")]
        [HttpGet]
        public List<Company> GetCompanies()
        {
            return _examineeServices.GetCompanies();
        }

        /// <summary>
        /// 获取试室
        /// </summary>
        /// <returns></returns>
        [Route("GetTestRooms")]
        [HttpGet]
        public List<TestRoom> GetTestRooms()
        {
            return _examineeServices.GetTestRooms();
        }

        /// <summary>
        /// 获取单位
        /// </summary>
        /// <returns></returns>
        [Route("GetExamRooms")]
        [HttpGet]
        public List<ExamRoom> GetExamRooms()
        {
            return _examineeServices.GetExamRooms();
        }
    }
}