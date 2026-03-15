using Homelab.Data.Data.Location.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Homelab.Data.Data.Location.Configurations;

public class LocationConfiguration : IEntityTypeConfiguration<location>
{
    public void Configure(EntityTypeBuilder<location> entity)
    {
        entity.HasKey(e => e.id).HasName("locations_pkey");

        entity.Property(e => e.created_at)
        .HasDefaultValueSql("CURRENT_TIMESTAMP")
        .HasColumnType("timestamp(3) without time zone");
        entity.Property(e => e.deletedAt).HasColumnType("timestamp(3) without time zone");
        entity.Property(e => e.updated_at).HasColumnType("timestamp(3) without time zone");

    }
}
