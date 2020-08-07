using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public HomeController(IJobService jobService)
        {
            _jobService = jobService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Job>> GetJob()
        {
            var job = _jobService.FindAll().ToList();
            return Ok(job);
        }
    }
}
