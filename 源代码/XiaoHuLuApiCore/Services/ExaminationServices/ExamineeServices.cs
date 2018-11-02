using System;
using System.Collections.Generic;
using System.Text;

using IServices.IExaminationServices;
using Models;
using Models.Examination;
using SqlSugar;
namespace Services.ExaminationServices
{    public class ExamineeServices : IExamineeServices
    {
        public SimpleClient<Candidate> sdb = new SimpleClient<Candidate>(Educationcontext.GetClient());
        /// <summary>
        /// 单条数据添加考生
        /// </summary>
        /// <param name="candidate"></param>
        /// <returns></returns>
        public int ADD(Candidate candidate)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 多条数据添加考生
        /// </summary>
        /// <param name="candidates"></param>
        /// <returns></returns>
        public int ADDList(List<Candidate> candidates)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 显示考生信息
        /// </summary>
        /// <returns></returns>
        public List<Candidate> GetCandidates()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 根据准考证号显示考生信息
        /// </summary>
        /// <param name="examNumber"></param>
        /// <returns></returns>
        public List<Candidate> GetCandidatesByExamNumber(string examNumber)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 修改考生
        /// </summary>
        /// <param name="candidate"></param>
        /// <returns></returns>
        public int Update(Candidate candidate)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 根据ID返填需要修改的考生
        /// </summary>
        /// <param name="candidate"></param>
        /// <returns></returns>
        public int UpdateById(int candidateId)
        {
            throw new NotImplementedException();
        }
    }
}
