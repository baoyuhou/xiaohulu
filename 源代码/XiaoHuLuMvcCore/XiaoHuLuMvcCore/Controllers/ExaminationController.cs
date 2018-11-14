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
            //单位
            var GetCompanies = WebApiHelper.GetApiResult("Get", "Examination", "GetCompanies");
            ViewBag.Company = JsonConvert.DeserializeObject<List<Company>>(GetCompanies); ;
            //试室
            var GetTestRooms = WebApiHelper.GetApiResult("Get", "Examination", "GetTestRooms");
            ViewBag.TestRoom = JsonConvert.DeserializeObject<List<TestRoom>>(GetTestRooms);
            //考试
            var GetExamRooms = WebApiHelper.GetApiResult("Get", "Examination", "GetExamRooms");
            ViewBag.ExamRoom = JsonConvert.DeserializeObject<List<ExamRoom>>(GetExamRooms);
            var result = WebApiHelper.GetApiResult("Get", "Examination", "GetCandidateList");
            return View(JsonConvert.DeserializeObject<List<Candidateinherit>>(result));
        }

        /// <summary>
        /// 添加考生
        /// </summary>
        /// <returns></returns>
        public IActionResult ADDCandidateinherit()
        {
            //单位
            var GetCompanies = WebApiHelper.GetApiResult("Get", "Examination", "GetCompanies");
            ViewBag.Company = JsonConvert.DeserializeObject<List<Company>>(GetCompanies); ;
            //试室
            var GetTestRooms = WebApiHelper.GetApiResult("Get", "Examination", "GetTestRooms");
            ViewBag.TestRoom = JsonConvert.DeserializeObject<List<TestRoom>>(GetTestRooms);
            //考试
            var GetExamRooms = WebApiHelper.GetApiResult("Get", "Examination", "GetExamRooms");
            ViewBag.ExamRoom = JsonConvert.DeserializeObject<List<ExamRoom>>(GetExamRooms);
            return View();
        }

        /// <summary>
        /// 上传接口属性
        /// </summary>
        private readonly IHostingEnvironment _hostingEnvironment;

        /// <summary>
        /// 控制反转
        /// </summary>
        /// <param name="hostingEnvironment"></param>
        public ExaminationController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        /// <summary>
        /// 添加考生
        /// </summary>
        /// <returns></returns>
        public IActionResult ADDCandidateinheritData(Candidate candidate)
        {
            #region 上传
            long size = 0;
            //获取form中的图片
            var files = Request.Form.Files;
            //循环获取
            foreach (var file in files)
            {
                //var fileName = file.FileName;
                //去掉图片的双引号并转换成ContentDispositionHeaderValue
                var fileName = ContentDispositionHeaderValue
                                .Parse(file.ContentDisposition)
                                .FileName
                                .Trim('"');
                fileName = _hostingEnvironment.WebRootPath + $@"\{fileName}";
                size += file.Length;
                //保存图片
                using (FileStream fs = System.IO.File.Create(fileName))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }
                candidate.Photo = fileName;
<<<<<<< HEAD
=======
            }
            #endregion
            var GetExamRooms = WebApiHelper.GetApiResult("post", " Examination", "CandidateAdd", candidate);
            return Redirect("/Examination/Index");
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
                    //循环Excel里面的数据
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
                    BadRequest("添加成功!");
                    Redirect("/Examination/Index");
                }
>>>>>>> b5ff0d4e984ea24aac822dcf64dcb55d5ddf4c19
            }
            catch (Exception ex)
            {
                Content(ex.Message);
            }
            #endregion
        }

    }
}