using PetroleumModel.ExtendMode;
using PetroleumModel.Model;
using PetroleumService.IService;
using Repository.IResposit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetroleumService.Service
{
    public class OrganizationStructureService : BasesService<OrganizationStructure>, IOrganizationStructureService
    {
        private readonly IOrganizationStructureResposit _organizationStructureResposit;

        public OrganizationStructureService(IOrganizationStructureResposit organizationStructureResposit)
        {
            _organizationStructureResposit = organizationStructureResposit ?? throw new ArgumentNullException(nameof(organizationStructureResposit));
        }

        public bool AddOrganInfo(OrganizationStructure organizationStructure)
        {
            try
            {
                string leve = string.Empty;
                if(organizationStructure.Leve == "总部")
                {
                    leve = "大区";
                }else if(organizationStructure.Leve == "大区")
                {
                    leve = "区域";
                }
                return _organizationStructureResposit.AddInfo(new OrganizationStructure()
                {
                    Code = organizationStructure.Code,
                    CreateTime = DateTime.Now,
                    IsDel = 0,
                    Name = organizationStructure.Name,
                    ParentId = organizationStructure.Id.ToString(),
                    Leve = leve,
                }) > 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DeleteOrganInfo(OrganizationStructure organizationStructure)
        {
            try
            {
                if(organizationStructure.ParentId == "0")
                {
                   return _organizationStructureResposit.UpdateInfo(it => new OrganizationStructure { IsDel = 1, UpdateTime = DateTime.Now }, it => it.Id == organizationStructure.Id) > 0;
                }
                else
                {
                    var info = (from o in _organizationStructureResposit.FindAll()
                               where o.Id == organizationStructure.Id || o.ParentId == organizationStructure.Id.ToString()
                                select new OrganizationStructure
                               {
                                    Id = o.Id
                               }).ToList();
                    return _organizationStructureResposit.Updateable(info,it =>new OrganizationStructure {  IsDel = 1, UpdateTime = DateTime.Now }) > 0;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// 查询组织结构数据
        /// </summary>
        /// <returns></returns>
        public List<organStrucInfo> GetOrganInfoAll()
        {
            var temp = (from o in _organizationStructureResposit.FindAll()
                        where o.Leve == "总部"
                        select new organStrucInfo()
                        {
                            id = o.Id,
                            Leve = o.Leve,
                            label = o.Name,
                            ParentId = o.ParentId
                        }).ToList();

            var temp1 = (from o in _organizationStructureResposit.FindAll()
                        where o.Leve == "大区"
                        select new organStrucChildren()
                        {
                            id = o.Id,
                            Leve = o.Leve,
                            ParentId = o.ParentId,
                            label = o.Name
                        }).ToList();
            var temp2 = (from o in _organizationStructureResposit.FindAll()
                         where o.Leve == "区域"
                         select new organSturchilders()
                         {
                             id = o.Id,
                             label = o.Name,
                             ParentId = o.ParentId,
                         }).ToList();
            List<organStrucInfo> list = new List<organStrucInfo>();
            foreach (var item in temp)
            {
                List<organStrucChildren> child = new List<organStrucChildren>();
                foreach (var item1 in temp1)
                {
                    List<organSturchilders> child1 = new List<organSturchilders>();
                    foreach (var item2 in temp2)
                    {
                        if (item1.id == Convert.ToInt32(item2.ParentId))
                        {

                            child1.Add(new organSturchilders()
                            {
                                id = item2.id,
                                label = item2.label,
                                ParentId = item2.ParentId
                            });
                        }
                    }
                    child.Add(new organStrucChildren()
                    {
                        id = item1.id,
                        ParentId = item1.ParentId,
                        label = item1.label,
                        Leve = item1.Leve,
                        children = child1
                    });
                }
                list.Add(new organStrucInfo()
                {
                    id = item.id,
                    label = item.label,
                    Leve = item.Leve,
                    ParentId = item.ParentId,
                    children = child
                });
            }
            return list;
        }
    }
}
