using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetroleumModel;
using PetroleumModel.Model;
using Repository;

namespace PetroleumCore.Controllers
{
    [Route("api/home")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly PetroleumDbContext _dbContext;

        public HomeController(Repository.PetroleumDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Job>> GetJob()
        {
            var job = _dbContext.Set<Job>().Where(x => x.Id >= 0);
            return Ok(job);
        }
    }
}
