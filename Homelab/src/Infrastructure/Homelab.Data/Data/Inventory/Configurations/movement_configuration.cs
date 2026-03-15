using Homelab.Data.Data.Inventory.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Homelab.Data.Data.Inventory.Configurations;

public class MovementConfiguration : IEntityTypeConfiguration<movement>
{
    public void Configure(EntityTypeBuilder<movement> entity)
    {
        entity.HasKey(e => e.id).HasName("movements_pkey");

        entity.Property(e => e.created_at)
        .HasDefaultValueSql("CURRENT_TIMESTAMP")
        .HasColumnType("timestamp(3) without time zone");
        entity.Property(e => e.updated_at).HasColumnType("timestamp(3) without time zone");

        entity.HasOne(d => d.inventory_item).WithMany(p => p.movements)
        .HasForeignKey(d => d.inventory_item_id)
        .OnDelete(DeleteBehavior.Restrict)
        .HasConstraintName("movements_inventory_item_id_fkey");

    }
}
