using Homelab.Data.Data.Identity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Homelab.Data.Data.Identity.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<user>
{
    public void Configure(EntityTypeBuilder<user> entity)
    {
        entity.HasKey(e => e.id).HasName("users_pkey");

        entity.HasIndex(e => e.email, "users_email_key").IsUnique();

        entity.Property(e => e.created_at)
        .HasDefaultValueSql("CURRENT_TIMESTAMP")
        .HasColumnType("timestamp(3) without time zone");
        entity.Property(e => e.deletedAt).HasColumnType("timestamp(3) without time zone");
        entity.Property(e => e.updated_at).HasColumnType("timestamp(3) without time zone");

    }
}
