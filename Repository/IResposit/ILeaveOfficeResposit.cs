using PetroleumModel.ExtendMode;
using PetroleumModel.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Repository.IResposit
{
    public interface ILeaveOfficeResposit : IBasesResposity<LeaveOffice>
    {
        #region 暂时没用
        List<object> GetLeaveAll(int pageIndex, int pageSize, int jobId, ref int totalCount);
        #endregion

        List<object> GetruzhiInfo(int pageIndex, int pageSize, Expression<Func<ProcessStepRecord, Entrys, bool>> wheres, ref int totalCount);
        List<object> GetlizhiInfo(int pageIndex, int pageSize, Expression<Func<ProcessStepRecord, LeaveOffice, Staff, bool>> wheres, ref int totalCount);
    }
}
