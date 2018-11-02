using System;
using System.Collections.Generic;
using System.Text;

using Models.Examination;

namespace IServices.IExaminationServices
{
    public interface IExamineeServices
    {
        /// <summary>
        /// 单条数据添加考生
        /// </summary>
        /// <param name="candidate"></param>
        /// <returns></returns>
        int ADD(Candidate candidate);

        /// <summary>
        /// 多条数据添加考生
        /// </summary>
        /// <param name="candidates"></param>
        /// <returns></returns>
        int ADDList(List<Candidate> candidates);

        /// <summary>
        /// 根据ID返填需要修改的考生
        /// </summary>
        /// <param name="candidate"></param>
        /// <returns></returns>
        int UpdateById(int candidateId);

        /// <summary>
        /// 修改考生
        /// </summary>
        /// <param name="candidate"></param>
        /// <returns></returns>
        int Update(Candidate candidate);

        /// <summary>
        /// 显示考生信息
        /// </summary>
        /// <returns></returns>
        List<Candidate> GetCandidates();

        /// <summary>
        /// 根据准考证号显示考生信息
        /// </summary>
        /// <param name="examNumber"></param>
        /// <returns></returns>
        List<Candidate> GetCandidatesByExamNumber(string examNumber);
    }
}
