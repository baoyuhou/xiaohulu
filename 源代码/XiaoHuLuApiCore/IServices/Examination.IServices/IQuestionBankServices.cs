using System;
using System.Collections.Generic;
using System.Text;

using Models.Examination;

namespace IServices.IExaminationServices
{
    public interface IQuestionBankServices
    {
        /// <summary>
        /// 单条添加题
        /// </summary>
        /// <param name="questionBank"></param>
        /// <returns></returns>
        int ADD(QuestionBankinherit questionBankinherit);

        /// <summary>
        /// 多条添加题
        /// </summary>
        /// <param name="questionBanks"></param>
        /// <returns></returns>
        int ADDList(List<QuestionBankinherit> questionBankinherits);

        /// <summary>
        /// 查询全部题库
        /// </summary>
        /// <returns></returns>
        List<QuestionBankinherit> GetQuestionBanks();

        /// <summary>
        /// 根据类型查找题库
        /// </summary>
        /// <param name="TypeOfExamId"></param>
        /// <returns></returns>
        List<QuestionBankinherit> GetQuestionBanksByTypeOfExam(int TypeOfExamId);

        /// <summary>
        /// 根据id返填题
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        QuestionBankinherit UpdateById(int id);

        /// <summary>
        /// 修改题库的题
        /// </summary>
        /// <param name="questionBank"></param>
        /// <returns></returns>
        int Update(QuestionBankinherit questionBank);
        
    }
}
