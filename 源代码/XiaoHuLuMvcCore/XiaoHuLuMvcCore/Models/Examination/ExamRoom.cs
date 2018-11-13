using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XiaoHuLuMvcCore.Models.Examination
{
    public class ExamRoom
    {
        /// <summary>
        /// 考场主键
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 考场名称
        /// </summary>
        public string Name { get; set; }
    }
}
