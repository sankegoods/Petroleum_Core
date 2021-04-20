using PetroleumModel.Model;
using PetroleumService.IService;
using Repository.IResposit;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SqlSugar;
using ServiceExt;

namespace PetroleumService.Service
{
    public class StaffService : BasesService<Staff>, IStaffService
    {
        #region 数据注入 仓库
        private readonly IStaffResposit _staffResposit;
        private readonly IJobresposit _jobresposit;
        private readonly IRoleResposit _roleResposit;
        private readonly IEntrysResposit _entrysResposit;
        private readonly IProcessStepRecordResposit _processStepRecordResposit;
        private readonly ILeaveOfficeResposit _leaveOfficeResposit;

        public StaffService(IStaffResposit staffResposit,
                            IJobresposit jobresposit,
                            IRoleResposit roleResposit,
                            IEntrysResposit entrysResposit,
                            IProcessStepRecordResposit processStepRecordResposit,
                            ILeaveOfficeResposit leaveOfficeResposit)
        {
            _staffResposit = staffResposit ?? throw new ArgumentNullException(nameof(staffResposit));
            _jobresposit = jobresposit ?? throw new ArgumentNullException(nameof(jobresposit));
            _roleResposit = roleResposit ?? throw new ArgumentNullException(nameof(roleResposit));
            _entrysResposit = entrysResposit ?? throw new ArgumentNullException(nameof(entrysResposit));
            _processStepRecordResposit = processStepRecordResposit ?? throw new ArgumentNullException(nameof(processStepRecordResposit));
            _leaveOfficeResposit = leaveOfficeResposit ?? throw new ArgumentNullException(nameof(leaveOfficeResposit));
        }
        #endregion

        #region 在职员工 （Staff）
        /// <summary>
        /// 添加在职员工信息 （在完成员工申请 经 审批通过后）
        /// </summary>
        /// <param name="staff"></param>
        /// <returns></returns>
        public bool addStarffInfo(Staff staff)
        {
            staff.CreateTime = DateTime.Now;
            staff.IsLaunch = 0;
            staff.IsHSEGroup = "是";
            staff.OrgID = 1;
            staff.Statusd = "待入职";
            staff.NoN = staff.Name;
            staff.Passwords = GetTime.randomPwd();
            return _staffResposit.AddCreateInfo(staff) > 0;
        }

        /// <summary>
        /// 修改在职员工信息
        /// </summary>
        /// <param name="staff"></param>
        /// <returns></returns>
        public bool updateStarff(Staff staff)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 查询在职员工信息
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public List<object> GetStarffInfo(int pageIndex, int pageSize, ref int total)
        {
            return _staffResposit.GetStarffInfo(pageIndex, pageSize, ref total);
        }

        /// <summary>
        /// 查询在职员工信息
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public List<object> GetStarffInfo()
        {
            List<object> list = new List<object>();
            list.Add(_staffResposit.FindAll().Select(x => x.Name).ToList());
            return list;
        }

        #endregion

        

        /// <summary>
        /// 查询岗位信息
        /// </summary>
        /// <returns></returns>

        public List<Job> GetJobInfo()
        {
            var temp = (from j in _jobresposit.FindAll()
                        where j.IsDel == 0
                        select new Job
                        {
                            Id = j.Id,
                            Name = j.Name,
                            Code = j.Code,
                            IsDel = j.IsDel
                        }).ToList();
            return temp;
        }

        /// <summary>
        /// 查询角色信息
        /// </summary>
        /// <returns></returns>
        public List<Role> GetRoleInfo()
        {
            var temp1 = (from r in _roleResposit.FindAll()
                         select new Role
                         {
                             Id = r.Id,
                             Name = r.Name,
                             Code = r.Code
                         }).ToList();
            return temp1;
        }

        /// <summary>
        /// 查询员工信息
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="staff"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public List<object> GetStarffInfo(int pageIndex, int pageSize, Staff staff, ref int total)
        {
            return _staffResposit.GetStarffInfo(pageIndex, pageSize, staff, ref total);
        }

        #region 员工入职信息
        /// <summary>
        /// 获取员工入职信息表
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<Entrys> GetEntrysInfoAll(int pageIndex, int pageSize, ref int totalCount)
        {
            var list = (from en in _entrysResposit.FindPageAll(pageIndex, pageSize, ref totalCount)
                        where en.IsDel == 0
                        select new Entrys
                        {
                            Id = en.Id,
                            StaffName = en.StaffName,
                            Sex = en.Sex,
                            BirthDay = en.BirthDay,
                            Major = en.Major,
                            Tel = en.Tel,
                            JobId=en.JobId,
                            Email = en.Email,
                            IDNumber = en.IDNumber,
                            CreateTime = en.CreateTime,
                            ProbationarySalary = en.ProbationarySalary
                        }).ToList();
            return list;
        }

