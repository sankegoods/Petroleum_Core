﻿using PetroleumModel.Model;
using PetroleumService.IService;
using Repository.IResposit;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetroleumService.Service
{
    public class JobService : BasesService<Job>, IJobService
    {
        public JobService(IJobresposit jobresposit)
        {
            _baseRepository = jobresposit;
        }
    }
}
