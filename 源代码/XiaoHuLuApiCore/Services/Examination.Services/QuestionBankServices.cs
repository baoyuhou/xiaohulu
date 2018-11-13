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
            try
            {
                //添加到题库
                QuestionBank questionBank = new QuestionBank();
                questionBank.Subject = questionBankinherit.Subject;
                questionBank.Answer = questionBankinherit.Answer;
                questionBank.Photo = questionBankinherit.Photo;
                questionBank.TypeOfExam = questionBankinherit.TypeOfExam;
                questionBank.Enable = questionBankinherit.Enable;
                SqlSugarClient sugarClient = Educationcontext.GetClient();
                var resultquestionBank = QuestionBankDB.Insert(questionBank);
                //获取最后一个Id
                questionBank = sugarClient.SqlQueryable<QuestionBank>("select id from QuestionBank order by id DESC limit 1").First();
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
                return 1;
            }
            catch (Exception ex)
            {
                //return ex.Message;
                return 0;
            }
        }

        /// <summary>
        /// 多条添加题
        /// </summary>
        /// <param name="questionBanks"></param>
        /// <returns></returns>
        public int ADDList(List<QuestionBankinherit> questionBankinherits)
        {
            try
            {
                foreach (var item in questionBankinherits)
                {
                    //添加到题库
                    QuestionBank questionBank = new QuestionBank();
                    questionBank.Subject = item.Subject;
                    questionBank.Answer = item.Answer;
                    questionBank.Photo = item.Photo;
                    questionBank.TypeOfExam = item.TypeOfExam;
                    questionBank.Enable = item.Enable;
                    var resultquestionBank = QuestionBankDB.Insert(questionBank);
                    if (resultquestionBank)
                    {
                        //获取最后一个Id
                        SqlSugarClient sugarClient = Educationcontext.GetClient();
                        questionBank = sugarClient.SqlQueryable<QuestionBank>("select id from QuestionBank order by id DESC limit 1").First();
                        //添加到选项
                        Option option = new Option();
                        option.QuestionBankId = questionBank.Id;
                        option.AnswerA = item.AnswerA;
                        option.AnswerB = item.AnswerB;
                        option.AnswerC = item.AnswerC;
                        option.AnswerD = item.AnswerD;
                        option.AnswerE = item.AnswerE;
                        OptionDB.Insert(option);
                    }
                }
                return 1;
            }
            catch (Exception ex)
            {
                //return Content(ex.Message);
                return 0;
            }
        }

        /// <summary>
        /// 查询全部题库
        /// </summary>
        /// <returns></returns>
        public List<QuestionBankinherit> GetQuestionBanks()
        {
            SqlSugarClient sugarClient = Educationcontext.GetClient();
            List<QuestionBankinherit> questionBankinherits = sugarClient.Queryable<QuestionBank, Option, TextType>((QB, Op, TT) => new object[] {
                JoinType.Inner,QB.Id == Op.QuestionBankId,
                JoinType.Inner,QB.TypeOfExam == TT.ID})
                .Select((QB, Op, TT) => new QuestionBankinherit { Answer = QB.Answer, AnswerA = Op.AnswerA, AnswerB = Op.AnswerB, AnswerC = Op.AnswerC, AnswerD = Op.AnswerD, AnswerE = Op.AnswerE, Subject = QB.Subject, Enable = QB.Enable, ExamType = TT.ExamType, Photo = QB.Photo, Id = QB.Id }).ToList();
            return questionBankinherits;
        }

        /// <summary>
        /// 根据类型查找题库
        /// </summary>
        /// <param name="TypeOfExamId"></param>
        /// <returns></returns>
        public List<QuestionBankinherit> GetQuestionBanksByTypeOfExam(int TypeOfExamId)
        {
            SqlSugarClient sugarClient = Educationcontext.GetClient();
            List<QuestionBankinherit> questionBankinherits = sugarClient.Queryable<QuestionBank, Option, TextType>((QB, Op, TT) => QB.Id == Op.QuestionBankId && QB.Id == Op.QuestionBankId).Where((QB, Op, TT) => QB.TypeOfExam == TypeOfExamId).Select((QB, Op, TT) => new QuestionBankinherit { Answer = QB.Answer, AnswerA = Op.AnswerA, AnswerB = Op.AnswerB, AnswerC = Op.AnswerC, AnswerD = Op.AnswerD, AnswerE = Op.AnswerE, Subject = QB.Subject, Enable = QB.Enable, Photo = QB.Photo, ExamType = TT.ExamType }).ToList();
            return questionBankinherits;
        }

        /// <summary>
        /// 修改题库的题
        /// </summary>
        /// <param name="questionBank"></param>
        /// <returns></returns>
        public int Update(QuestionBankinherit questionBankinherit)
        {
            SqlSugarClient sugarClient = Educationcontext.GetClient();
            //修改题库
            QuestionBank questionBank = new QuestionBank();
            questionBank.Subject = questionBankinherit.Subject;
            questionBank.Answer = questionBankinherit.Answer;
            questionBank.Photo = questionBankinherit.Photo;
            questionBank.TypeOfExam = questionBankinherit.TypeOfExam;
            questionBank.Enable = questionBankinherit.Enable;
            questionBank.Id = questionBankinherit.Id;
            var questionBankId = questionBankinherit.Id;
            var resultquestionBank = sugarClient.Updateable<QuestionBank>(questionBank).ExecuteCommand();
            if (resultquestionBank != 0)
            {
                //修改选项
                Option option = sugarClient.SqlQueryable<Option>("select * from `Option` where QuestionBankId = " + questionBankinherit.Id).First();
                option.AnswerA = questionBankinherit.AnswerA;
                option.AnswerB = questionBankinherit.AnswerB;
                option.AnswerC = questionBankinherit.AnswerC;
                option.AnswerD = questionBankinherit.AnswerD;
                option.AnswerE = questionBankinherit.AnswerE;
                var resultoption = sugarClient.Updateable<Option>(option).ExecuteCommand();
                if (resultoption != 0)
                    return 1;
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
            SqlSugarClient sugarClient = Educationcontext.GetClient();
            QuestionBankinherit questionBankinherit = sugarClient.SqlQueryable<QuestionBankinherit>("select q.*,o.AnswerA,o.AnswerB,o.AnswerC,o.AnswerD,o.AnswerE,t.ExamType from QuestionBank q join `Option` o on q.Id = o.QuestionBankId join TextType t on q.TypeOfExam = t.ID where q.Id = " + id).First();
            return questionBankinherit;
        }

        /// <summary>
        /// 显示全部题型
        /// </summary>
        public List<TextType> GetTextType()
        {
            SqlSugarClient sugarClient = Educationcontext.GetClient();
            List<TextType> textTypes = sugarClient.SqlQueryable<TextType>("select * from TextType where Enable = 1").ToList();
            return textTypes;
        }

        /// <summary>
        /// 显示题类型显示题数
        /// </summary>
        /// <returns></returns>
        public List<TextTypeNuminherit> TextTypeNums()
        {
            using (SqlSugarClient sugarClient = Educationcontext.GetClient())
            {
                List<TextTypeNuminherit> textTypeNums = sugarClient.SqlQueryable<TextTypeNuminherit>("select t.*,p.ExamType from TextTypeNum t join texttype p on t.TextTypeId = p.id").ToList();
                return textTypeNums;
            }
        }

        /// <summary>
        /// 修改题量
        /// </summary>
        /// <returns></returns>
        public int UpdateTextTypeNum(TextTypeNum textTypeNum)
        {
            using (SqlSugarClient sugarClient = Educationcontext.GetClient())
            {
                var result = sugarClient.Updateable<TextTypeNum>(textTypeNum).ExecuteCommand();
                if (result == 1)
                {
                    return 1;
                }
                return 0;
            }
        }
    }
}
