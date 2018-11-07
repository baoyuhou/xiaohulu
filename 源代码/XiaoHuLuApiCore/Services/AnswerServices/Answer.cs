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
        public List<AnswerModel> GetAnswerModelList(int Id)
        {
            using (SqlSugarClient db = Educationcontext.GetClient())
            {
                var answermodellist = db.Ado.SqlQuery<AnswerModel>("select * from QuestionBank a INNER JOIN TextType b on a.TypeOfExam=b.ID INNER JOIN `Option` c on a.Id=c.QuestionBankId WHERE a.Id="+Id);
                return answermodellist;
            }
        }
    }
}
