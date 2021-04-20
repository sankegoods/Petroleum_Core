using PetroleumModel.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetroleumService.IService
{
    public interface IStaffService : IBaseService<Staff>
    {
        List<object> GetStarffInfo(int pageIndex,int pageSize,ref int total);
        List<object> GetStarffInfo();
        List<object> GetStarffInfo(int pageIndex,int pageSize, Staff staff, ref int total);
        List<Entrys> GetEntrysInfoAll(int pageIndex, int pageSize, ref int totalCount);
        List<object> GetLeaveOfficesInfoAll(int pageIndex, int pageSize, ref int totalCount);
        bool addStarffInfo(Staff staff);
        bool updateStarff(Staff staff);
        string addEntrysInfoAll(Entrys entrys);
        string updateEntrysInfoAll(Entrys entrys);
        string addLeaveOfficesInfoAll(LeaveOffice leaveOffice);
        string updataLeaveOfficesInfoAll(LeaveOffice leaveOffice);
        List<Job> GetJobInfo();
        List<Role> GetRoleInfo();

    }
}
