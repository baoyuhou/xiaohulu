using System;
using System.Collections.Generic;
using System.Text;

using IServices.IAnswerServices;
using Models;
using Models.Examination;
using SqlSugar;

namespace Services.AnswerServices
{
    public class Answer : IAnswer
    {
        public List<AnswerModel> GetAnswerModelList(int Id,int totalCount=0)
        {
            using (SqlSugarClient db = Educationcontext.GetClient())
            {
                //var answermodellist = db.Ado.SqlQuery<AnswerModel>("select * from QuestionBank a INNER JOIN TextType b on a.TypeOfExam=b.ID INNER JOIN `Option` c on a.Id=c.QuestionBankId WHERE a.Id="+Id);
                //return answermodellist;
                //var answermodellist = db.Ado.UseStoredProcedure().GetDataTable("p_paging", new {
                //    @tableName = pageparams.TableName,
                //    @indexCol = pageparams.IndexCol,
                //    @pageSize= pageparams.PageSize,
                //    @pageIndex= pageparams.PageIndex,
                //    @orderCol= pageparams.OrderCol,
                //    @where= pageparams.StrWhere,
                //    @columns= pageparams.Columns
                //});
                
                var answermodels = db.Queryable<QuestionBank, TextType, Option>((questionbank, texttype, op) => new object[] {
            JoinType.Inner,questionbank.TypeOfExam==texttype.ID,
            JoinType.Inner,questionbank.Id==op.QuestionBankId
            })
            //    .Where((questionbank, texttype, op) => questionbank.Id == Id)
               .Select((questionbank, texttype, op) => new AnswerModel
               {
                   Id = questionbank.Id,
                   Subject = questionbank.Subject,
                   Answer = questionbank.Answer,
                   Photo = questionbank.Photo,
                   TypeOfExam = questionbank.TypeOfExam,
                   Enable = questionbank.Enable,
                   ExamType = texttype.ExamType,
                   AnswerA = op.AnswerA,
                   AnswerB = op.AnswerB,
                   AnswerC = op.AnswerC,
                   AnswerD = op.AnswerD,
                   AnswerE = op.AnswerE
               }).ToPageList(Id, 1, ref totalCount); ;
                return answermodels;
            }
        }

        public List<QuestionBank> QuestionNumber()
        {
            throw new NotImplementedException();
        }
    }
}
