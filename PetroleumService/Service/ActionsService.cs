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
        private readonly IStaffResposit _staffResposit;
        private readonly IJobresposit _jobresposit;
        private readonly IJobactionResposit _jobactionResposit;

        public ActionsService(IActionsResposit actionsService, IStaffResposit staffResposit, IJobresposit jobresposit,IJobactionResposit jobactionResposit)
        {
            _baseRepository = actionsService;
            _actionsService = actionsService ?? throw new ArgumentNullException(nameof(actionsService));
            _staffResposit = staffResposit ?? throw new ArgumentNullException(nameof(staffResposit));
            _jobresposit = jobresposit ?? throw new ArgumentNullException(nameof(jobresposit));
            _jobactionResposit = jobactionResposit ?? throw new ArgumentNullException(nameof(jobactionResposit));
        }


        public object MenusInfoAll(int jobId)
        {
            //主菜单查询
            var temp = (from m in _actionsService.FindAll()
                        where m.NonMenu == 2
                        select m).ToList();

            //子菜单查询
            var temp1 = (from m in _actionsService.FindAll()
                         join j in _jobactionResposit.FindAll()
                         on m.Id equals j.ActionId
                         where m.NonMenu == 1 && j.JobId == jobId
                         orderby m.Mnusort
                         select m).ToList();

            List<Actions_modes> list = new List<Actions_modes>();
            //temp1.GroupBy(x => x.Mnusort);
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

        /// <summary>
        /// 用户登陆
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Passwords"></param>
        /// <returns></returns>
        public object GetLogInfo(string Name, string Passwords)
        {
            Staff Info = _staffResposit.FindAll().FirstOrDefault(x => x.NoN == Name);
            if (Info != null)
            {
                if (Info.Passwords == Passwords)
                {
                    Job job = _jobresposit.FindAll().FirstOrDefault(x => x.Id == Info.JobId);
                    return new { Info, job };
                }
                else
                {
                    return "密码错误！！";
                }
            }
            else
            {
                return "该用户不存在！！";
            }
        }
    }
}
