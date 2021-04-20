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
    [Route("api/home")]
    [ApiController]
    public class HomeController : ControllerBase
    {

        private readonly IJobService _jobService;
        private readonly IActionsService _actionsService;
        private readonly IStaffService _staffService;

        #region 仓储
        public HomeController(
            IJobService jobService,
            IActionsService actionsResposit,
            IStaffService staffService
            )
        {
            _jobService = jobService ?? throw new ArgumentNullException(nameof(jobService));
            _actionsService = actionsResposit ?? throw new ArgumentNullException(nameof(actionsResposit));
            _staffService = staffService ?? throw new ArgumentNullException(nameof(staffService));
        }
        #endregion

        /// <summary>
        /// 菜单渲染
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetMenuInfo")]
        public async Task<ActionResult<IEnumerable<Actions>>> GetMenuInfo([FromQuery]int jobId)
        {
            var job = await Task.Factory.StartNew(() => _actionsService.MenusInfoAll(jobId));
            return Ok(job);
        }
        /// <summary>
        /// 登陆
        /// </summary>
        /// <returns></returns>
        [HttpGet("login")]
        public async Task<ActionResult<IEnumerable<Staff>>> logig(string Name, string Passwords)
        {
            return Ok(await Task.Factory.StartNew(() => _actionsService.GetLogInfo(Name, Passwords)));
        }

        /// <summary>
        /// 查询在职员工姓名
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetstaffInfoByName")]
        public async Task<ActionResult<IEnumerable<Staff>>> GetstaffInfoByName()
        {
            return Ok(await Task.Factory.StartNew(() => _staffService.GetStarffInfo()));
        }

        /// <summary>
        ///查询员工申请入职信息
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetEntrysInfoAll")]
        public async Task<ActionResult<IEnumerable<Entrys>>> GetEntrysInfoAll([FromQuery]responseInfo responseInfo)
        {

            int total = 0;
            var temp = await Task.Factory.StartNew(() => _staffService.GetEntrysInfoAll(responseInfo.pageInfo, responseInfo.pageSize, ref total)).ConfigureAwait(false);
            return Ok(new { total, temp });
        }

        /// <summary>
        ///添加员工申请入职信息
        /// </summary>
        /// <returns></returns>
        [HttpPost("AddEntrysInfoAll")]
        public async Task<ActionResult<IEnumerable<Entrys>>> AddEntrysInfoAll([FromBody]Entrys entrys)
        {
            return Ok(await Task.Factory.StartNew(() => _staffService.addEntrysInfoAll(entrys)));
        }

        /// <summary>
        ///修改员工申请入职信息
        /// </summary>
        /// <returns></returns>
        [HttpPost("UpdateEntrysInfoAll")]
        public async Task<ActionResult<IEnumerable<Entrys>>> UpdateEntrysInfoAll([FromBody]Entrys entrys)
        {
            return Ok(await Task.Factory.StartNew(() => _staffService.updateEntrysInfoAll(entrys)));
        }


        /// <summary>
        ///查询员工申请离职信息
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetLeaveOfficesInfoAll")]
        public async Task<ActionResult<IEnumerable<LeaveOffice>>> GetLeaveOfficesInfoAll([FromQuery]responseInfo responseInfo)
        {

            int total = 0;
            var temp = await Task.Factory.StartNew(() => _staffService.GetLeaveOfficesInfoAll(responseInfo.pageInfo, responseInfo.pageSize, ref total)).ConfigureAwait(false);
            return Ok(new { total, temp });
        }

        /// <summary>
        ///添加员工申请离职信息
        /// </summary>
        /// <returns></returns>
        [HttpPost("AddLeaveOfficesInfoAll")]
        public async Task<ActionResult<IEnumerable<LeaveOffice>>> AddLeaveOfficesInfoAll([FromBody]LeaveOffice leaveOffice)
        {
            return Ok(await Task.Factory.StartNew(() => _staffService.addLeaveOfficesInfoAll(leaveOffice)));
        }

        /// <summary>
        ///修改员工申请离职信息
        /// </summary>
        /// <returns></returns>
        [HttpPost("UpdataLeaveOfficesInfoAll")]
        public async Task<ActionResult<IEnumerable<LeaveOffice>>> UpdataLeaveOfficesInfoAll([FromBody]LeaveOffice leaveOffice)
        {
            return Ok(await Task.Factory.StartNew(() => _staffService.updataLeaveOfficesInfoAll(leaveOffice)));
        }
    }
}
