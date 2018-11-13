using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XiaoHuLuMvcCore.Models.Examination
{
    public class Candidate
    {
        /// <summary>
        /// 考生表主键
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public bool Sex { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        public string Photo { get; set; }

        /// <summary>
        /// 准考证号
        /// </summary>
        public string ExamNumber { get; set; }

        /// <summary>
        /// 证件类型
        /// </summary>
        public string DocumentType { get; set; }

        /// <summary>
        /// 证件号
        /// </summary>
        public string Certificates { get; set; }

        /// <summary>
        /// 所在考场外键
        /// </summary>
        public int ExamRoomID { get; set; }

        /// <summary>
        /// 当前场次
        /// </summary>
        public int Field { get; set; }

        /// <summary>
        /// 座位号
        /// </summary>
        public int SeatNumber { get; set; }

        /// <summary>
        /// 所在试室外键
        /// </summary>
        public int TestRoomID { get; set; }

        /// <summary>
        /// 所在单位外键
        /// </summary>
        public int CompanyID { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public int Enable { get; set; }
    }
}
