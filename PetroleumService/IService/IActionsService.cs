using PetroleumModel.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetroleumService.IService
{
    public interface IActionsService: IBaseService<Actions>
    {
        /// <summary>
        /// 导航菜单数据
        /// </summary>
        /// <returns></returns>
        object MenusInfoAll(int jobId);
        /// <summary>
        /// 用户登陆
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Passwords"></param>
        /// <returns></returns>
        object GetLogInfo(string Name, string Passwords);
    }
}
