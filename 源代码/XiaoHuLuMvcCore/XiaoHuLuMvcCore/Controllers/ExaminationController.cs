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
            var GetExamRooms = WebApiHelper.GetApiResult("Get", "Examination", "CandidateAdd", candidate);
            if (GetExamRooms!=null)
            {
                return 1;
            }
            return 0;
        }

    }
}