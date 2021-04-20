using PetroleumModel.Model;
using Repository.IResposit;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Repository.Resposit
{
    public class OilMaterialOrderResposit : BasesResposity<OilMaterialOrder>, IOilMaterialOrderResposit
    {
        public List<object> GetListyouliaoInfo(int pageIndex, int pageSize, Expression<Func<ProcessStepRecord, OilMaterialOrder, OilMaterialOrderDetail, Staff, bool>> wheres, ref int totalCount)
        {
            List<object> lists = new List<object>();
            lists.Add(_db.Queryable<ProcessStepRecord, OilMaterialOrder,OilMaterialOrderDetail,Staff>((p, oi,oid,st) => new object[]{
                JoinType.Left,p.RefOrderId == oi.Id,
                JoinType.Left,oid.OrderId == oi.Id,
                JoinType.Left,st.NoN == oi.StaffNoN
            }).Where(wheres)
            .Select((p, oi,oid,st) => new {
                Id = p.Id,
                OilmId = oi.Id,
                st.Name,
                st.NoN,
                oi.CreateTime,
                oid.NeedAmount,
                OilmdId = oid.Id,
                oid.OilSpec,
                oid.Volume,
                oid.Surplus,
                oid.DayAvg
            }).ToPageList(pageIndex, pageSize, ref totalCount));
            return lists;
        }
    }
}
