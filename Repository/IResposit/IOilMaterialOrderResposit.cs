using PetroleumModel.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Repository.IResposit
{
    public interface IOilMaterialOrderResposit : IBasesResposity<OilMaterialOrder>
    {
        List<object> GetListyouliaoInfo(int pageIndex, int pageSize, Expression<Func<ProcessStepRecord, OilMaterialOrder, OilMaterialOrderDetail, Staff, bool>> wheres, ref int totalCount);
    }
}
