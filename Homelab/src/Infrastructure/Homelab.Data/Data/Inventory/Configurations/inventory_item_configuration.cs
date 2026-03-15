using Homelab.Data.Data.Inventory.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Homelab.Data.Data.Inventory.Configurations;

public class InventoryItemConfiguration : IEntityTypeConfiguration<inventory_item>
{
    public void Configure(EntityTypeBuilder<inventory_item> entity)
    {
        entity.HasKey(e => e.id).HasName("inventory_items_pkey");

        entity.HasIndex(e => new { e.stock_id, e.stock_item_id }, "inventory_items_stock_id_stock_item_id_key").IsUnique();

        entity.Property(e => e.created_at)
        .HasDefaultValueSql("CURRENT_TIMESTAMP")
        .HasColumnType("timestamp(3) without time zone");
        entity.Property(e => e.updated_at).HasColumnType("timestamp(3) without time zone");

        entity.HasOne(d => d.stock).WithMany(p => p.inventory_items)
        .HasForeignKey(d => d.stock_id)
        .OnDelete(DeleteBehavior.Restrict)
        .HasConstraintName("inventory_items_stock_id_fkey");

        entity.HasOne(d => d.stock_item).WithMany(p => p.inventory_items)
        .HasForeignKey(d => d.stock_item_id)
        .OnDelete(DeleteBehavior.Restrict)
        .HasConstraintName("inventory_items_stock_item_id_fkey");

    }
}
