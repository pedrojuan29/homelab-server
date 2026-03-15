using Homelab.Data.Data.Identity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Homelab.Data.Data.Identity.Configurations;

public class UserRoleConfiguration : IEntityTypeConfiguration<user_role>
{
    public void Configure(EntityTypeBuilder<user_role> entity)
    {
        entity.HasKey(e => new { e.user_id, e.role_id }).HasName("user_roles_pkey");

        entity.HasIndex(e => e.role_id, "user_roles_role_id_idx");

        entity.Property(e => e.created_at)
        .HasDefaultValueSql("CURRENT_TIMESTAMP")
        .HasColumnType("timestamp(3) without time zone");

        entity.HasOne(d => d.role).WithMany(p => p.user_roles)
        .HasForeignKey(d => d.role_id)
        .HasConstraintName("user_roles_role_id_fkey");

        entity.HasOne(d => d.user).WithMany(p => p.user_roles)
        .HasForeignKey(d => d.user_id)
        .HasConstraintName("user_roles_user_id_fkey");

    }
}
