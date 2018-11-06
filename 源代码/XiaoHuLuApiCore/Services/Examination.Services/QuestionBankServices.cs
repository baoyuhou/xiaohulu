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
                    SqlSugarClient sugarClient = Educationcontext.GetClient();
                    questionBank = sugarClient.SqlQueryable<QuestionBank>("select id from QuestionBank order by id DESC limit 1").First();

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
        public List<QuestionBankinherit> GetQuestionBanks()
        {
            SqlSugarClient sugarClient = Educationcontext.GetClient();
            List<QuestionBankinherit> questionBankinherits = sugarClient.Queryable<QuestionBank, Option, TextType>((QB, Op, TT) => new object[] {
                QB.Id == Op.QuestionBankId,
                QB.TypeOfExam == TT.ID
            }).Select((QB, Op, TT) => new QuestionBankinherit { Answer = QB.Answer, AnswerA = Op.AnswerA, AnswerB = Op.AnswerB, AnswerC = Op.AnswerC, AnswerD = Op.AnswerD, AnswerE = Op.AnswerE, Subject = QB.Subject, Enable = QB.Enable, ExamType = TT.ExamType, Phone = QB.Phone }).ToPageList(1, 3);
            return questionBankinherits;
        }

        /// <summary>
        /// 根据类型查找题库
        /// </summary>
        /// <param name="TypeOfExamId"></param>
        /// <returns></returns>
        public List<QuestionBankinherit> GetQuestionBanksByTypeOfExam(int TypeOfExamId)
        {
            //var result = QuestionBankDB.GetList(m => m.TypeOfExam == TypeOfExamId);
            //return result;
            SqlSugarClient sugarClient = Educationcontext.GetClient();
            List<QuestionBankinherit> questionBankinherits = sugarClient.Queryable<QuestionBank, Option, TextType>((QB, Op,TT) => QB.Id == Op.QuestionBankId).Select((QB, Op,TT)=> new QuestionBankinherit { Answer = QB.Answer, AnswerA = Op.AnswerA, AnswerB = Op.AnswerB, AnswerC = Op.AnswerC, AnswerD = Op.AnswerD, AnswerE = Op.AnswerE, Subject = QB.Subject, Enable = QB.Enable, Phone = QB.Phone, ExamType = TT.ExamType }).Where(m => m.TypeOfExam == TypeOfExamId).ToPageList(1, 3);
            return questionBankinherits;
        }

        /// <summary>
        /// 修改题库的题
        /// </summary>
        /// <param name="questionBank"></param>
        /// <returns></returns>
        public int Update(QuestionBankinherit questionBankinherit)
        {
            //var result = Convert.ToInt32(QuestionBankDB.Update(questionBank));
            //return result;

            //修改题库
            QuestionBank questionBank = new QuestionBank();
            questionBank.Subject = questionBankinherit.Subject;
            questionBank.Answer = questionBankinherit.Answer;
            questionBank.Phone = questionBankinherit.Phone;
            questionBank.TypeOfExam = questionBankinherit.TypeOfExam;
            questionBank.Enable = questionBankinherit.Enable;
            questionBank.Id = questionBankinherit.Id;
            var questionBankId = questionBankinherit.Id;
            var resultquestionBank = QuestionBankDB.Update(questionBank);
            if (resultquestionBank)
            {
                //修改选项
                SqlSugarClient sugarClient = Educationcontext.GetClient();
                Option option = sugarClient.SqlQueryable<Option>("select * from Option where QuestionBankId == " + resultquestionBank).First();
                option.AnswerA = questionBankinherit.AnswerA;
                option.AnswerB = questionBankinherit.AnswerB;
                option.AnswerC = questionBankinherit.AnswerC;
                option.AnswerD = questionBankinherit.AnswerD;
                option.AnswerE = questionBankinherit.AnswerE;
                var resultoption = OptionDB.Update(option);
                if (resultoption)
                {
                    return 1;
                }
                return 0;
            }
            return 0;
        }

        /// <summary>
        /// 根据id返填题
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public QuestionBankinherit UpdateById(int id)
        {
            //var result = QuestionBankDB.GetSingle(m => m.Id == id);
            //return result;

            SqlSugarClient sugarClient = Educationcontext.GetClient();
            QuestionBankinherit questionBankinherit = sugarClient.Queryable<QuestionBank, Option, TextType>((QB, OP, TT) => QB.Id == OP.QuestionBankId && QB.TypeOfExam == TT.ID).Select((QB, OP, TT) => new QuestionBankinherit { Answer = QB.Answer, AnswerA = OP.AnswerA, AnswerB = OP.AnswerB, AnswerC = OP.AnswerC, AnswerD = OP.AnswerD, AnswerE = OP.AnswerE, Subject = QB.Subject, Enable = QB.Enable, Phone = QB.Phone, ExamType = TT.ExamType }).Where(m => m.Id == id).First();
            return questionBankinherit;
        }
    }
}
