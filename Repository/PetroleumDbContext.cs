using Microsoft.EntityFrameworkCore;
using PetroleumModel;
using PetroleumModel.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class PetroleumDbContext : DbContext
    {
        public PetroleumDbContext(DbContextOptions<PetroleumDbContext> options) : base(options)
        {

        }
        public DbSet<Job> Job { get; set; }
        public DbSet<Actions> Actions { get; set; }
        public DbSet<Approver> Approver { get; set; }
        public DbSet<Entrys> Entrys { get; set; }
        public DbSet<LeaveOffice> LeaveOffice { get; set; }
        public DbSet<OilMaterialOrder> OilMaterialOrder { get; set; }
        public DbSet<OilMaterialOrderDetail> OilMaterialOrderDetail { get; set; }
        public DbSet<OrganizationStructure> OrganizationStructure { get; set; }
        public DbSet<ProcessItem> ProcessItem { get; set; }
        public DbSet<ProcessStepRecord> ProcessStepRecord { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<RoleAction> RoleAction { get; set; }
        public DbSet<RoleResourceModule> RoleResourceModule { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<StaffRole> StaffRole { get; set; }
        public DbSet<SystemResourceModule> SystemResourceModule { get; set; }
    }
}