        /// <summary>
        /// 添加员工入职信息
        /// </summary>
        /// <param name="entrys"></param>
        /// <returns></returns>
        public string addEntrysInfoAll(Entrys entrys)
        {
            string isOk = "添加失败！";
            //开启一个事务
            _entrysResposit.StatrAffair(() => {
                entrys.CreateTime = DateTime.Now;
                entrys.IsDel = 0;


                //得到申请表id
                int entrysId = _entrysResposit.AddCreateInfo(entrys);

                ProcessStepRecord processStepRecord = new ProcessStepRecord();
                processStepRecord.Typed = ProcessType.员工入职审批流程.ToString();

                if (entrys.JobId == (int)JobEmun.油站员工)
                {
                    processStepRecord.OilStation = 1; //油站经理
                }
                else if(entrys.JobId == (int)JobEmun.人事员工)
                {
                    processStepRecord.ExecutiveDirector = 1; //人事经理
                }
                else if (entrys.JobId == (int)JobEmun.油站经理 || entrys.JobId == (int)JobEmun.财务经理)
                {
                    processStepRecord.ExecutiveDirector = 1; //人事经理
                    processStepRecord.GeneralManagerOfPerson = 1; //主管
                }
                else if (entrys.JobId == (int)JobEmun.人事经理 || entrys.JobId == (int)JobEmun.主管)
                {
                    processStepRecord.GeneralManager = 1; //总经理
                    processStepRecord.ChiefInspector = 1; //总监
                }
                else if (entrys.JobId == (int)JobEmun.总经理)
                {
                    processStepRecord.ChiefInspector = 1;
                }
                processStepRecord.CreateTime = DateTime.Now;
                processStepRecord.WhetherToExecute = 1;

                #region 生成non号 不可重复 （后期数据多了之后需要改进）
                bool isok = true;
                string non = "";
                while (isok)
                {
                    non = GetTime.randomPwd() + GetTime.randomPwd() + GetTime.randomPwd();
                    var list = (from pr in _processStepRecordResposit.FindAll()
                                where non == pr.NoN
                                select new { }).ToList();
                    if (list.Count == 0)
                    {
                        isok = false;
                    }

                }
                #endregion

                processStepRecord.NoN = non;
                processStepRecord.RefOrderId = entrysId;  //关联的入职申请表的主键id
                processStepRecord.Result = 0; //表示已经申请还未开始审核
                _processStepRecordResposit.AddInfo(processStepRecord);
                isOk = "ok";
            });


            return isOk;
        }
        /// <summary>
        /// 修改员工入职信息
        /// </summary>
        /// <param name="entrys"></param>
        /// <returns></returns>
        public string updateEntrysInfoAll(Entrys entrys)
        {
            if (_entrysResposit.UpdateInfo((x) => new Entrys
            {
                IDNumber = entrys.IDNumber,
                ProbationarySalary = entrys.ProbationarySalary,
                Sex = entrys.Sex,
                StaffName = entrys.StaffName,
                Tel = entrys.Tel,
                Email = entrys.Email,
                Major = entrys.Major,
                BirthDay = entrys.BirthDay,
                UpdateTime = DateTime.Now

            }, x => x.Id == entrys.Id) > 0)
            {
                return "ok";
            }
            return "修改失败！";
        }


        #endregion


        #region 员工离职信息
        /// <summary>
        /// 查询员工离职表
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<object> GetLeaveOfficesInfoAll(int pageIndex, int pageSize, ref int totalCount)
        {
            List<object> lists = new List<object>();
            ;
            var list = (from le in _leaveOfficeResposit.FindPageAll(pageIndex, pageSize, ref totalCount)
                        join st in _staffResposit.FindAll()
                        on le.ApplyPersonId equals st.Id.ToString()
                        join j in _jobresposit.FindAll()
                        on le.JobId equals j.Id
                        where le.IsDel == "0"                        
                        select new { 
                         Id = le.Id,
                         NoN = le.NoN,
                         StaffName = le.StaffName,
                         JobName = j.Name,
                         JonId = le.JobId,
                         LeaveType = le.LeaveType == "1"? "正常提交离职表":le.LeaveType == "2"?"自动离职":"被辞退",
                         ApplyDate = le.ApplyDate,
                         Reason = le.Reason,
                         ExplanationHandover = le.ExplanationHandover,
                         HandoverSatffId = le.HandoverSatffId,
                         ApplyPersonId = le.ApplyPersonId,
                         Sex = st.Sex
                        }).ToList();
            lists.Add(list);
            return lists;
        }

