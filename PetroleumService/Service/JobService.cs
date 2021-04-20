using PetroleumModel.Model;
using PetroleumService.IService;
using Repository.IResposit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetroleumService.Service
{
    public class JobService : BasesService<Job>, IJobService
    {
        private readonly IJobresposit _jobresposit;
        private readonly IStaffService _staffService;
        private readonly IRoleResposit _roleResposit;

        public JobService(IJobresposit jobresposit, 
            IStaffService staffService,
            IRoleResposit roleResposit
            )
        {
            _jobresposit = jobresposit ?? throw new ArgumentNullException(nameof(jobresposit));
            _staffService = staffService ?? throw new ArgumentNullException(nameof(staffService));
            _roleResposit = roleResposit ?? throw new ArgumentNullException(nameof(roleResposit));
        }

        public bool addJueSheInfo(Role role)
        {
            return _roleResposit.AddInfo(role) > 0;
        }

        public bool DeleteJueSheInfo(Role role)
        {
            return _roleResposit.DeleteInfo(x => x.Id == role.Id) > 0;
        }

        public List<Job> GetJobInfo()
        {
            return _staffService.GetJobInfo();
        }

        public List<object> GetJueseQuanxianAll(int pageIndex, int pageSize, ref int total)
        {
            List<object> list = new List<object>();
            var RoleInfo = _roleResposit.FindPageAll(pageIndex, pageSize,ref total);
            var temp = from r in RoleInfo
                       select new
                       {
                        Id = r.Id,
                        Name = r.Name,
                        Code = r.Code
                       };
            list.Add(temp);
            return list;
        }

        public bool UpdataRoleInfo(Role role)
        {
            return _roleResposit.UpdateInfo(x => new Role
            {
                Id = role.Id,
                Code = role.Code,
                Name = role.Name
            }, r => r.Id == role.Id) > 0;
        }
    }
}
