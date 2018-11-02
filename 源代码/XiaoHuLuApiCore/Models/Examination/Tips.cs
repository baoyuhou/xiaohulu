using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Examination
{
    public class Tips
    {
        /// <summary>
        /// 提示表主键
        /// </summary>
        public int ID { get; set; }
         
        /// <summary>
        /// 说明
        /// </summary>
        public string Explain { get; set; }

        /// <summary>
        /// 试卷描述
        /// </summary>
        public string PaperDescription { get; set; }

        /// <summary>
        /// 帮助
        /// </summary>
        public string Help { get; set; }
    }
}
