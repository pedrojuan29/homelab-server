using Homelab.Data.Data.Catalog.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Homelab.Data.Data.Catalog.Configurations;

public class BrandConfiguration : IEntityTypeConfiguration<brand>
{
    public void Configure(EntityTypeBuilder<brand> entity)
    {
        entity.HasKey(e => e.id).HasName("brands_pkey");

        entity.HasIndex(e => e.alias, "brands_alias_key").IsUnique();

        entity.HasIndex(e => e.name, "brands_name_key").IsUnique();

        entity.Property(e => e.created_at)
        .HasDefaultValueSql("CURRENT_TIMESTAMP")
        .HasColumnType("timestamp(3) without time zone");
        entity.Property(e => e.deletedAt).HasColumnType("timestamp(3) without time zone");
        entity.Property(e => e.updated_at).HasColumnType("timestamp(3) without time zone");

    }
}
