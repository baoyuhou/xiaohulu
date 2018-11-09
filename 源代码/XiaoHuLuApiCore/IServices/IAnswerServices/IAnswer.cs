﻿using System;
using System.Collections.Generic;
using System.Text;

using Models.Examination;

namespace IServices.IAnswerServices
{
    public interface IAnswer
    {
        /// <summary>
        /// 显示题型
        /// </summary>
        /// <returns></returns>
        List<AnswerModel> GetAnswerModelList(int Id, int totalCount = 0);
    }
}
