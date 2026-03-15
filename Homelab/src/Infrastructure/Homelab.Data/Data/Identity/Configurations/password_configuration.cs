using Homelab.Data.Data.Identity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Homelab.Data.Data.Identity.Configurations;

public class PasswordConfiguration : IEntityTypeConfiguration<password>
{
    public void Configure(EntityTypeBuilder<password> entity)
    {
        entity.HasKey(e => e.id).HasName("passwords_pkey");

        entity.Property(e => e.created_at)
        .HasDefaultValueSql("CURRENT_TIMESTAMP")
        .HasColumnType("timestamp(3) without time zone");
        entity.Property(e => e.deletedAt).HasColumnType("timestamp(3) without time zone");
        entity.Property(e => e.updated_at).HasColumnType("timestamp(3) without time zone");

        entity.HasOne(d => d.user).WithMany(p => p.passwords)
        .HasForeignKey(d => d.userId)
        .HasConstraintName("passwords_userId_fkey");

    }
}
