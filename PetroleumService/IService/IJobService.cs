using PetroleumModel.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetroleumService.IService
{
    public interface IJobService : IBaseService<Job>
    {
        List<Job> GetJobInfo();//获取岗位信息
        List<object> GetJueseQuanxianAll(int pageIndex, int pageSize, ref int total);//查询角色权限相关数据
        bool UpdataRoleInfo(Role role);//修改角色权限数据
        bool addJueSheInfo(Role role);//增添角色权限数据
        bool DeleteJueSheInfo(Role role);//删除角色权限数据
    }
}
