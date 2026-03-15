using Homelab.Data.Data.Inventory.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Homelab.Data.Data.Inventory.Configurations;

public class ProductImageConfiguration : IEntityTypeConfiguration<product_image>
{
    public void Configure(EntityTypeBuilder<product_image> entity)
    {
        entity.HasKey(e => e.id).HasName("product_images_pkey");

        entity.Property(e => e.created_at)
        .HasDefaultValueSql("CURRENT_TIMESTAMP")
        .HasColumnType("timestamp(3) without time zone");
        entity.Property(e => e.deletedAt).HasColumnType("timestamp(3) without time zone");
        entity.Property(e => e.updated_at).HasColumnType("timestamp(3) without time zone");

        entity.HasOne(d => d.product).WithMany(p => p.product_images)
        .HasForeignKey(d => d.productId)
        .HasConstraintName("product_images_productId_fkey");

    }
}
