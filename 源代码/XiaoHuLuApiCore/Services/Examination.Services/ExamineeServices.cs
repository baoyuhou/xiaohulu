﻿using System;
using System.Collections.Generic;
using System.Text;

using IServices.Examination.IServices;
using Models;
using Models.Authority;
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
        public List<Candidateinherit> GetCandidates()
        {
            using (SqlSugarClient db = Educationcontext.GetClient())
            {
                var CandList = db.SqlQueryable<Candidateinherit>("select a.*,c.`Name` as CompanyName,t.`Name` as TestRoomName,e.`Name` as ExamRoomName from  candidate a join company c on a.CompanyID=c.ID join testroom t on a.TestRoomID=t.ID join examroom e on a.ExamRoomID=e.ID join testtime s on a.ExamNumber=s.ExamNumberId");
                return CandList.ToList();
            }
        }

        /// <summary>
        /// 根据准考证号显示考生信息
        /// </summary>
        /// <param name="examNumber"></param>
        /// <returns></returns>
        public Candidateinherit GetCandidatesByExamNumber(string examNumber)
        {
            SqlSugarClient sugarClient = Educationcontext.GetClient();
            //var  candidate  = sugarClient.Queryable<Candidate>().First(s=>s.ExamNumber==examNumber);
           var   candidate = sugarClient.SqlQueryable<Candidateinherit>(" select * from ( select a.*,c.`Name` as CompanyName,b.`Name` as  TestRoomName, d.`Name` as ExamRoomName from candidate a,testroom b, examroom c ,company d where a.TestRoomID=b.Id and a.CompanyID=d.Id and a.ExamRoomID=c.Id) info where ExamNumber =" + examNumber);
            return candidate.Single();
        }

        /// <summary>
        /// 获取后台登陆人的信息
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public Users GetUsersByNameAndPwd(string name, string pwd)
        {
            using (SqlSugarClient  sqlsc =Educationcontext.GetClient())
            {
              var user=  sqlsc.Queryable<Users>().First(s=>(s.UserName==name)&&(s.Password==pwd));
                return user;
            }
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
        public Candidateinherit UpdateById(int candidateId)
        {
            SqlSugarClient sugarClient = Educationcontext.GetClient();
            Candidateinherit candidateinherit = sugarClient.Queryable<Candidate, TestRoom, ExamRoom, Company, TestTime>((CD, TR, ER, CP, TT) => CD.CompanyID == CP.Id && CD.ExamRoomID == ER.Id && CD.TestRoomID == TR.ID && CD.ExamNumber == TT.ExamNumberId).Select((CD, TR, ER, CP, TT) => new Candidateinherit { Certificates = CD.Certificates, CompanyName = CP.Name, DocumentType = CD.DocumentType, Enable = CD.Enable, ExamNumber = CD.ExamNumber, ExamRoomName = ER.Name, Field = CD.Field, ID = CD.ID, LongExam = TT.LongExam, Name = CD.Name, Photo = CD.Photo, ProgressOfAnswer = TT.ProgressOfAnswer, RemainderLength = TT.RemainderLength, SeatNumber = CD.SeatNumber, Sex = CD.Sex, TestRoomName = TR.Name, TimeUsed = TT.TimeUsed }).Where(m => m.ID == candidateId).First();
            return candidateinherit;
        }
    }
}
