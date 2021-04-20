using PetroleumModel.Model;
using PetroleumModel;
using PetroleumService.IService;
using Repository.IResposit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetroleumModel.ExtendMode;
using ServiceExt;

namespace PetroleumService.Service
{
    public class OilMaterialOrderService : BasesService<OilMaterialOrder>, IOilMaterialOrderService
    {
        #region 仓储
        private readonly IOilMaterialOrderResposit _oilMaterialOrderResposit;
        private readonly IOilMaterialOrderDetailResposit _oilMaterialOrderDetailResposit;
        private readonly IStaffResposit _staffResposit;
        private readonly IProcessStepRecordResposit _processStepRecordResposit;

        public OilMaterialOrderService(
            IOilMaterialOrderResposit oilMaterialOrderService,
            IOilMaterialOrderDetailResposit oilMaterialOrderDetailResposit,
            IStaffResposit staffResposit,
            IProcessStepRecordResposit processStepRecordResposit
            )
        {
            _oilMaterialOrderResposit = oilMaterialOrderService ?? throw new ArgumentNullException(nameof(oilMaterialOrderService));
            _oilMaterialOrderDetailResposit = oilMaterialOrderDetailResposit ?? throw new ArgumentNullException(nameof(oilMaterialOrderDetailResposit));
            _staffResposit = staffResposit ?? throw new ArgumentNullException(nameof(staffResposit));
            _processStepRecordResposit = processStepRecordResposit ?? throw new ArgumentNullException(nameof(processStepRecordResposit));
        }
        #endregion

        #region 油料申请
        /// <summary>
        /// 获取油料订单
        /// </summary>
        /// <returns></returns>
        public List<OilMaterialOrderDto> GetOderInfo()
        {
            List<OilMaterialOrderDto> temp = (from oredr in _oilMaterialOrderResposit.FindAll()
                                              join detail in _oilMaterialOrderDetailResposit.FindAll()
                                              on oredr.Id equals detail.OrderId
                                              join user in _staffResposit.FindAll()
                                              on oredr.StaffNoN equals user.NoN
                                              select new OilMaterialOrderDto
                                              {
                                                  Id = oredr.Id,
                                                  IsDel = oredr.IsDel,
                                                  IsPanke = oredr.IsPanke,
                                                  NoN = oredr.NoN,
                                                  ApplyDate = oredr.ApplyDate,
                                                  StaffNoN = oredr.StaffNoN,
                                                  stfName = user.Name,
                                                  CreateTime = oredr.CreateTime,
                                                  Remark = oredr.Remark,
                                                  OilSpec = detail.OilSpec,
                                                  Volume = detail.Volume,
                                                  Surplus = detail.Surplus,
                                                  DayAvg = detail.DayAvg,
                                                  NeedAmount = detail.NeedAmount,
                                                  DetailID = detail.Id
                                              }).ToList();
            return temp;
        }

