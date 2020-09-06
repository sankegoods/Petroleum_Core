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

        public OilMaterialOrderService(
            IOilMaterialOrderResposit oilMaterialOrderService,
            IOilMaterialOrderDetailResposit oilMaterialOrderDetailResposit,
            IStaffResposit staffResposit
            )
        {
            _oilMaterialOrderResposit = oilMaterialOrderService ?? throw new ArgumentNullException(nameof(oilMaterialOrderService));
            _oilMaterialOrderDetailResposit = oilMaterialOrderDetailResposit ?? throw new ArgumentNullException(nameof(oilMaterialOrderDetailResposit));
            _staffResposit = staffResposit ?? throw new ArgumentNullException(nameof(staffResposit));
        }
        #endregion

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
                                              on oredr.ApplyPersonId equals user.Name
                                              select new OilMaterialOrderDto
                                              {
                                                  Id = oredr.Id,
                                                  IsDel = oredr.IsDel,
                                                  IsPanke = oredr.IsPanke,
                                                  NoN = oredr.NoN,
                                                  ApplyDate = oredr.ApplyDate,
                                                  ApplyPersonId = oredr.ApplyPersonId,
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
            if (_staffResposit.FindAll().Where(x => x.Name == oilMaterialOrderDto.ApplyPersonId).FirstOrDefault() == null)
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
                ApplyPersonId = oilMaterialOrderDto.ApplyPersonId,
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
            Staff staff = _staffResposit.FindAll().Where(x => x.Name == oilMaterialOrderDto.ApplyPersonId).FirstOrDefault();
            if (staff == null)
            {
                rem = "未找到这个用户！！！";
                return false;
            }
            int num = 0;
            _oilMaterialOrderResposit.StatrAffair(() =>
            {

                int OrderId = _oilMaterialOrderResposit.AddCreateInfo(new OilMaterialOrder
                {
                    ApplyPersonId = oilMaterialOrderDto.ApplyPersonId,
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
            });
            num++;
            return num > 0;
        }
    }
}
