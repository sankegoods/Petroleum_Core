using PetroleumModel.Model;
using PetroleumService.IService;
using Repository.IResposit;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetroleumService.Service
{
    public class ActionsService: BasesService<Actions>, IActionsService
    {
        public ActionsService(IActionsResposit actionsService)
        {
            _baseRepository = actionsService;
        }
    }
}
