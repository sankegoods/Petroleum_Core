using PetroleumModel;
using PetroleumModel.Model;
using PetroleumService.IService;
using Repository.IResposit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetroleumService.Service
{
    public class ActionsService : BasesService<Actions>, IActionsService
    {
        private readonly IActionsResposit _actionsService;

        public ActionsService(IActionsResposit actionsService)
        {
            _baseRepository = actionsService;
            _actionsService = actionsService;
        }

        public object MenusInfoAll()
        {
            var temp = (from m in _actionsService.FindAll()
                        where m.NonMenu == 2
                        select m).ToList();

            var temp1 = (from m in _actionsService.FindAll()
                         where m.NonMenu == 1
                         select m).ToList();

            List<Actions_modes> list = new List<Actions_modes>();
            foreach (var item in temp)
            {
                List<Actions> listActions = new List<Actions>();
                for (int i = 0; i < temp1.Count; i++)
                {
                    if (item.NameType == temp1[i].NameType)
                        listActions.Add(temp1[i]);

                }
                list.Add(new Actions_modes() { Name = item.Name, children = listActions });
            }

            return list;
        }
    }
}
