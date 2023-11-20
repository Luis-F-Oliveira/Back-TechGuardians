using Back_TechGuardians.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Back_TechGuardians.Data.Map
{
    public class EquipamentMap : IEntityTypeConfiguration<EquipamentModel>
    {
        public void Configure(EntityTypeBuilder<EquipamentModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(80);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(200);
        }
    }
}
