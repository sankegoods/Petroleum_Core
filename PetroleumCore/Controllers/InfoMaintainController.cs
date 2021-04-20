using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetroleumModel.ExtendMode;
using PetroleumModel.Model;
using PetroleumService.IService;

namespace PetroleumCore.Controllers
{
    /// <summary>
    /// 信息维护
    /// </summary>
    [Route("api/InfoMaintain")]
    [ApiController]
    public class InfoMaintainController : ControllerBase
    {
        private readonly IOrganizationStructureService _organizationStructureService;
        private readonly IStaffService _staffService;
        private readonly IJobService _jobService;

        public InfoMaintainController(IOrganizationStructureService organizationStructureService, IStaffService staffService, IJobService jobService)
        {
            _organizationStructureService = organizationStructureService ?? throw new ArgumentNullException(nameof(organizationStructureService));
            _staffService = staffService ?? throw new ArgumentNullException(nameof(staffService));
            _jobService = jobService ?? throw new ArgumentNullException(nameof(jobService));
        }
        /// <summary>
        /// 组织机构管理
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetOrganInfo")]
        public async Task<ActionResult<IEnumerable<OrganizationStructure>>> GetOrganInfo()
        {
            return Ok(await Task.Factory.StartNew(() => _organizationStructureService.GetOrganInfoAll()).ConfigureAwait(false));
        }

        /// <summary>
        /// 添加组织机构 数据
        /// </summary>
        /// <param name="organizationStructure"></param>
        /// <returns></returns>
        [HttpPost("addOrganInfo")]
        public async Task<bool> addOrganInfo([FromBody]OrganizationStructure organizationStructure)
        {
            return await Task.Factory.StartNew(() => _organizationStructureService.AddOrganInfo(organizationStructure)).ConfigureAwait(false);
        }
        /// <summary>
        /// 删除组织机构数据
        /// </summary>
        /// <param name="organizationStructure"></param>
        /// <returns></returns>
        [HttpDelete("DeleteOrganInfoById")]
        public async Task<bool> DeleteOrganInfoById([FromBody]OrganizationStructure organizationStructure)
        {
            return await Task.Factory.StartNew(() => _organizationStructureService.DeleteOrganInfo(organizationStructure)).ConfigureAwait(false);
        }
        /// <summary>
        /// 获取员工信息
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetStarffInfo")]
        public async Task<ActionResult<IEnumerable<Staff>>> GetStarffInfo([FromQuery]responseInfo responseInfo)
        {
            int total = 0;
            var temp = await Task.Factory.StartNew(() => _staffService.GetStarffInfo(responseInfo.pageInfo, responseInfo.pageSize, ref total)).ConfigureAwait(false);
            return Ok(new { total ,temp });
        }

        [HttpPost("addStarffInfo")]
        public async Task<bool> addStarffInfo([FromBody]Staff staff)
        {
            await Task.Factory.StartNew(() => _staffService.addStarffInfo(staff)).ConfigureAwait(false);
            return true;
        }
        /// <summary>
        /// 获取岗位和角色数据
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetJonRoleInfo")]
        public async Task<ActionResult> GetJonRoleInfo()
        {
            var job = await Task.Factory.StartNew(() => _staffService.GetJobInfo()).ConfigureAwait(false);
            var role = await Task.Factory.StartNew(() => _staffService.GetRoleInfo()).ConfigureAwait(false);
            return Ok(new {job ,role });
        }
        /// <summary>
        /// 获取岗位信息
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetJobInfo")]
        public async Task<ActionResult> GetJobInfo()
        {
            return Ok(await Task.Factory.StartNew(() => _jobService.GetJobInfo()).ConfigureAwait(false));
        }

        /// <summary>
        /// 根据Job或者Role Id获取员工信息
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetStarffInfoById")]
        public async Task<ActionResult> GetStarffInfoById([FromQuery]Staff staff,[FromQuery]responseInfo responseInfo)
        {
            int total = 0;
            var temp = await Task.Factory.StartNew(() => _staffService.GetStarffInfo(responseInfo.pageInfo, responseInfo.pageSize, staff, ref total)).ConfigureAwait(false);
            return Ok(new { total, temp });
        }

        #region 角色权限
        /// <summary>
        /// 查询角色权限相关数据
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetJueseQuanxianAll")]
        public async Task<ActionResult> GetJueseQuanxianAll([FromQuery]responseInfo responseInfo)
        {
            int total = 0;
            var temp = await Task.Factory.StartNew(() => _jobService.GetJueseQuanxianAll(responseInfo.pageInfo, responseInfo.pageSize, ref total)).ConfigureAwait(false);
            return Ok(new { total, temp });
        }
        /// <summary>
        /// 修改角色权限数据
        /// </summary>
        /// <param name="staff"></param>
        /// <returns></returns>
        [HttpPost("UpdataRoleInfo")]
        public async Task<bool> UpdataRoleInfo([FromBody]Role Role)
        {
            return await Task.Factory.StartNew(() => _jobService.UpdataRoleInfo(Role)).ConfigureAwait(false);
        }

        /// <summary>
        /// 增添角色权限数据
        /// </summary>
        /// <param name="staff"></param>
        /// <returns></returns>
        [HttpPost("addJueSheInfo")]
        public async Task<bool> addJueSheInfo([FromBody]Role Role)
        {
            return await Task.Factory.StartNew(() => _jobService.addJueSheInfo(Role)).ConfigureAwait(false);
        }
        /// <summary>
        /// 删除角色权限数据
        /// </summary>
        /// <param name="staff"></param>
        /// <returns></returns>
        [HttpPost("DeleteJueSheInfo")]
        public async Task<bool> DeleteJueSheInfo([FromBody]Role Role)
        {
            return await Task.Factory.StartNew(() => _jobService.DeleteJueSheInfo(Role)).ConfigureAwait(false);
        }

        #endregion
    }
}