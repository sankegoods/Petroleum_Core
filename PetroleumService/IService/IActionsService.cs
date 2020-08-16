using PetroleumModel.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetroleumService.IService
{
    public interface IActionsService: IBaseService<Actions>
    {
        object MenusInfoAll();
    }
}
