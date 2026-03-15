using Homelab.Data.Data.Inventory.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Homelab.Data.Data.Inventory.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<product>
{
    public void Configure(EntityTypeBuilder<product> entity)
    {
        entity.HasKey(e => e.id).HasName("products_pkey");

        entity.HasIndex(e => e.alias, "products_alias_key").IsUnique();

        entity.HasIndex(e => e.description_tsvector, "products_description_tsvector_idx").HasMethod("gin");

        entity.HasIndex(e => e.name, "products_name_key").IsUnique();

        entity.HasIndex(e => e.name_tsvector, "products_name_tsvector_idx").HasMethod("gin");

        entity.HasIndex(e => e.sku, "products_sku_key").IsUnique();

        entity.Property(e => e.created_at)
        .HasDefaultValueSql("CURRENT_TIMESTAMP")
        .HasColumnType("timestamp(3) without time zone");
        entity.Property(e => e.deletedAt).HasColumnType("timestamp(3) without time zone");
        entity.Property(e => e.updated_at).HasColumnType("timestamp(3) without time zone");

        entity.HasOne(d => d.brand).WithMany(p => p.products)
        .HasForeignKey(d => d.brand_id)
        .OnDelete(DeleteBehavior.Restrict)
        .HasConstraintName("products_brand_id_fkey");

        entity.HasOne(d => d.subcategory).WithMany(p => p.products)
        .HasForeignKey(d => d.subcategory_id)
        .OnDelete(DeleteBehavior.Restrict)
        .HasConstraintName("products_subcategory_id_fkey");

    }
}
