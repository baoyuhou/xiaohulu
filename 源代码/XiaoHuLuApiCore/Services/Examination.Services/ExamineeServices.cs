using System;
using System.Collections.Generic;
using System.Text;

using IServices.Examination.IServices;
using Models;
using Models.Examination;
using SqlSugar;

namespace Services.Examination.Services
{
    public class ExamineeServices : IExamineeServices
    {
        //实例化
        public SimpleClient<Candidate> CandidateDB = new SimpleClient<Candidate>(Educationcontext.GetClient());
        public SimpleClient<TestTime> TestTimeDB = new SimpleClient<TestTime>(Educationcontext.GetClient());
        /// <summary>
        /// 单条数据添加考生
        /// </summary>
        /// <param name="candidate"></param>
        /// <returns></returns>
        public int ADD(Candidate candidate)
        {
            var result = Convert.ToInt32(CandidateDB.Insert(candidate));
            return result;
        }

        /// <summary>
        /// 多条数据添加考生
        /// </summary>
        /// <param name="candidates"></param>
        /// <returns></returns>
        public int ADDList(List<Candidate> candidates)
        {
            var result = Convert.ToInt16(CandidateDB.InsertRange(candidates.ToArray()));
            return result;
        }

        /// <summary>
        /// 等待考生考完试,添加考试所用的时间
        /// </summary>
        /// <param name="testTime"></param>
        /// <returns></returns>
        public int ADDTime(TestTime testTime)
        {
            var result = Convert.ToInt32(TestTimeDB.Insert(testTime));
            return result;
        }

        /// <summary>
        /// 显示考生信息
        /// </summary>
        /// <returns></returns>
        public List<Candidate> GetCandidates()
        {
            using (SqlSugarClient db = Educationcontext.GetClient())
            {
                var CandList = db.Queryable<Candidate>().ToList();
                return CandList as List<Candidate>;
            }
        }

        /// <summary>
        /// 根据准考证号显示考生信息
        /// </summary>
        /// <param name="examNumber"></param>
        /// <returns></returns>
        public Candidate GetCandidatesByExamNumber(string examNumber)
        {
            var result = CandidateDB.GetSingle(m => m.ExamNumber == examNumber);
            return result;
        }
        
        /// <summary>
        /// 修改考生
        /// </summary>
        /// <param name="candidate"></param>
        /// <returns></returns>
        public int Update(Candidate candidate)
        {
            var result = Convert.ToInt32(CandidateDB.Update(candidate));
            return result;
        }

        /// <summary>
        /// 根据返填需要修改的考生
        /// </summary>
        /// <param name="candidate"></param>
        /// <returns></returns>
        public Candidate UpdateById(int candidateId)
        {
            var result = CandidateDB.GetSingle(m => m.ID == candidateId);
            return result;
        }
    }
}
