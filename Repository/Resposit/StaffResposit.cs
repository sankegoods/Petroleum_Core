using PetroleumModel.Model;
using Repository.IResposit;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Resposit
{
    public class StaffResposit : BasesResposity<Staff>, IStaffResposit
    {
        public List<object> GetStarffInfo(int pageIndex, int pageSize, ref int total)
        {
            List<object> list = new List<object>();
            var temp = _db.Queryable<Staff, Job, Role>((s, j, r) => s.JobId == j.Id && s.RoleId == r.Id)
                .Where((s) => s.Statusd == "入职")
                .Select((s, j, r) => new
                {
                    ID = s.Id,
                    number = s.NoN,
                    name = s.Name,
                    Sex = s.Sex,
                    BirthDay = s.BirthDay,
                    NativePlace = s.NativePlace,
                    Addressd = s.Addressd,
                    Passwords = s.Passwords,
                    Email = s.Email,
                    Tel = s.Tel,
                    Statusd = s.Statusd,
                    CreateTime = s.CreateTime,
                    RoleName = r.Name,
                })
                .ToPageList(pageIndex, pageSize, ref total);
            list.Add(temp);
            return list;
        }

        public List<object> GetStarffInfo(int pageIndex, int pageSize, Staff staff, ref int total)
        {
            List<object> list = new List<object>();
            if (staff.JobId != null)
            {
                var temp = _db.Queryable<Staff, Job, Role>((s, j, r) => s.JobId == j.Id && s.RoleId == r.Id)
                    .Where((s) => s.Statusd == "入职" && s.JobId == staff.JobId)
                    .Select((s, j, r) => new
                    {
                        ID = s.Id,
                        number = s.NoN,
                        name = s.Name,
                        Sex = s.Sex,
                        BirthDay = s.BirthDay,
                        NativePlace = s.NativePlace,
                        Addressd = s.Addressd,
                        Passwords = s.Passwords,
                        Email = s.Email,
                        Tel = s.Tel,
                        Statusd = s.Statusd,
                        CreateTime = s.CreateTime,
                        RoleName = r.Name,
                    })
                    .ToPageList(pageIndex, pageSize, ref total);
                list.Add(temp);
            }
            return list;
        }
    }
}
