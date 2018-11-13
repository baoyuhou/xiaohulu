using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using XiaoHuLuMvcCore.Models.Examination;
using Newtonsoft.Json;
using XiaoHuLuMvcCore.Models;
using System.Net.Http.Headers;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;

namespace XiaoHuLuMvcCore.Controllers
{
    public class ExaminationController : Controller
    {
        /// <summary>
        /// 显示全部考生信息
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var result = WebApiHelper.GetApiResult("Get", "Examination", "GetCandidateList");
            return View(JsonConvert.DeserializeObject<List<Candidateinherit>>(result));
        }

        /// <summary>
        /// 添加考生
        /// </summary>
        /// <returns></returns>
        public IActionResult ADDCandidateinherit()
        {
            var GetCompanies = WebApiHelper.GetApiResult("Get", "Examination", "GetCompanies");
            ViewBag.Company = JsonConvert.DeserializeObject<List<Company>>(GetCompanies); ;
            var GetTestRooms = WebApiHelper.GetApiResult("Get", "Examination", "GetTestRooms");
            ViewBag.TestRoom = JsonConvert.DeserializeObject<List<TestRoom>>(GetTestRooms);
            var GetExamRooms = WebApiHelper.GetApiResult("Get", "Examination", "GetExamRooms");
            ViewBag.ExamRoom = JsonConvert.DeserializeObject<List<ExamRoom>>(GetExamRooms); ;
            return View();
        }

        private readonly IHostingEnvironment _hostingEnvironment;

        public ExaminationController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        /// <summary>
        /// 添加考生
        /// </summary>
        /// <returns></returns>
        public int ADDCandidateinheritData(Candidate candidate)
        {
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
                candidate.Photo = fileName;
            }
            var GetExamRooms = WebApiHelper.GetApiResult("post", " Examination", "CandidateAdd", candidate);
            if (GetExamRooms!=null)
            {
                return 1;
            }
            return 0;
        }

        /// <summary>
        /// 批量添加题库
        /// </summary>
        /// <param name="file"></param>
        public void ADDQuestionBankList(IFormFile formFile)
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
                    var candidates = new List<Candidate>();
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
                    int rowCount = worksheet.Dimension.Rows;
                    int ColCount = worksheet.Dimension.Columns;
                    for (int row = 1 + 1; row <= rowCount; row++)
                    {
                        Candidate candidate = new Candidate();
                        candidate.Name = worksheet.Cells[row, 1].Value.ToString();
                        var sex = worksheet.Cells[row, 2].Value.ToString();
                        if (sex == "男")
                            candidate.Sex = true;
                        else
                            candidate.Sex = false;
                        var photo = worksheet.Cells[row, 3].Value;
                        if (photo == null)
                            candidate.Photo = "";
                        else
                            candidate.Photo = photo.ToString();
                        candidate.ExamNumber = worksheet.Cells[row, 4].Value.ToString();
                        candidate.DocumentType = worksheet.Cells[row, 5].Value.ToString();
                        candidate.Certificates = worksheet.Cells[row, 6].Value.ToString();
                        candidate.ExamRoomID = Convert.ToInt32(worksheet.Cells[row, 7].Value);
                        candidate.Field = Convert.ToInt32(worksheet.Cells[row, 8].Value.ToString());
                        candidate.SeatNumber = Convert.ToInt32(worksheet.Cells[row, 9].Value.ToString());
                        candidate.TestRoomID = Convert.ToInt32(worksheet.Cells[row, 10].Value.ToString());
                        candidate.CompanyID = Convert.ToInt32(worksheet.Cells[row, 11].Value.ToString());
                        candidate.Enable = Convert.ToInt32(worksheet.Cells[row, 12].Value.ToString());
                        candidates.Add(candidate);
                    }
                    var result = WebApiHelper.GetApiResult("post", "Examination", "ADDList", candidates);
                }
            }
            catch (Exception ex)
            {
                Content(ex.Message);
            }
            #endregion
        }

    }
}