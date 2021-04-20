using PetroleumModel.ExtendMode;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetroleumService.IService
{
    public interface IOilMaterialOrderService
    {
        List<OilMaterialOrderDto> GetOderInfo();
        bool UpdateOilMatOrder(OilMaterialOrderDto oilMaterialOrderDto);
        bool DeleteOilMatOrder(OilMaterialOrderDto oilMaterialOrderDto);
        bool AddOilMatOrder(OilMaterialOrderDto oilMaterialOrderDto, ref string rem);

        List<object> GetyouliaoshenpiInfo(int pageIndex, int pageSize, int jobId, ref int totalCount);
    }
}
