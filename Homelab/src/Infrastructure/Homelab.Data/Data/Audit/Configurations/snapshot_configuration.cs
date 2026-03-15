using Homelab.Data.Data.Audit.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Homelab.Data.Data.Audit.Configurations;

public class SnapshotConfiguration : IEntityTypeConfiguration<snapshot>
{
    public void Configure(EntityTypeBuilder<snapshot> entity)
    {
        entity.HasKey(e => e.id).HasName("snapshots_pkey");

        entity.Property(e => e.created_at)
        .HasDefaultValueSql("CURRENT_TIMESTAMP")
        .HasColumnType("timestamp(3) without time zone");
        entity.Property(e => e.processed_at).HasColumnType("timestamp(3) without time zone");
        entity.Property(e => e.updated_at).HasColumnType("timestamp(3) without time zone");

        entity.HasOne(d => d.inventory_item).WithMany(p => p.snapshots)
        .HasForeignKey(d => d.inventory_item_id)
        .OnDelete(DeleteBehavior.Restrict)
        .HasConstraintName("snapshots_inventory_item_id_fkey");

    }
}