        /// <summary>
        /// 增添员工离职申请
        /// </summary>
        /// <param name="leaveOffice"></param>
        /// <returns></returns>
        public string addLeaveOfficesInfoAll(LeaveOffice leaveOffice)
        {
            string isOk = "添加失败！";
            Staff staffInfo = _staffResposit.FindAll().FirstOrDefault(x => x.NoN == leaveOffice.NoN);
            if (staffInfo == null)
            {
                isOk = "未查询到此人";
                return isOk;
            }
            //开启事务 
            _leaveOfficeResposit.StatrAffair(() => {
                leaveOffice.ApplyDate = DateTime.Now;
                leaveOffice.isyes = 1;
                leaveOffice.IsDel = "0";
                leaveOffice.ApplyPersonId = staffInfo.Id.ToString();
                leaveOffice.CreateTime = DateTime.Now;

                int leaveId = _leaveOfficeResposit.AddCreateInfo(leaveOffice);

                ProcessStepRecord processStepRecord = new ProcessStepRecord();
                processStepRecord.Typed = ProcessType.员工离职审批流程.ToString();

                if (leaveOffice.JobId == (int)JobEmun.油站员工)
                {
                    processStepRecord.OilStation = 1;
                }
                else if (leaveOffice.JobId == (int)JobEmun.人事员工)
                {
                    processStepRecord.ExecutiveDirector = 1; //人事经理
                }
                else if (leaveOffice.JobId == (int)JobEmun.油站经理 || leaveOffice.JobId == (int)JobEmun.财务经理)
                {
                    processStepRecord.ExecutiveDirector = 1; //人事经理
                    processStepRecord.GeneralManagerOfPerson = 1; //主管
                }
                else if (leaveOffice.JobId == (int)JobEmun.人事经理 || leaveOffice.JobId == (int)JobEmun.主管)
                {
                    processStepRecord.GeneralManager = 1; //总经理
                    processStepRecord.ChiefInspector = 1; //总监
                }
                else if (leaveOffice.JobId == (int)JobEmun.总经理)
                {
                    processStepRecord.ChiefInspector = 1;
                }


                #region 生成non号 不可重复 （后期数据多了之后需要改进）
                bool isok = true;
                string non = "";
                while (isok)
                {
                    non = GetTime.randomPwd() + GetTime.randomPwd() + GetTime.randomPwd();
                    var list = (from pr in _processStepRecordResposit.FindAll()
                                where non == pr.NoN
                                select new { }).ToList();
                    if (list.Count == 0)
                    {
                        isok = false;
                    }

                }
                #endregion
                processStepRecord.CreateTime = DateTime.Now;
                processStepRecord.WhetherToExecute = 1;
                processStepRecord.NoN = non;
                processStepRecord.RefOrderId = leaveId;  //关联的离职申请表的主键id
                processStepRecord.Result = 0;
                _processStepRecordResposit.AddInfo(processStepRecord);
                isOk = "ok";

            });
            return isOk;
        }

        /// <summary>
        /// 修改员工离职申请数据
        /// </summary>
        /// <param name="leaveOffice"></param>
        /// <returns></returns>
        public string updataLeaveOfficesInfoAll(LeaveOffice leaveOffice)
        {
            string LeaveType = leaveOffice.LeaveType == "正常提交离职表" ? "1" : leaveOffice.LeaveType == "自动离职" ? "2" : "3";
            if (_leaveOfficeResposit.UpdateInfo(x => new LeaveOffice() {
                JobId = leaveOffice.JobId,
                StaffName = leaveOffice.StaffName,
                Reason = leaveOffice.Reason,
                ExplanationHandover = leaveOffice.ExplanationHandover,
                HandoverSatffId = leaveOffice.HandoverSatffId,
                LeaveType = LeaveType,
                UpdateTime = DateTime.Now
            },x => x.Id == leaveOffice.Id)> 0)
            {
                return "ok";
            }
            return "修改失败！";
        }
        #endregion

    }
}
