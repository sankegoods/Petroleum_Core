using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetroleumModel;
using PetroleumModel.ExtendMode;
using PetroleumModel.Model;
using PetroleumService.IService;
using Repository;
using Repository.IResposit;

namespace PetroleumCore.Controllers
{
    [ApiController]
    [Route("api/order")]
    public class OilMaterialOrderController : ControllerBase
    {
        private readonly IOilMaterialOrderService _oilMaterialOrderService;

        public OilMaterialOrderController(IOilMaterialOrderService oilMaterialOrderService)
        {
            _oilMaterialOrderService = oilMaterialOrderService ?? throw new ArgumentNullException(nameof(oilMaterialOrderService));
        }

        /// <summary>
        /// 获取油料订单数据
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetOiMateOrder")]
        public async Task<ActionResult<IEnumerable<OilMaterialOrder>>> GetOiMateOrder()
        {
            var info = await Task.Factory.StartNew(() => _oilMaterialOrderService.GetOderInfo());
            return Ok(info);
        }

        /// <summary>
        /// 增添油料订单
        /// </summary>
        /// <param name="oilMaterialOrderDto"></param>
        /// <returns></returns>
        [HttpPost("CreateOilMatOrder")]
        public async Task<ActionResult<IEnumerable<OilMaterialOrderDto>>> CreateOilMatOrder([FromBody]OilMaterialOrderDto oilMaterialOrderDto)
        {
            string rem = string.Empty;
            bool temp = await Task.Factory.StartNew(() => _oilMaterialOrderService.AddOilMatOrder(oilMaterialOrderDto, ref rem));
            return Ok(new { rem, temp }); //CreatedAtRoute
            return Ok(); //CreatedAtRoute
        }
        /// <summary>
        /// 修改油料订单
        /// </summary>
        /// <param name="oilMaterialOrderDto"></param>
        /// <returns></returns>
        [HttpPost("UpdateOilMatOrder")]
        public async Task<ActionResult<IEnumerable<OilMaterialOrderDto>>> UpdateOilMatOrder([FromBody] OilMaterialOrderDto oilMaterialOrderDto)
        {
            return Ok(await Task.Factory.StartNew(() => _oilMaterialOrderService.UpdateOilMatOrder(oilMaterialOrderDto)));
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="oilMaterialOrderDto"></param>
        /// <returns></returns>
        [HttpGet("DeleteOilMatOrder")]
        public async Task<ActionResult<IEnumerable<OilMaterialOrderDto>>> DeleteOilMatOrder([FromQuery]OilMaterialOrderDto oilMaterialOrderDto)
        {
            return Ok(await Task.Factory.StartNew(() => _oilMaterialOrderService.DeleteOilMatOrder(oilMaterialOrderDto)));
        }
    }
}