using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetroleumModel.Dtos;
using PetroleumModel.ExtendMode;
using PetroleumModel.Model;
using PetroleumService.IService;


namespace PetroleumCore.Controllers
{
    [Route("api/leaveOffice")]
    [ApiController]
    public class LeaveOfficeController : BaseController
    {
        private readonly ILeaveOfficeService _leaveOfficeService;
        #region 仓储
        public LeaveOfficeController(ILeaveOfficeService leaveOfficeService)
        {
            _leaveOfficeService = leaveOfficeService ?? throw new ArgumentNullException(nameof(leaveOfficeService));
        }
        #endregion

        #region 暂时未用的部分代码(忘了那儿用的！！！)
        /// <summary>
        /// 获取离职数据
        /// </summary>
        /// <param name="pageingInfo"></param>
        /// <returns></returns>
        [HttpGet("GetLeaveOffice")]
        public async Task<ActionResult> GetLeaveOffice([FromQuery]PageingInfo pageingInfo, int jobId)
        {
            int count = 0;
            responseInfo.success = await Task.Factory.StartNew(() => _leaveOfficeService.GetLeaveOffices(pageingInfo.pageIndex, pageingInfo.pageSize, jobId, ref count));
            responseInfo.totalCount = count;
            return Ok(responseInfo);
        }

        /// <summary>
        /// 修改离职数据
        /// </summary>
        /// <param name="leaveOffice"></param>
        /// <returns></returns>
        [HttpPost("UpdateLeaveOffice")]
        public async Task<ActionResult> UpdateLeaveOffice([FromBody] LeaveOffice leaveOffice)
        {
            string log = string.Empty;
            if (await Task.Factory.StartNew(() => _leaveOfficeService.UpdateLeaveOffices(leaveOffice, ref log)))
            {
                responseInfo.successIn = log;
            }
            else
            {
                responseInfo.unsuccessful = log;
            }

            return Ok(responseInfo);
        }

        /// <summary>
        /// 添加离职记录
        /// </summary>
        /// <param name="leaveOffice"></param>
        /// <returns></returns>
        public async Task<ActionResult> AddLeaveOffice([FromBody] LeaveOffice leaveOffice)
        {
            return Ok(await Task.Factory.StartNew(() => _leaveOfficeService.AddLeaveOffices(leaveOffice)));
        }

        /// <summary>
        /// 删除离职
        /// </summary>
        /// <param name="leaveOffice"></param>
        /// <returns></returns>
        public async Task<ActionResult> DeleteLeaveOffice([FromQuery] LeaveOffice leaveOffice)
        {
            return Ok(await Task.Factory.StartNew(() => _leaveOfficeService.DeleteLeaveOffices(leaveOffice)));
        }
        #endregion

        #region 员工入职审批
        /// <summary>
        /// 获取需要入职审批的数据
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetruzhishenpiInfo")]
        public async Task<ActionResult<IEnumerable<object>>> GetruzhishenpiInfo([FromQuery]responseInfo responseInfo, [FromQuery]int jobId)
        {
            int total = 0;
            var temp = await Task.Factory.StartNew(() => _leaveOfficeService.GetruzhiInfo(responseInfo.pageInfo, responseInfo.pageSize, jobId, ref total));
            return Ok(new { total, temp });
        }

        /// <summary>
        /// 审批入职表信息
        /// </summary>
        /// <returns></returns>
        [HttpPost("UpdateruzhishenpiInfo")]
        public async Task<ActionResult<IEnumerable<object>>> UpdateruzhishenpiInfo([FromBody]Entity_shenpi_mode  entity_Shenpi_Mode)
        {
            return Ok(await Task.Factory.StartNew(() => _leaveOfficeService.UpdateRuzhiInfo(entity_Shenpi_Mode.JobId, entity_Shenpi_Mode.Remack, entity_Shenpi_Mode.ProceId, entity_Shenpi_Mode.StaffName)));
        }

        #endregion

        #region 员工离职审批

        /// <summary>
        /// 获取需要离职审批的数据
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetlizhishenpiInfo")]
        public async Task<ActionResult<IEnumerable<object>>> GetlizhishenpiInfo([FromQuery]responseInfo responseInfo, [FromQuery]int jobId)
        {
            int total = 0;
            var temp = await Task.Factory.StartNew(() => _leaveOfficeService.GetlizhiInfo(responseInfo.pageInfo, responseInfo.pageSize, jobId, ref total));
            return Ok(new { total, temp });
        }

        /// <summary>
        /// 审批离职表信息
        /// </summary>
        /// <returns></returns>
        [HttpPost("UpdatelizhishenpiInfo")]
        public async Task<ActionResult<IEnumerable<object>>> UpdatelizhishenpiInfo([FromBody]Entity_shenpi_mode entity_Shenpi_Mode)
        {
            return Ok(await Task.Factory.StartNew(() => _leaveOfficeService.UpdateLizhiInfo(entity_Shenpi_Mode.JobId, entity_Shenpi_Mode.Remack, entity_Shenpi_Mode.ProceId, entity_Shenpi_Mode.StaffName)));
        }
        #endregion
    }
}