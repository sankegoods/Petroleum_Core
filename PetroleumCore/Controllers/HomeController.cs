using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetroleumModel;
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
        private readonly IActionsService _actionsResposit;

        #region 仓储
        public HomeController(
            IJobService jobService,
            IActionsService actionsResposit
            )
        {
            _jobService = jobService ?? throw new ArgumentNullException(nameof(jobService));
            _actionsResposit = actionsResposit ?? throw new ArgumentNullException(nameof(actionsResposit));
        }
        #endregion

        /// <summary>
        /// 菜单渲染
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetMenuInfo")]
        public ActionResult<IEnumerable<Actions>> GetMenuInfo()
        {
            var job = _actionsResposit.MenusInfoAll();
            return Ok(job);
        }
    }
}
