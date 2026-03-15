using Homelab.Data.Data.Catalog.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Homelab.Data.Data.Catalog.Configurations;

public class SubcategoryConfiguration : IEntityTypeConfiguration<subcategory>
{
    public void Configure(EntityTypeBuilder<subcategory> entity)
    {
        entity.HasKey(e => e.id).HasName("subcategories_pkey");

        entity.HasIndex(e => e.alias, "subcategories_alias_key").IsUnique();

        entity.HasIndex(e => new { e.name, e.parentId }, "subcategories_name_parentId_key").IsUnique();

        entity.Property(e => e.created_at)
        .HasDefaultValueSql("CURRENT_TIMESTAMP")
        .HasColumnType("timestamp(3) without time zone");
        entity.Property(e => e.deletedAt).HasColumnType("timestamp(3) without time zone");
        entity.Property(e => e.updated_at).HasColumnType("timestamp(3) without time zone");

        entity.HasOne(d => d.parent).WithMany(p => p.subcategories)
        .HasForeignKey(d => d.parentId)
        .OnDelete(DeleteBehavior.Restrict)
        .HasConstraintName("subcategories_parentId_fkey");

    }
}
