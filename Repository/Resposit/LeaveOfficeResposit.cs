using PetroleumModel.ExtendMode;
using PetroleumModel.Model;
using Repository.IResposit;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Repository.Resposit
{
    public class LeaveOfficeResposit : BasesResposity<LeaveOffice>, ILeaveOfficeResposit
    {
        #region 暂时没用
        public List<object> GetLeaveAll(int pageIndex, int pageSize, int jobId, ref int totalCount)
        {
            List<object> lists = new List<object>();
            var list = _db.Queryable<LeaveOffice, Staff>((le, st) => new object[] {
                        JoinType.Left,le.StaffName ==  st.Name})
                    .Where((le, st) => st.JobId == jobId)
                    .Select((le, st) => new { st = st, le = le })
                    .ToPageList(pageIndex, pageSize, ref totalCount);

            lists.Add(list);
            return lists;
        }
        #endregion


        /// <summary>
        /// 查询入职审批数据
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="wheres"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<object> GetruzhiInfo(int pageIndex, int pageSize, Expression<Func<ProcessStepRecord, Entrys, bool>> wheres, ref int totalCount)
        {
            List<object> lists = new List<object>();
            lists.Add(_db.Queryable<ProcessStepRecord, Entrys>((p,en)=>new object[]{
                JoinType.Left,p.RefOrderId == en.Id
            }).Where(wheres)
            .Select((p,en) => new{
                    Id = p.Id,
                    StaffId = en.Id,
                    RecordRemarks = p.RecordRemarks,
                    StaffName = en.StaffName,
                    Sex = en.Sex,
                    BirthDay = en.BirthDay,
                    Major = en.Major,
                    Tel = en.Tel,
                    jobId = en.JobId,
                    Email = en.Email,
                    IDNumber = en.IDNumber,
                    CreateTime = en.CreateTime,
                    ProbationarySalary = en.ProbationarySalary
                })
                .ToPageList(pageIndex, pageSize, ref totalCount));
            return lists;
        }
        /// <summary>
        /// 查询离职审批数据
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="wheres"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<object> GetlizhiInfo(int pageIndex, int pageSize, Expression<Func<ProcessStepRecord, LeaveOffice, Staff, bool>> wheres, ref int totalCount)
        {
            List<object> lists = new List<object>();
            lists.Add(_db.Queryable<ProcessStepRecord, LeaveOffice,Staff>((p, le,st) => new object[]{
                JoinType.Left,p.RefOrderId == le.Id,
                JoinType.Left,le.NoN == st.NoN
            }).Where(wheres)
            .Select((p, le,st) => new {
                Id = p.Id,
                RecordRemarks =le.Reason,
                LeId = le.Id,
                StaffName = le.StaffName,
                Sex = st.Sex,
                Tel = st.Tel,
                JobId = le.JobId,
                LeaveType = le.LeaveType == "1"? "正常提交离职表" : le.LeaveType == "2"? "自动离职" : "被辞退", //离职类型
                ApplyDate = le.ApplyDate,//申请时间
                Reason = le.Reason,//离职原因
                ExplanationHandover = le.ExplanationHandover,//工作交接说明
                HandoverSatffId = le.HandoverSatffId,//和谁交接的 交接人ID
                ApplyPersonId = le.ApplyPersonId,//申请离职的人 ID
                CreateTime = le.CreateTime,//数据创建时间
                st.Email,//邮箱
                StaffId = st.Id,
            })
                .ToPageList(pageIndex, pageSize, ref totalCount));
            return lists;
        }

    }
}
