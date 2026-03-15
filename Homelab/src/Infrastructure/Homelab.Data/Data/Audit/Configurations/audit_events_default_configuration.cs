using Homelab.Data.Data.Audit.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Homelab.Data.Data.Audit.Configurations;

public class AuditEventsDefaultConfiguration : IEntityTypeConfiguration<audit_events_default>
{
    public void Configure(EntityTypeBuilder<audit_events_default> entity)
    {
        entity.HasKey(e => new { e.occurred_at, e.id }).HasName("audit_events_default_pkey");

        entity.ToTable("audit_events_default");

        entity.HasIndex(e => e.occurred_at, "audit_events_default_occurred_at_idx").HasMethod("brin");

        entity.HasIndex(e => new { e.user_id, e.occurred_at }, "audit_events_default_user_id_occurred_at_idx").IsDescending(false, true);

        entity.Property(e => e.id).HasDefaultValueSql("(gen_random_uuid())::text");

    }
}
