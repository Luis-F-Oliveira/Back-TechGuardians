using Back_TechGuardians.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Back_TechGuardians.Data.Map
{
    public class MonitoringMap : IEntityTypeConfiguration<MonitoringModel>
    {
        public void Configure(EntityTypeBuilder<MonitoringModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Block).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Room).IsRequired().HasMaxLength(150);
        }
    }
}
