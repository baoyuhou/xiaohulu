﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Models.QuestionBank;
using XiaoHuLuMvcCore.Models;
using Newtonsoft.Json;
using XiaoHuLuMvcCore.Models.Examination;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Hosting;
using OfficeOpenXml;

namespace XiaoHuLuMvcCore.Controllers
{
    public class QuestionBankController : Controller
    {
        /// <summary>
        /// 题库管理
        /// </summary>
        /// <returns></returns>
        public IActionResult QuestionsManagement()
        {
            return View();
        }

        /// <summary>
        /// 显示题库
        /// </summary>
        /// <returns></returns>
        public string GetQuestionBank()
        {
            var questionBankList = WebApiHelper.GetApiResult("Get", "QuestionBank", "GetQuestionBanks");
            return questionBankList;
        }

        /// <summary>
        /// 上传接口
        /// </summary>
        private readonly IHostingEnvironment _hostingEnvironment;

        /// <summary>
        /// 控制反转
        /// </summary>
        /// <param name="hostingEnvironment"></param>
        public QuestionBankController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="questionBank"></param>
        /// <returns></returns>
        public IActionResult ADDQuestionBank(QuestionBankinherit questionBankinherit)
        {
            #region 上传
            long size = 0;
            var files = Request.Form.Files;
            foreach (var file in files)
            {
                var fileName = ContentDispositionHeaderValue
                                .Parse(file.ContentDisposition)
                                .FileName
                                .Trim('"');
                fileName = _hostingEnvironment.WebRootPath + $@"\{fileName}";
                size += file.Length;
                using (FileStream fs = System.IO.File.Create(fileName))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }
                questionBankinherit.Photo = fileName;
            }
            #endregion
            var result = WebApiHelper.GetApiResult("post", "QuestionBank", "ADD", questionBankinherit);
            BadRequest("添加成功!");
            return Redirect("/QuestionBank/QuestionsManagement");
        }

        /// <summary>
        /// 批量添加题库
        /// </summary>
        /// <param name="file"></param>
        public IActionResult ADDQuestionBankList(IFormFile formFile)
        {
            #region 导入
            string sWebRootFolder = _hostingEnvironment.WebRootPath;
            string sFileName = $"{Guid.NewGuid()}.xlsx";
            FileInfo file = new FileInfo(Path.Combine(sWebRootFolder, sFileName));
            try
            {
                using (FileStream fs = new FileStream(file.ToString(), FileMode.Create))
                {
                    formFile.CopyTo(fs);
                    fs.Flush();
                }
                using (ExcelPackage package = new ExcelPackage(file))
                {
                    var questionBankinherits = new List<QuestionBankinherit>();
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
                    int rowCount = worksheet.Dimension.Rows;
                    int ColCount = worksheet.Dimension.Columns;
                    for (int row = 1 + 1; row <= rowCount; row++)
                    {
                        QuestionBankinherit questionBankinherit = new QuestionBankinherit();
                        questionBankinherit.Subject = worksheet.Cells[row, 1].Value.ToString();
                        questionBankinherit.TypeOfExam = Convert.ToInt32(worksheet.Cells[row, 2].Value);
                        questionBankinherit.AnswerA = worksheet.Cells[row, 3].Value.ToString();
                        questionBankinherit.AnswerB = worksheet.Cells[row, 4].Value.ToString();
                        var AnswerC = worksheet.Cells[row, 5].Value;
                        if (AnswerC == null)
                            AnswerC = "";
                        questionBankinherit.AnswerC = AnswerC.ToString();
                        var AnswerD = worksheet.Cells[row, 6].Value;
                        if (AnswerD == null)
                            AnswerD = "";
                        questionBankinherit.AnswerD = AnswerD.ToString();
                        var AnswerE = worksheet.Cells[row, 7].Value;
                        if (AnswerE == null)
                            AnswerE = "";
                        questionBankinherit.AnswerE = AnswerE.ToString();
                        questionBankinherit.Answer = worksheet.Cells[row, 8].Value.ToString();
                        questionBankinherit.Enable = Convert.ToInt32(worksheet.Cells[row, 9].Value.ToString());
                        questionBankinherits.Add(questionBankinherit);
                    }
                    var result = WebApiHelper.GetApiResult("post", "QuestionBank", "ADDList", questionBankinherits);
                    return Redirect("/QuestionBank/QuestionsManagement");
                }
            }
            catch (Exception ex)
            {
                return Redirect("/QuestionBank/QuestionsManagement");
            }
            #endregion
        }

        /// <summary>
        /// 绑定题类型下拉框
        /// </summary>
        /// <returns></returns>
        public string GetTextType()
        {
            var result = WebApiHelper.GetApiResult("get", "QuestionBank", "GetTextType");
            return result;
        }

        /// <summary>
        /// 显示题型所显示题量
        /// </summary>
        /// <returns></returns>
        public IActionResult GetTextTypeNum()
        {
            var result = WebApiHelper.GetApiResult("get", "QuestionBank", "TextTypeNums");
            ViewBag.num = JsonConvert.DeserializeObject<List<TextTypeNuminherit>>(result);
            return View();
        }

        /// <summary>
        /// 修改题量
        /// </summary>
        /// <returns></returns>
        public IActionResult UpdateTextTypeNum(int num, int id, int TextTypeId)
        {
            TextTypeNum textType = new TextTypeNum { };
            textType.Id = id;
            textType.Num = num;
            textType.TextTypeId = TextTypeId;
            var result = WebApiHelper.GetApiResult("put", "QuestionBank", "UpdateTextTypeNum", textType);
            if (result != null)
            {
                Response.WriteAsync("<script>alert('修改成功!')</script>");
            }
            return Redirect("/QuestionBank/GetTextTypeNum");
        }

        /// <summary>
        /// 修改题页面
        /// </summary>
        /// <param name="id"></param>
        public IActionResult UpdateQuestionBank(int id)
        {
            var result = WebApiHelper.GetApiResult("get", "QuestionBank", "UpdateById?id="+id);
            return View(JsonConvert.DeserializeObject<QuestionBankinherit>(result));
        }

        /// <summary>
        /// 修改题
        /// </summary>
        /// <param name="id"></param>
        public IActionResult UpdateQuestionBankData(QuestionBankinherit questionBankinherit)
        {
            #region 上传
            long size = 0;
            var files = Request.Form.Files;
            foreach (var file in files)
            {
                //var fileName = file.FileName;
                var fileName = ContentDispositionHeaderValue
                                .Parse(file.ContentDisposition)
                                .FileName
                                .Trim('"');
                fileName = _hostingEnvironment.WebRootPath + $@"\{fileName}";
                size += file.Length;
                using (FileStream fs = System.IO.File.Create(fileName))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }
                questionBankinherit.Photo = fileName;
            }
            #endregion
            var result = WebApiHelper.GetApiResult("put", "QuestionBank", "Update", questionBankinherit);
            return Redirect("/QuestionBank/QuestionsManagement");
        }
    }
}