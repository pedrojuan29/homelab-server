using Homelab.Data.Data.Identity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Homelab.Data.Data.Identity.Configurations;

public class RolePermissionConfiguration : IEntityTypeConfiguration<role_permission>
{
    public void Configure(EntityTypeBuilder<role_permission> entity)
    {
        entity.HasKey(e => new { e.role_id, e.permission_id }).HasName("role_permissions_pkey");

        entity.HasIndex(e => e.permission_id, "role_permissions_permission_id_idx");

        entity.Property(e => e.created_at)
        .HasDefaultValueSql("CURRENT_TIMESTAMP")
        .HasColumnType("timestamp(3) without time zone");

        entity.HasOne(d => d.permission).WithMany(p => p.role_permissions)
        .HasForeignKey(d => d.permission_id)
        .HasConstraintName("role_permissions_permission_id_fkey");

        entity.HasOne(d => d.role).WithMany(p => p.role_permissions)
        .HasForeignKey(d => d.role_id)
        .HasConstraintName("role_permissions_role_id_fkey");

    }
}
