using PetroleumModel.ExtendMode;
using PetroleumModel.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetroleumService.IService
{
     public interface IOrganizationStructureService :IBaseService<OrganizationStructure>
    {
        List<organStrucInfo> GetOrganInfoAll();
        bool AddOrganInfo(OrganizationStructure organizationStructure);
        bool DeleteOrganInfo(OrganizationStructure organizationStructure);
    }
}
