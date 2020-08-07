using PetroleumModel.Model;
using PetroleumService.IService;
using Repository.IResposit;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetroleumService.Service
{
    public class JobService : BasesService<Job>, IJobService
    {
        private readonly IJobresposit jobresposit;

        public JobService(IJobresposit jobresposit)
        {
            this._baseRepository = jobresposit;
        }
        ///// <summary>
        ///// 查询全部(不加分页)
        ///// </summary>
        ///// <returns></returns>
        //public IEnumerable<Job> FindAll()
        //{
        //    return jobresposit.FindAll();
        //}
    }
}
