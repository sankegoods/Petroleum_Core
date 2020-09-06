using PetroleumModel.ExtendMode;
using PetroleumModel.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetroleumService.IService
{
    public interface IOilMaterialOrderService : IBaseService<OilMaterialOrder>
    {
        List<OilMaterialOrderDto> GetOderInfo();
        bool UpdateOilMatOrder(OilMaterialOrderDto oilMaterialOrderDto);
        bool DeleteOilMatOrder(OilMaterialOrderDto oilMaterialOrderDto);
        bool AddOilMatOrder(OilMaterialOrderDto oilMaterialOrderDto,ref string rem);
    }
}
