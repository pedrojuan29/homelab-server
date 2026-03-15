using Homelab.Data.Data.Inventory.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Homelab.Data.Data.Inventory.Configurations;

public class StockConfiguration : IEntityTypeConfiguration<stock>
{
    public void Configure(EntityTypeBuilder<stock> entity)
    {
        entity.HasKey(e => e.id).HasName("stocks_pkey");

        entity.HasIndex(e => e.location_id, "stocks_location_id_key").IsUnique();

        entity.Property(e => e.created_at)
        .HasDefaultValueSql("CURRENT_TIMESTAMP")
        .HasColumnType("timestamp(3) without time zone");
        entity.Property(e => e.deletedAt).HasColumnType("timestamp(3) without time zone");
        entity.Property(e => e.updated_at).HasColumnType("timestamp(3) without time zone");

        entity.HasOne(d => d.location).WithOne(p => p.stock)
        .HasForeignKey<stock>(d => d.location_id)
        .OnDelete(DeleteBehavior.Restrict)
        .HasConstraintName("stocks_location_id_fkey");

    }
}
