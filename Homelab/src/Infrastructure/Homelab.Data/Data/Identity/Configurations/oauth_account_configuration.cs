using Homelab.Data.Data.Identity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Homelab.Data.Data.Identity.Configurations;

public class OauthAccountConfiguration : IEntityTypeConfiguration<oauth_account>
{
    public void Configure(EntityTypeBuilder<oauth_account> entity)
    {
        entity.HasKey(e => e.id).HasName("oauth_accounts_pkey");

        entity.HasIndex(e => e.user_id, "oauth_accounts_user_id_idx");

        entity.Property(e => e.created_at)
        .HasDefaultValueSql("CURRENT_TIMESTAMP")
        .HasColumnType("timestamp(3) without time zone");
        entity.Property(e => e.updated_at).HasColumnType("timestamp(3) without time zone");

        entity.HasOne(d => d.user).WithMany(p => p.oauth_accounts)
        .HasForeignKey(d => d.user_id)
        .HasConstraintName("oauth_accounts_user_id_fkey");

    }
}
