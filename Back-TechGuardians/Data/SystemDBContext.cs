using Back_TechGuardians.Data.Map;
using Back_TechGuardians.Models;
using Microsoft.EntityFrameworkCore;

namespace Back_TechGuardians.Data
{
    public class SystemDBContext : DbContext
    {
        public SystemDBContext(DbContextOptions<SystemDBContext> options) : base(options) { }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<MonitoringModel> Monitorings { get; set; }
        public DbSet<EquipamentModel> Equipaments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Map.UserMap());
            modelBuilder.ApplyConfiguration(new Map.MonitoringMap());
            modelBuilder.ApplyConfiguration(new Map.EquipamentMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
