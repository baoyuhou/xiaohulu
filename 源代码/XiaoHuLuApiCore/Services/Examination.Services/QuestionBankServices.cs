using System;
using System.Collections.Generic;
using System.Text;
using IServices.IExaminationServices;
using Models;
using Models.Examination;
using SqlSugar;

namespace Services.ExaminationServices
{
    public class QuestionBankServices : IQuestionBankServices
    {
        public SimpleClient<QuestionBank> QuestionBankDB = new SimpleClient<QuestionBank>(Educationcontext.GetClient());
        public SimpleClient<Option> OptionDB = new SimpleClient<Option>(Educationcontext.GetClient());

        /// <summary>
        /// 单条添加题
        /// </summary>
        /// <param name="questionBank"></param>
        /// <returns></returns>
        public int ADD(QuestionBankinherit questionBankinherit)
        {
            //添加到题库
            QuestionBank questionBank = new QuestionBank();
            questionBank.Subject = questionBankinherit.Subject;
            questionBank.Answer = questionBankinherit.Answer;
            questionBank.Phone = questionBankinherit.Phone;
            questionBank.TypeOfExam = questionBankinherit.TypeOfExam;
            questionBank.Enable = questionBankinherit.Enable;
            var resultquestionBank = QuestionBankDB.Insert(questionBank);
            if (resultquestionBank)
            {
                //获取最后一个Id
                using (SqlSugarClient sugarClient = Educationcontext.GetClient())
                {
                    questionBank = sugarClient.SqlQueryable<QuestionBank>("select id from QuestionBank order by id DESC limit 1").First();
                }
                var resultQuestionBankId = questionBank.Id;
                //添加到选项
                Option option = new Option();
                option.QuestionBankId = resultQuestionBankId;
                option.AnswerA = questionBankinherit.AnswerA;
                option.AnswerB = questionBankinherit.AnswerB;
                option.AnswerC = questionBankinherit.AnswerC;
                option.AnswerD = questionBankinherit.AnswerD;
                option.AnswerE = questionBankinherit.AnswerE;
                var resultoption = OptionDB.Insert(option);
                if (resultoption)
                {
                    return 1;
                }
                return 0;
            }
            return 0;
        }

        /// <summary>
        /// 多条添加题
        /// </summary>
        /// <param name="questionBanks"></param>
        /// <returns></returns>
        public int ADDList(List<QuestionBankinherit> questionBankinherits)
        {
            //var result = Convert.ToInt32(QuestionBankDB.InsertRange(questionBanks.ToArray()));
            //return result;
            foreach (var item in questionBankinherits)
            {
                //添加到题库
                QuestionBank questionBank = new QuestionBank();
                questionBank.Subject = item.Subject;
                questionBank.Answer = item.Answer;
                questionBank.Phone = item.Phone;
                questionBank.TypeOfExam = item.TypeOfExam;
                questionBank.Enable = item.Enable;
                var resultquestionBank = QuestionBankDB.Insert(questionBank);
                if (resultquestionBank)
                {
                    //获取最后一个Id
                    using (SqlSugarClient sugarClient = Educationcontext.GetClient())
                    {
                        questionBank = sugarClient.SqlQueryable<QuestionBank>("select id from QuestionBank order by id DESC limit 1").First();
                    }
                    var resultQuestionBankId = questionBank.Id;
                    //添加到选项
                    Option option = new Option();
                    option.QuestionBankId = resultQuestionBankId;
                    option.AnswerA = item.AnswerA;
                    option.AnswerB = item.AnswerB;
                    option.AnswerC = item.AnswerC;
                    option.AnswerD = item.AnswerD;
                    option.AnswerE = item.AnswerE;
                    var resultoption = OptionDB.Insert(option);
                    if (resultoption)
                    {
                        return 1;
                    }
                    return 0;
                }
                return 0;
            }
            return 0;
        }

        /// <summary>
        /// 查询全部题库
        /// </summary>
        /// <returns></returns>
        public List<QuestionBank> GetQuestionBanks()
        {
            var result = QuestionBankDB.GetList();
            return result;
        }

        /// <summary>
        /// 根据类型查找题库
        /// </summary>
        /// <param name="TypeOfExamId"></param>
        /// <returns></returns>
        public List<QuestionBank> GetQuestionBanksByTypeOfExam(int TypeOfExamId)
        {
            var result = QuestionBankDB.GetList(m => m.TypeOfExam == TypeOfExamId);
            return result;
        }

        /// <summary>
        /// 修改题库的题
        /// </summary>
        /// <param name="questionBank"></param>
        /// <returns></returns>
        public int Update(QuestionBank questionBank)
        {
            var result = Convert.ToInt32(QuestionBankDB.Update(questionBank));
            return result;
        }

        /// <summary>
        /// 根据id返填题
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public QuestionBank UpdateById(int id)
        {
            var result = QuestionBankDB.GetSingle(m => m.Id == id);
            return result;
        }
    }
}
