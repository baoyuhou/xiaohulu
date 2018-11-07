using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Examination
{
    public class Candidateinherit
    {
        /// <summary>
        /// 考生从表主键
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
        public string Phone { get; set; }

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

        /// <summary>
        /// 准考证号码
        /// </summary>
        public string ExamNumberId { get; set; }

        /// <summary>
        /// 考试总时长
        /// </summary>
        public double LongExam { get; set; }

        /// <summary>
        /// 所用时长
        /// </summary>
        public double TimeUsed { get; set; }

        /// <summary>
        /// 剩余时长
        /// </summary>
        public double RemainderLength { get; set; }

        /// <summary>
        /// 答题进度
        /// </summary>
        public string ProgressOfAnswer { get; set; }

        /// <summary>
        /// 试室名称
        /// </summary>
        public string TestRoomName { get; set; }

        /// <summary>
        /// 单位表名称
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// 考场名称
        /// </summary>
        public string ExamRoomName { get; set; }
    }
}
