using PetroleumModel.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.IResposit
{
    public interface IStaffResposit : IBasesResposity<Staff>
    {
        List<object> GetStarffInfo(int pageIndex, int pageSize, ref int total);
        List<object> GetStarffInfo(int pageIndex, int pageSize, Staff staff, ref int total);
    }
}
