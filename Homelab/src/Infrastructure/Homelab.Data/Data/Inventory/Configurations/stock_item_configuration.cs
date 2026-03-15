using Homelab.Data.Data.Inventory.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Homelab.Data.Data.Inventory.Configurations;

public class StockItemConfiguration : IEntityTypeConfiguration<stock_item>
{
    public void Configure(EntityTypeBuilder<stock_item> entity)
    {
        entity.HasKey(e => e.id).HasName("stock_items_pkey");

        entity.Property(e => e.created_at)
        .HasDefaultValueSql("CURRENT_TIMESTAMP")
        .HasColumnType("timestamp(3) without time zone");
        entity.Property(e => e.deletedAt).HasColumnType("timestamp(3) without time zone");
        entity.Property(e => e.updated_at).HasColumnType("timestamp(3) without time zone");

    }
}
