using Homelab.Data.Data.Inventory.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Homelab.Data.Data.Inventory.Configurations;

public class ProductCharacteristicConfiguration : IEntityTypeConfiguration<product_characteristic>
{
    public void Configure(EntityTypeBuilder<product_characteristic> entity)
    {
        entity.HasKey(e => e.id).HasName("product_characteristics_pkey");

        entity.Property(e => e.created_at)
        .HasDefaultValueSql("CURRENT_TIMESTAMP")
        .HasColumnType("timestamp(3) without time zone");
        entity.Property(e => e.deletedAt).HasColumnType("timestamp(3) without time zone");
        entity.Property(e => e.updated_at).HasColumnType("timestamp(3) without time zone");

        entity.HasOne(d => d.product).WithMany(p => p.product_characteristics)
        .HasForeignKey(d => d.productId)
        .HasConstraintName("product_characteristics_productId_fkey");

    }
}
