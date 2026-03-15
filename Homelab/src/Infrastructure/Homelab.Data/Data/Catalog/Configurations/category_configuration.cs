using Homelab.Data.Data.Catalog.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Homelab.Data.Data.Catalog.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<category>
{
    public void Configure(EntityTypeBuilder<category> entity)
    {
        entity.HasKey(e => e.id).HasName("categories_pkey");

        entity.HasIndex(e => e.alias, "categories_alias_key").IsUnique();

        entity.HasIndex(e => e.name, "categories_name_key").IsUnique();

        entity.Property(e => e.created_at)
        .HasDefaultValueSql("CURRENT_TIMESTAMP")
        .HasColumnType("timestamp(3) without time zone");
        entity.Property(e => e.deletedAt).HasColumnType("timestamp(3) without time zone");
        entity.Property(e => e.updated_at).HasColumnType("timestamp(3) without time zone");

    }
}
