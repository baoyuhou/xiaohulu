using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XiaoHuLuMvcCore.Models.Authoritys
{
    public class Jurisdictions
    {
        /// <summary>
        /// 主键id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 权限名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 权限级别
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// 父级权限
        /// </summary>
        public int Father { get; set; }
        /// <summary>
        /// 子级权限
        /// </summary>
        public int Child { get; set; }
    }
}
