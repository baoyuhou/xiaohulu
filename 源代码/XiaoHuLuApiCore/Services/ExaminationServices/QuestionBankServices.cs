using System;
using System.Collections.Generic;
using System.Text;

using IServices.IExaminationServices;
using Models.Examination;

namespace Services.ExaminationServices
{
    public class QuestionBankServices : IQuestionBankServices
    {
        /// <summary>
        /// 单条添加题
        /// </summary>
        /// <param name="questionBank"></param>
        /// <returns></returns>
        public int ADD(QuestionBank questionBank)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 多条添加题
        /// </summary>
        /// <param name="questionBanks"></param>
        /// <returns></returns>
        public int ADDList(List<QuestionBank> questionBanks)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 查询全部题库
        /// </summary>
        /// <returns></returns>
        public List<QuestionBank> GetQuestionBanks()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 根据类型查找题库
        /// </summary>
        /// <param name="TypeOfExamId"></param>
        /// <returns></returns>
        public List<QuestionBank> GetQuestionBanksByTypeOfExam(int TypeOfExamId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 修改题库的题
        /// </summary>
        /// <param name="questionBank"></param>
        /// <returns></returns>
        public int Update(QuestionBank questionBank)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 根据id返填题
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int UpdateById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
