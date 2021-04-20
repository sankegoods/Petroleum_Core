using PetroleumModel.Model;
using PetroleumService.IService;
using Repository.IResposit;
using ServiceExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace PetroleumService.Service
{
    public class LeaveOfficeService : BasesService<LeaveOffice>, ILeaveOfficeService
    {
        private readonly ILeaveOfficeResposit _leaveOfficeResposit;
        private readonly IProcessItemResposit _processItemResposit;
        private readonly IJobresposit _jobresposit;
        private readonly IProcessStepRecordResposit _processStepRecordResposit;
        private readonly IStaffResposit _staffResposit;
        private readonly IEntrysResposit _entrysResposit;
        #region 仓储
        public LeaveOfficeService(
            ILeaveOfficeResposit leaveOfficeResposit,
            IProcessItemResposit processItemResposit,
            IJobresposit jobresposit,
            IProcessStepRecordResposit processStepRecordResposit,
            IStaffResposit staffResposit,
            IEntrysResposit entrysResposit
            )
        {
            _leaveOfficeResposit = leaveOfficeResposit ?? throw new ArgumentNullException(nameof(leaveOfficeResposit));
            _processItemResposit = processItemResposit ?? throw new ArgumentNullException(nameof(processItemResposit));
            _jobresposit = jobresposit ?? throw new ArgumentNullException(nameof(jobresposit));
            _processStepRecordResposit = processStepRecordResposit ?? throw new ArgumentNullException(nameof(processStepRecordResposit));
            _staffResposit = staffResposit ?? throw new ArgumentNullException(nameof(staffResposit));
            _entrysResposit = entrysResposit ?? throw new ArgumentNullException(nameof(entrysResposit));
        }
        #endregion

        #region 暂时未用的部分代码(忘了那儿用的！！！)
        /// <summary>
        /// 获取请假数据
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<object> GetLeaveOffices(int pageIndex, int pageSize, int jobId, ref int totalCount)
        {
            return _leaveOfficeResposit.GetLeaveAll(pageIndex, pageSize, jobId, ref totalCount);
        }
        /// <summary>
        /// 修改请假数据
        /// </summary>
        /// <param name="leaveOffice"></param>
        /// <returns></returns>
        public bool UpdateLeaveOffices(LeaveOffice leaveOffice, ref string log)
        {
            try
            {
                int number = 0;
                _leaveOfficeResposit.StatrAffair(() =>
                {
                    number += _leaveOfficeResposit.UpdateInfo(x => new LeaveOffice
                    {
                        Reason = leaveOffice.Reason,
                        UpdateTime = DateTime.Now
                    }, x => x.Id == leaveOffice.Id);

                });
                log = "成功";
                return number >= 0;
            }
            catch (Exception ex)
            {
                log = ex.ToString();
                throw;
            }
        }
        /// <summary>
        /// 增添数据
        /// </summary>
        /// <param name="leaveOffice"></param>
        /// <returns></returns>
        public bool AddLeaveOffices(LeaveOffice leaveOffice)
        {
            int Record = 0;
            _leaveOfficeResposit.StatrAffair(() =>
            {
                leaveOffice.IsDel = "0";
                int leaveId = _leaveOfficeResposit.AddCreateInfo(leaveOffice);
                ProcessStepRecord processStepRecord = new ProcessStepRecord();
                processStepRecord.Typed = ProcessType.员工离职审批流程.ToString();
                processStepRecord.RecordRemarks = leaveOffice.Reason;
                processStepRecord.CreateTime = DateTime.Now;
                processStepRecord.WhetherToExecute = 1;
                processStepRecord.NoN = leaveId.ToString();
                processStepRecord.Result = 1;

                if (leaveOffice.JobId == (int)JobEmun.油站员工)
                {
                    processStepRecord.OilStation = 1;
                }
                else if (leaveOffice.JobId == (int)JobEmun.油站经理 || leaveOffice.JobId == (int)JobEmun.人事员工 || leaveOffice.JobId == (int)JobEmun.主管 || leaveOffice.JobId == (int)JobEmun.财务经理)
                {
                    processStepRecord.ExecutiveDirector = 1;
                }
                else if (leaveOffice.JobId == (int)JobEmun.人事经理)
                {
                    processStepRecord.GeneralManager = 1;
                }
                else if (leaveOffice.JobId == (int)JobEmun.总经理)
                {
                    processStepRecord.ChiefInspector = 1;
                }

                Record += _processStepRecordResposit.AddInfo(processStepRecord);
            });
            return Record > 0;
        }

        /// <summary>
        /// 删除离职记录
        /// </summary>
        /// <param name="leaveOffice"></param>
        /// <returns></returns>
        public bool DeleteLeaveOffices(LeaveOffice leaveOffice)
        {
            int isOk = 0;
            _leaveOfficeResposit.StatrAffair(() =>
            {
                isOk += _leaveOfficeResposit.UpdateInfo(x => new LeaveOffice { IsDel = "1" }, x => x.Id == leaveOffice.Id);
                isOk += _processStepRecordResposit.UpdateInfo(x => new ProcessStepRecord { Result = 0 }, x => x.NoN == leaveOffice.NoN);
            });
            return isOk > 0;
        }
        #endregion


        #region 入职审批


        /// <summary>
        /// 获取入职审批数据
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="jobId"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<object> GetruzhiInfo(int pageIndex, int pageSize, int jobId, ref int totalCount)
        {
            //根据jobId分出当前登陆的用户能审批那些数据
            if ((int)JobEmun.油站经理 == jobId)
            {
                return _leaveOfficeResposit.GetruzhiInfo(pageIndex, pageSize, (p, en) => p.Typed == ProcessType.员工入职审批流程.ToString() && p.OilStation == 1 && p.ExecutiveDirector == null, ref totalCount);
            } else if ((int)JobEmun.人事经理 == jobId)
            {
                return _leaveOfficeResposit.GetruzhiInfo(pageIndex, pageSize, (p, en) => p.Typed == ProcessType.员工入职审批流程.ToString() && p.OilStation == null && p.ExecutiveDirector == 1 && (p.GeneralManagerOfPerson == 1 || p.GeneralManagerOfPerson == null), ref totalCount);

            } else if ((int)JobEmun.主管 == jobId)
            {
                return _leaveOfficeResposit.GetruzhiInfo(pageIndex, pageSize, (p, en) => p.Typed == ProcessType.员工入职审批流程.ToString() && p.ExecutiveDirector == 0 && p.GeneralManagerOfPerson == 1 && p.GeneralManager == null, ref totalCount);
            } else if ((int)JobEmun.总经理 == jobId)
            {
                return _leaveOfficeResposit.GetruzhiInfo(pageIndex, pageSize, (p, en) => p.Typed == ProcessType.员工入职审批流程.ToString() && p.GeneralManagerOfPerson == null && p.GeneralManager == 1 && p.ChiefInspector == 1, ref totalCount);
            }
            else if ((int)JobEmun.总监 == jobId)
            {
                return _leaveOfficeResposit.GetruzhiInfo(pageIndex, pageSize, (p, en) => p.Typed == ProcessType.员工入职审批流程.ToString() && (p.GeneralManager == 0 || p.GeneralManager == null) && p.ChiefInspector == 1, ref totalCount);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 确定审批意见
        /// </summary>
        /// <returns></returns>
        public string UpdateRuzhiInfo(int JobId, string Remack, int ProceId, string staffName)
        {
            //开启事务
            _processStepRecordResposit.StatrAffair(() =>
            {
                //查询得出当前审批的数据
                ProcessStepRecord processStepRecord = _processStepRecordResposit.FindAll().FirstOrDefault(x => x.Id == ProceId);
                processStepRecord.Result = 1;//表示审核中

                //判断审批人的职位
                if ((int)JobEmun.油站经理 == JobId)
                {
                    processStepRecord.OilStation = 0;
                    processStepRecord.OilStationRemark = staffName + Remack;
                    //判断当前这个审批的数据是否为最后一个人审批
                    if (processStepRecord.ExecutiveDirector == null && Remack == "同意")
                    {
                        AddStaffInfo(processStepRecord.RefOrderId);
                        processStepRecord.Result = 2;//表示审核完毕  并且通过审核
                    }

                }
                else if ((int)JobEmun.人事经理 == JobId)
                {
                    processStepRecord.ExecutiveDirector = 0;
                    processStepRecord.ExecutiveDirectorRemark = staffName + Remack;

                    if (processStepRecord.OilStation == null && processStepRecord.GeneralManagerOfPerson == null && Remack == "同意")
                    {
                        //人事员工的最后一个审批人
                        AddStaffInfo(processStepRecord.RefOrderId);
                        processStepRecord.Result = 2;//表示审核完毕  并且通过审核
                    }
                }
                else if ((int)JobEmun.主管 == JobId)
                {
                    processStepRecord.GeneralManagerOfPerson = 0;
                    processStepRecord.GeneralManagerOfPersonRemark = staffName + Remack;

                    if (processStepRecord.ExecutiveDirector == 0 && processStepRecord.GeneralManager == null && Remack == "同意")
                    {
                        //油站经理  和 财务经理 的最后一个审批人
                        AddStaffInfo(processStepRecord.RefOrderId);
                        processStepRecord.Result = 2;//表示审核完毕  并且通过审核
                    }

                }
                else if ((int)JobEmun.总经理 == JobId)
                {
                    processStepRecord.GeneralManager = 0;
                    processStepRecord.GeneralManagerRemark = staffName + Remack;
                }
                else if ((int)JobEmun.总监 == JobId)
                {
                    processStepRecord.ChiefInspector = 0;
                    processStepRecord.ChiefInspectorRemark = staffName + Remack;

                    if (processStepRecord.GeneralManager == 0 && Remack == "同意")
                    {
                        // 人事经理 和 主管的最后一个审批人
                        AddStaffInfo(processStepRecord.RefOrderId);
                        processStepRecord.Result = 2;//表示审核完毕  并且通过审核
                    }
                }

                _processStepRecordResposit.UpdateInfo((x) => new ProcessStepRecord
                {
                    OilStation = processStepRecord.OilStation,
                    OilStationRemark = processStepRecord.OilStationRemark,
                    ExecutiveDirector = processStepRecord.ExecutiveDirector,
                    ExecutiveDirectorRemark = processStepRecord.ExecutiveDirectorRemark,
                    GeneralManagerOfPerson = processStepRecord.GeneralManagerOfPerson,
                    GeneralManagerOfPersonRemark = processStepRecord.GeneralManagerOfPersonRemark,
                    GeneralManager = processStepRecord.GeneralManager,
                    GeneralManagerRemark = processStepRecord.GeneralManagerRemark,
                    ChiefInspector = processStepRecord.ChiefInspector,
                    ChiefInspectorRemark = processStepRecord.ChiefInspectorRemark,
                    Result = processStepRecord.Result
                }, x => x.Id == processStepRecord.Id);
            });
            return "ok";
        }

        /// <summary>
        /// 生成一张员工在职表(如果改员工被同意入职)
        /// </summary>
        /// <param name="RefOrderId"></param>
        public void AddStaffInfo(int RefOrderId)
        {
            //根据记录表中关联的入职信息id 查询到申请人信息
            Entrys entrys = _entrysResposit.FindAll().FirstOrDefault(x => x.Id == RefOrderId);

            //生成一张员工在职表(如果改员工被同意入职)

            #region 生成工号 (后期性能差)
            bool isoks = true;
            string non = "";
            while (isoks)
            {
                non = "CH" + GetTime.GetTimeStamp() + GetTime.GetRandom();
                Staff staffNon = _staffResposit.FindAll().FirstOrDefault(x => x.NoN == non);

                if (staffNon == null)
                {
                    isoks = false;
                }
            }
            #endregion

            #region 审批同意后需要生成正式员工表的信息
            Staff staffIn = null;
            staffIn = new Staff()
            {
                JobId = entrys.JobId,
                BirthDay = entrys.BirthDay,
                Name = entrys.StaffName,
                NoN = non,
                CreateTime = DateTime.Now,
                RoleId = entrys.JobId,
                Passwords = "123456", // 初始密码
                Sex = entrys.Sex == 1 ? "男" : "女",
                Tel = entrys.Tel,
                Email = entrys.Email,
                Statusd = "入职",
                IsHSEGroup = "是",
                IsLaunch = 0,
                OrgID = 1,
                Addressd = entrys.Addressd,
                NativePlace = "待定",
            };
            //添加
            _staffResposit.AddInfo(staffIn);
            #endregion
        }

        #endregion

        #region 离职审批
        /// <summary>
        /// 获取离职数据
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="jobId"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<object> GetlizhiInfo(int pageIndex, int pageSize, int jobId, ref int totalCount)
        {
            if ((int)JobEmun.油站经理 == jobId)
            {
                return _leaveOfficeResposit.GetlizhiInfo(pageIndex, pageSize, (p, le, st) =>
                            p.Typed == ProcessType.员工离职审批流程.ToString() &&
                            p.OilStation == 1 && p.ExecutiveDirector == null
                        , ref totalCount);
            }
            else if ((int)JobEmun.人事经理 == jobId)
            {
                return _leaveOfficeResposit.GetlizhiInfo(pageIndex, pageSize, (p, le, st) =>
                            p.Typed == ProcessType.员工离职审批流程.ToString() &&
                            p.OilStation == null && p.ExecutiveDirector == 1 &&
                            (p.GeneralManagerOfPerson == 1 || p.GeneralManagerOfPerson == null)
                        , ref totalCount);

            }
            else if ((int)JobEmun.主管 == jobId)
            {
                return _leaveOfficeResposit.GetlizhiInfo(pageIndex, pageSize, (p, le, st) =>
                            p.Typed == ProcessType.员工离职审批流程.ToString() &&
                            p.ExecutiveDirector == 0 && p.GeneralManagerOfPerson == 1 &&
                            p.GeneralManager == null
                        , ref totalCount);
            }
            else if ((int)JobEmun.总经理 == jobId)
            {
                return _leaveOfficeResposit.GetlizhiInfo(pageIndex, pageSize, (p, le, st) =>
                            p.Typed == ProcessType.员工离职审批流程.ToString() &&
                            p.GeneralManagerOfPerson == null &&
                            p.GeneralManager == 1 &&
                            p.ChiefInspector == 1
                        , ref totalCount);
            }
            else if ((int)JobEmun.总监 == jobId)
            {
                return _leaveOfficeResposit.GetlizhiInfo(pageIndex, pageSize, (p, le, st) =>
                            p.Typed == ProcessType.员工离职审批流程.ToString() &&
                           (p.GeneralManager == 0 || p.GeneralManager == null) &&
                            p.ChiefInspector == 1
                        , ref totalCount);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 确定审批意见
        /// </summary>
        /// <returns></returns>
        public string UpdateLizhiInfo(int JobId, string Remack, int ProceId, string staffName) 
        {
            //开启事务
            _leaveOfficeResposit.StatrAffair(() =>
            {
                //查询出当前审批数据记录
                ProcessStepRecord processStepRecord = _processStepRecordResposit.FindAll().FirstOrDefault(x => x.Id == ProceId);
                processStepRecord.Result = 1;  //正在审核

                if ((int)JobEmun.油站经理 == JobId)
                {
                    processStepRecord.OilStation = 0;
                    processStepRecord.OilStationRemark = staffName + Remack;
                    if(processStepRecord.ExecutiveDirector == null && Remack == "同意")
                    {
                        UpdataStaffInfoaBylizi(processStepRecord.RefOrderId);
                        processStepRecord.Result = 2;//表示审核完毕  并且通过审核
                    }

                }
                else if ((int)JobEmun.人事经理 == JobId)
                {
                    processStepRecord.ExecutiveDirector = 0;
                    processStepRecord.ExecutiveDirectorRemark = staffName + Remack;
                    if (processStepRecord.OilStation == null && processStepRecord.GeneralManagerOfPerson == null && Remack == "同意")
                    {
                        UpdataStaffInfoaBylizi(processStepRecord.RefOrderId);
                        processStepRecord.Result = 2;//表示审核完毕  并且通过审核
                    }
                }
                else if ((int)JobEmun.主管 == JobId)
                {
                    processStepRecord.GeneralManagerOfPerson = 0;
                    processStepRecord.GeneralManagerOfPersonRemark = staffName + Remack;
                    if(processStepRecord.ExecutiveDirector == 0 && Remack == "同意")
                    {
                        UpdataStaffInfoaBylizi(processStepRecord.RefOrderId);
                        processStepRecord.Result = 2;//表示审核完毕  并且通过审核
                    }
                }
                else if ((int)JobEmun.总经理 == JobId)
                {
                    processStepRecord.GeneralManager = 0;
                    processStepRecord.GeneralManagerRemark = staffName + Remack;
                }
                else if ((int)JobEmun.总监 == JobId)
                {
                    processStepRecord.ChiefInspector = 0;
                    processStepRecord.ChiefInspectorRemark = staffName + Remack;

                    if (processStepRecord.GeneralManager == 0 && Remack == "同意")
                    {
                        UpdataStaffInfoaBylizi(processStepRecord.RefOrderId);
                        processStepRecord.Result = 2;//表示审核完毕  并且通过审核
                    }
                }
                _processStepRecordResposit.UpdateInfo((x) => new ProcessStepRecord
                {
                    OilStation = processStepRecord.OilStation,
                    OilStationRemark = processStepRecord.OilStationRemark,
                    ExecutiveDirector = processStepRecord.ExecutiveDirector,
                    ExecutiveDirectorRemark = processStepRecord.ExecutiveDirectorRemark,
                    GeneralManagerOfPerson = processStepRecord.GeneralManagerOfPerson,
                    GeneralManagerOfPersonRemark = processStepRecord.GeneralManagerOfPersonRemark,
                    GeneralManager = processStepRecord.GeneralManager,
                    GeneralManagerRemark = processStepRecord.GeneralManagerRemark,
                    ChiefInspector = processStepRecord.ChiefInspector,
                    ChiefInspectorRemark = processStepRecord.ChiefInspectorRemark,
                    Result = processStepRecord.Result
                }, x => x.Id == processStepRecord.Id);
            });
            return "ok";
        }

        public void UpdataStaffInfoaBylizi(int RefOrderId)
        {
            LeaveOffice leaveOffice = _leaveOfficeResposit.FindAll().FirstOrDefault(x => x.Id == RefOrderId);
            Staff staff = _staffResposit.FindAll().FirstOrDefault(x => x.NoN == leaveOffice.NoN);
            staff.Statusd = "离职";
            staff.UpdateTime = DateTime.Now;

            _staffResposit.UpdateInfo((x) => new Staff
            {
                Statusd = staff.Statusd,
                UpdateTime = staff.UpdateTime,
            }, x => x.Id == staff.Id);
        }
        #endregion
    }
}
