using System;
using System.Collections.Generic;
using System.Text;

using Models;
using Models.Authority;
namespace IServices.Authority.IServices
{
    /// <summary>
    /// 权限接口层
    /// </summary>
    public interface IPermissionsServices
    {
        /// <summary>
        /// 获取权限信息
        /// </summary>
        /// <returns></returns>
        List<Jurisdiction> GetJurisdictions();

        int Add(Jurisdiction jurisdiction);
    }
}