        /// <summary>
        /// 更新订单数据
        /// </summary>
        /// <param name="oilMaterialOrderDto"></param>
        /// <returns></returns>
        public bool UpdateOilMatOrder(OilMaterialOrderDto oilMaterialOrderDto)
        {
            if (_staffResposit.FindAll().Where(x => x.Name == oilMaterialOrderDto.StaffNoN).FirstOrDefault() == null)
            {
                return false;
            }

            int Detail = _oilMaterialOrderDetailResposit.UpdateInfo(x => new OilMaterialOrderDetail
            {
                OilSpec = oilMaterialOrderDto.OilSpec,
                DayAvg = oilMaterialOrderDto.DayAvg,
                Volume = oilMaterialOrderDto.Volume,
                Surplus = oilMaterialOrderDto.Surplus,
                NeedAmount = oilMaterialOrderDto.NeedAmount,
                UpdateTime = DateTime.Now
            }, it => it.Id == oilMaterialOrderDto.DetailID);
            int Order = _oilMaterialOrderResposit.UpdateInfo(x => new OilMaterialOrder
            {
                StaffNoN = oilMaterialOrderDto.StaffNoN,
                UpdateTime = DateTime.Now,
                Remark = oilMaterialOrderDto.Remark

            }, it => it.Id == oilMaterialOrderDto.Id);

            if ((Detail + Order) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除订单
        /// </summary>
        /// <param name="oilMaterialOrderDto"></param>
        /// <returns></returns>
        public bool DeleteOilMatOrder(OilMaterialOrderDto oilMaterialOrderDto)
        {
            int num = 0;
            //开启事务
            _oilMaterialOrderResposit.StatrAffair(() =>
            {
                num += _oilMaterialOrderResposit.DeleteInfo(x => x.Id == oilMaterialOrderDto.Id);
                num += _oilMaterialOrderDetailResposit.DeleteInfo(x => x.Id == oilMaterialOrderDto.DetailID);
            });
            return num > 0;
        }

        /// <summary>
        /// 增添订单
        /// </summary>
        /// <param name="oilMaterialOrderDto"></param>
        /// <returns></returns>
        public bool AddOilMatOrder(OilMaterialOrderDto oilMaterialOrderDto, ref string rem)
        {
            Staff staff = _staffResposit.FindAll().Where(x => x.NoN == oilMaterialOrderDto.StaffNoN).FirstOrDefault();
            if (staff == null)
            {
                rem = "未找到这个用户！！！";
                return false;
            }
            int num = 0;
            //开启事务
            _oilMaterialOrderResposit.StatrAffairs(() =>
            {
                int OrderId = _oilMaterialOrderResposit.AddCreateInfo(new OilMaterialOrder
                {
                    StaffNoN = oilMaterialOrderDto.StaffNoN,
                    NoN = GetTime.GetTimeAll() + GetTime.GetTimeStamp() + "_" + GetTime.GetRandom(),
                    ApplyDate = DateTime.Now,
                    Remark = oilMaterialOrderDto.Remark,
                    IsDel = 0,
                    CreateTime = DateTime.Now,
                    IsPanke = 0,
                    IsLaunch = 0
                });
                _oilMaterialOrderDetailResposit.AddInfo(new OilMaterialOrderDetail
                {
                    OrderId = OrderId,
                    CreateTime = DateTime.Now,
                    DayAvg = oilMaterialOrderDto.DayAvg,
                    IsDel = 0,
                    NeedAmount = oilMaterialOrderDto.NeedAmount,
                    OilSpec = oilMaterialOrderDto.OilSpec,
                    Surplus = oilMaterialOrderDto.Surplus,
                    Volume = oilMaterialOrderDto.Volume
                });

                ProcessStepRecord processStepRecord = new ProcessStepRecord();

                //根据申请油料的多少决定有谁来审批
                if (oilMaterialOrderDto.NeedAmount <= 1000)
                {
                    processStepRecord.OilStation = 1;
                }
                else if (oilMaterialOrderDto.NeedAmount > 1000 && oilMaterialOrderDto.NeedAmount <= 10000)
                {
                    processStepRecord.GeneralManagerOfPerson = 1;
                }
                else if (oilMaterialOrderDto.NeedAmount > 10000 && oilMaterialOrderDto.NeedAmount <= 50000)
                {
                    processStepRecord.GeneralManagerOfPerson = 1;
                    processStepRecord.GeneralManager = 1;
                }
                else if (oilMaterialOrderDto.NeedAmount > 50000)
                {
                    processStepRecord.ChiefInspector = 1;
                }

                processStepRecord.Typed = ProcessType.油料申请审批流程.ToString();
                processStepRecord.RecordRemarks = oilMaterialOrderDto.Remark;
                processStepRecord.NoN = NewNoN();
                processStepRecord.RefOrderId = OrderId; //申请油料订单的id
                _processStepRecordResposit.AddInfo(processStepRecord);
                num++;
            });
            return num > 0;
        }

        public string NewNoN()
        {
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
            return non;
        }
        #endregion


        #region 油料审批
        /// <summary>
        /// 获取油料审批数据
        /// </summary>
        /// <returns></returns>
        public List<object> GetyouliaoshenpiInfo(int pageIndex, int pageSize, int jobId, ref int totalCount)
        {
            if((int)JobEmun.油站经理 == jobId)
            {
               return _oilMaterialOrderResposit.GetListyouliaoInfo(pageIndex, pageSize, (p, oi, oid, st) =>
                      p.Typed == ProcessType.油料申请审批流程.ToString() &&
                     p.OilStation == 1 && p.GeneralManagerOfPerson == null
                   ,ref totalCount);
            }
            else if((int)JobEmun.主管 == jobId)
            {
                return _oilMaterialOrderResposit.GetListyouliaoInfo(pageIndex, pageSize, (p, oi, oid, st) =>
                      p.Typed == ProcessType.油料申请审批流程.ToString() &&
                      p.GeneralManagerOfPerson == 1 && p.GeneralManager == 1
                   , ref totalCount);
            }
            else if((int)JobEmun.总经理 == jobId)
            {
                return _oilMaterialOrderResposit.GetListyouliaoInfo(pageIndex, pageSize, (p, oi, oid, st) =>
                      p.Typed == ProcessType.油料申请审批流程.ToString() &&
                      p.GeneralManagerOfPerson == 0 && p.GeneralManager == 1 && p.ChiefInspector == null
                   , ref totalCount);
            }
            else if((int)JobEmun.总监 == jobId)
            {
                return _oilMaterialOrderResposit.GetListyouliaoInfo(pageIndex, pageSize, (p, oi, oid, st) =>
                      p.Typed == ProcessType.油料申请审批流程.ToString() &&
                      p.GeneralManager == null && p.ChiefInspector == 1
                   , ref totalCount);
            }
            return null;
        }

        public List<object> GetListyouliaoInfo(int pageIndex, int pageSize, ref int totalCount)
        {
            List<object> list = new List<object>();
            var temp = (from oi in _oilMaterialOrderResposit.FindPageAll(pageIndex, pageSize, ref totalCount)
                        select new
                        {

                        }).ToList();
            list.Add(temp);
            return list;
        }

        /// <summary>
        /// 审批确定油料申请数据
        /// </summary>
        /// <returns></returns>
        public string UpdateyouliaoInfo(string remack,int oilmId, int jobId)
        {
            string rutes = string.Empty;
            _processStepRecordResposit.StatrAffair(() =>
            {
                ProcessStepRecord processStepRecord = new ProcessStepRecord();
                ProcessStepRecord processStep = _processStepRecordResposit.FindAll().FirstOrDefault(x => x.RefOrderId == oilmId);
                OilMaterialOrder oilMaterialOrder = _oilMaterialOrderResposit.FindAll().FirstOrDefault(x => x.Id == oilmId);
                oilMaterialOrder.UpdateTime = DateTime.Now;
                OilMaterialOrderDetail oilMaterialOrderDetail = _oilMaterialOrderDetailResposit.FindAll().FirstOrDefault(x => x.OrderId == oilmId);
                oilMaterialOrderDetail.UpdateTime = DateTime.Now;
                if ((int)JobEmun.油站经理 == jobId)
                {
                    if (remack == "同意")
                    {
                        processStep.OilStation = 0;
                        processStep.OilStationRemark = remack;
                        processStep.Result = 2;
                    }
                    else
                    {
                        processStep.OilStation = 2; //不同意该申请
                        processStep.OilStationRemark = remack;
                        processStep.Result = 3;
                    }
                }
                else if ((int)JobEmun.主管 == jobId)
                {
                    if (remack == "同意")
                    {
                        processStep.GeneralManagerOfPerson = 0;
                        processStep.GeneralManagerOfPersonRemark = remack;
                        processStep.Result = 2;
                    }
                    else
                    {
                        processStep.GeneralManagerOfPerson = 2; //不同意该申请
                        processStep.GeneralManagerOfPersonRemark = remack;
                        processStep.Result = 3;
                    }
                }
                else if ((int)JobEmun.总经理 == jobId)
                {
                    if (remack == "同意")
                    {
                        processStep.GeneralManager = 0;
                        processStep.GeneralManagerRemark = remack;
                        processStep.Result = 2;
                    }
                    else
                    {
                        processStep.GeneralManager = 2; //不同意该申请
                        processStep.GeneralManagerRemark = remack;
                        processStep.Result = 3;
                    }
                }
                else if ((int)JobEmun.总监 == jobId)
                {
                    if (remack == "同意")
                    {
                        processStep.ChiefInspector = 0;
                        processStep.ChiefInspectorRemark = remack;
                        processStep.Result = 2;
                    }
                    else
                    {
                        processStep.ChiefInspector = 2; //不同意该申请
                        processStep.ChiefInspectorRemark = remack;
                        processStep.Result = 3;
                    }
                }
                _processStepRecordResposit.UpdateInfo((x) => new ProcessStepRecord
                {
                    OilStation = processStep.OilStation,
                    OilStationRemark = processStep.OilStationRemark,
                    GeneralManagerOfPersonRemark = processStep.GeneralManagerOfPersonRemark,
                    GeneralManagerOfPerson = processStep.GeneralManagerOfPerson,
                    GeneralManager = processStep.GeneralManager,
                    GeneralManagerRemark = processStep.GeneralManagerRemark,
                    ChiefInspector = processStep.ChiefInspector,
                    ChiefInspectorRemark = processStep.ChiefInspectorRemark,
                    Result = processStep.Result
                }, x => x.Id == processStep.Id);

                _oilMaterialOrderDetailResposit.UpdateInfo((x) => new OilMaterialOrderDetail
                {
                    UpdateTime = oilMaterialOrderDetail.UpdateTime
                }, x => x.Id == oilMaterialOrderDetail.Id);

                _oilMaterialOrderResposit.UpdateInfo((x) => new OilMaterialOrder
                {
                    UpdateTime = oilMaterialOrder.UpdateTime
                }, x => x.Id == oilMaterialOrderDetail.Id);

                rutes = "ok";
            });
            return rutes;
            
        }
        #endregion
    }
}
