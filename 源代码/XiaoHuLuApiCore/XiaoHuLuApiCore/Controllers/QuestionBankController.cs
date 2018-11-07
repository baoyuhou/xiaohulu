using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace XiaoHuLuApiCore.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class QuestionBankController : ControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}