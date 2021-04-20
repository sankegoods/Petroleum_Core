using PetroleumModel.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetroleumService.IService
{
    public interface ILeaveOfficeService : IBaseService<LeaveOffice>
    {
        #region 暂时未用的部分代码(忘了那儿用的！！！)
        List<object> GetLeaveOffices(int pageIndex, int pageSize, int jobId, ref int totalCount);
        bool UpdateLeaveOffices(LeaveOffice leaveOffice, ref string log);
        bool AddLeaveOffices(LeaveOffice leaveOffice);
        bool DeleteLeaveOffices(LeaveOffice leaveOffice);
        #endregion


        List<object> GetruzhiInfo(int pageIndex, int pageSize, int jobId, ref int totalCount);
        string UpdateRuzhiInfo(int JobId, string Remack, int ProceId, string staffName);
        List<object> GetlizhiInfo(int pageIndex, int pageSize, int jobId, ref int totalCount);
        string UpdateLizhiInfo(int JobId, string Remack, int ProceId, string staffName);
    }
}
