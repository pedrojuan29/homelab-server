using System;
using System.Collections.Generic;
using Homelab.Data.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Homelab.Data.Data;

public partial class HomelabContext : DbContext
{
    public HomelabContext()
    {
    }

    public HomelabContext(DbContextOptions<HomelabContext> options)
        : base(options)
    {
    }

    public virtual DbSet<audit_events_202603> audit_events_202603s { get; set; }

    public virtual DbSet<audit_events_202604> audit_events_202604s { get; set; }

    public virtual DbSet<audit_events_202605> audit_events_202605s { get; set; }

    public virtual DbSet<audit_events_202606> audit_events_202606s { get; set; }

    public virtual DbSet<audit_events_default> audit_events_defaults { get; set; }

    public virtual DbSet<branch> branches { get; set; }

    public virtual DbSet<brand> brands { get; set; }

    public virtual DbSet<category> categories { get; set; }

    public virtual DbSet<inventory_item> inventory_items { get; set; }

    public virtual DbSet<location> locations { get; set; }

    public virtual DbSet<movement> movements { get; set; }

    public virtual DbSet<oauth_account> oauth_accounts { get; set; }

    public virtual DbSet<password> passwords { get; set; }

    public virtual DbSet<permission> permissions { get; set; }

    public virtual DbSet<product> products { get; set; }

    public virtual DbSet<product_characteristic> product_characteristics { get; set; }

    public virtual DbSet<product_image> product_images { get; set; }

    public virtual DbSet<role> roles { get; set; }

    public virtual DbSet<role_permission> role_permissions { get; set; }

    public virtual DbSet<snapshot> snapshots { get; set; }

    public virtual DbSet<stock> stocks { get; set; }

    public virtual DbSet<stock_item> stock_items { get; set; }

    public virtual DbSet<subcategory> subcategories { get; set; }

    public virtual DbSet<user> users { get; set; }

    public virtual DbSet<user_role> user_roles { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    => optionsBuilder.UseNpgsql("Host=192.168.0.12;Database=homelabdb;Username=homelab;Password=homelab123");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasPostgresEnum("CriticalityLevel", new[] { "LOW", "MEDIUM", "HIGH", "CRITICAL" })
            .HasPostgresEnum("MovementType", new[] { "IN", "OUT", "ADJUSTMENT", "TRANSFER" })
            .HasPostgresEnum("OAuthProvider", new[] { "GOOGLE" })
            .HasPostgresEnum("PasswordStatus", new[] { "ACTIVE", "INACTIVE" })
            .HasPostgresExtension("pgcrypto");


        modelBuilder.Entity<audit_events_202603>(entity =>
        {
            entity.HasKey(e => new { e.occurred_at, e.id }).HasName("audit_events_202603_pkey");

            entity.ToTable("audit_events_202603");

            entity.HasIndex(e => e.occurred_at, "audit_events_202603_occurred_at_idx").HasMethod("brin");

            entity.HasIndex(e => new { e.user_id, e.occurred_at }, "audit_events_202603_user_id_occurred_at_idx").IsDescending(false, true);

            entity.Property(e => e.id).HasDefaultValueSql("(gen_random_uuid())::text");
        });

        modelBuilder.Entity<audit_events_202604>(entity =>
        {
            entity.HasKey(e => new { e.occurred_at, e.id }).HasName("audit_events_202604_pkey");

            entity.ToTable("audit_events_202604");

            entity.HasIndex(e => e.occurred_at, "audit_events_202604_occurred_at_idx").HasMethod("brin");

            entity.HasIndex(e => new { e.user_id, e.occurred_at }, "audit_events_202604_user_id_occurred_at_idx").IsDescending(false, true);

            entity.Property(e => e.id).HasDefaultValueSql("(gen_random_uuid())::text");
        });

        modelBuilder.Entity<audit_events_202605>(entity =>
        {
            entity.HasKey(e => new { e.occurred_at, e.id }).HasName("audit_events_202605_pkey");

            entity.ToTable("audit_events_202605");

            entity.HasIndex(e => e.occurred_at, "audit_events_202605_occurred_at_idx").HasMethod("brin");

            entity.HasIndex(e => new { e.user_id, e.occurred_at }, "audit_events_202605_user_id_occurred_at_idx").IsDescending(false, true);

            entity.Property(e => e.id).HasDefaultValueSql("(gen_random_uuid())::text");
        });

        modelBuilder.Entity<audit_events_202606>(entity =>
        {
            entity.HasKey(e => new { e.occurred_at, e.id }).HasName("audit_events_202606_pkey");

            entity.ToTable("audit_events_202606");

            entity.HasIndex(e => e.occurred_at, "audit_events_202606_occurred_at_idx").HasMethod("brin");

            entity.HasIndex(e => new { e.user_id, e.occurred_at }, "audit_events_202606_user_id_occurred_at_idx").IsDescending(false, true);

            entity.Property(e => e.id).HasDefaultValueSql("(gen_random_uuid())::text");
        });

        modelBuilder.Entity<audit_events_default>(entity =>
        {
            entity.HasKey(e => new { e.occurred_at, e.id }).HasName("audit_events_default_pkey");

            entity.ToTable("audit_events_default");

            entity.HasIndex(e => e.occurred_at, "audit_events_default_occurred_at_idx").HasMethod("brin");

            entity.HasIndex(e => new { e.user_id, e.occurred_at }, "audit_events_default_user_id_occurred_at_idx").IsDescending(false, true);

            entity.Property(e => e.id).HasDefaultValueSql("(gen_random_uuid())::text");
        });

        modelBuilder.Entity<branch>(entity =>
        {
            entity.HasKey(e => e.id).HasName("branches_pkey");

            entity.Property(e => e.created_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(3) without time zone");
            entity.Property(e => e.deleted_at).HasColumnType("timestamp(3) without time zone");
            entity.Property(e => e.established_at).HasColumnType("timestamp(3) without time zone");
            entity.Property(e => e.updated_at).HasColumnType("timestamp(3) without time zone");
        });

        modelBuilder.Entity<brand>(entity =>
        {
            entity.HasKey(e => e.id).HasName("brands_pkey");

            entity.HasIndex(e => e.alias, "brands_alias_key").IsUnique();

            entity.HasIndex(e => e.name, "brands_name_key").IsUnique();

            entity.Property(e => e.created_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(3) without time zone");
            entity.Property(e => e.deletedAt).HasColumnType("timestamp(3) without time zone");
            entity.Property(e => e.updated_at).HasColumnType("timestamp(3) without time zone");
        });

        modelBuilder.Entity<category>(entity =>
        {
            entity.HasKey(e => e.id).HasName("categories_pkey");

            entity.HasIndex(e => e.alias, "categories_alias_key").IsUnique();

            entity.HasIndex(e => e.name, "categories_name_key").IsUnique();

            entity.Property(e => e.created_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(3) without time zone");
            entity.Property(e => e.deletedAt).HasColumnType("timestamp(3) without time zone");
            entity.Property(e => e.updated_at).HasColumnType("timestamp(3) without time zone");
        });

        modelBuilder.Entity<inventory_item>(entity =>
        {
            entity.HasKey(e => e.id).HasName("inventory_items_pkey");

            entity.HasIndex(e => new { e.stock_id, e.stock_item_id }, "inventory_items_stock_id_stock_item_id_key").IsUnique();

            entity.Property(e => e.created_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(3) without time zone");
            entity.Property(e => e.updated_at).HasColumnType("timestamp(3) without time zone");

            entity.HasOne(d => d.stock).WithMany(p => p.inventory_items)
                .HasForeignKey(d => d.stock_id)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("inventory_items_stock_id_fkey");

            entity.HasOne(d => d.stock_item).WithMany(p => p.inventory_items)
                .HasForeignKey(d => d.stock_item_id)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("inventory_items_stock_item_id_fkey");
        });

        modelBuilder.Entity<location>(entity =>
        {
            entity.HasKey(e => e.id).HasName("locations_pkey");

            entity.Property(e => e.created_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(3) without time zone");
            entity.Property(e => e.deletedAt).HasColumnType("timestamp(3) without time zone");
            entity.Property(e => e.updated_at).HasColumnType("timestamp(3) without time zone");
        });

        modelBuilder.Entity<movement>(entity =>
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
        });

        modelBuilder.Entity<oauth_account>(entity =>
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
        });

        modelBuilder.Entity<password>(entity =>
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
        });

        modelBuilder.Entity<permission>(entity =>
        {
            entity.HasKey(e => e.id).HasName("permissions_pkey");

            entity.HasIndex(e => e.alias, "permissions_alias_key").IsUnique();

            entity.Property(e => e.created_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(3) without time zone");
            entity.Property(e => e.deletedAt).HasColumnType("timestamp(3) without time zone");
            entity.Property(e => e.updated_at).HasColumnType("timestamp(3) without time zone");
        });

        modelBuilder.Entity<product>(entity =>
        {
            entity.HasKey(e => e.id).HasName("products_pkey");

            entity.HasIndex(e => e.alias, "products_alias_key").IsUnique();

            entity.HasIndex(e => e.description_tsvector, "products_description_tsvector_idx").HasMethod("gin");

            entity.HasIndex(e => e.name, "products_name_key").IsUnique();

            entity.HasIndex(e => e.name_tsvector, "products_name_tsvector_idx").HasMethod("gin");

            entity.HasIndex(e => e.sku, "products_sku_key").IsUnique();

            entity.Property(e => e.created_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(3) without time zone");
            entity.Property(e => e.deletedAt).HasColumnType("timestamp(3) without time zone");
            entity.Property(e => e.updated_at).HasColumnType("timestamp(3) without time zone");

            entity.HasOne(d => d.brand).WithMany(p => p.products)
                .HasForeignKey(d => d.brand_id)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("products_brand_id_fkey");

            entity.HasOne(d => d.subcategory).WithMany(p => p.products)
                .HasForeignKey(d => d.subcategory_id)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("products_subcategory_id_fkey");
        });

        modelBuilder.Entity<product_characteristic>(entity =>
        {
            entity.HasKey(e => e.id).HasName("product_characteristics_pkey");

            entity.Property(e => e.created_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(3) without time zone");
            entity.Property(e => e.deletedAt).HasColumnType("timestamp(3) without time zone");
            entity.Property(e => e.updated_at).HasColumnType("timestamp(3) without time zone");

            entity.HasOne(d => d.product).WithMany(p => p.product_characteristics)
                .HasForeignKey(d => d.productId)
                .HasConstraintName("product_characteristics_productId_fkey");
        });

        modelBuilder.Entity<product_image>(entity =>
        {
            entity.HasKey(e => e.id).HasName("product_images_pkey");

            entity.Property(e => e.created_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(3) without time zone");
            entity.Property(e => e.deletedAt).HasColumnType("timestamp(3) without time zone");
            entity.Property(e => e.updated_at).HasColumnType("timestamp(3) without time zone");

            entity.HasOne(d => d.product).WithMany(p => p.product_images)
                .HasForeignKey(d => d.productId)
                .HasConstraintName("product_images_productId_fkey");
        });

        modelBuilder.Entity<role>(entity =>
        {
            entity.HasKey(e => e.id).HasName("roles_pkey");

            entity.HasIndex(e => e.name, "roles_name_key").IsUnique();

            entity.Property(e => e.created_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(3) without time zone");
            entity.Property(e => e.deletedAt).HasColumnType("timestamp(3) without time zone");
            entity.Property(e => e.updated_at).HasColumnType("timestamp(3) without time zone");
        });

        modelBuilder.Entity<role_permission>(entity =>
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
        });

        modelBuilder.Entity<snapshot>(entity =>
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
        });

        modelBuilder.Entity<stock>(entity =>
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
        });

        modelBuilder.Entity<stock_item>(entity =>
        {
            entity.HasKey(e => e.id).HasName("stock_items_pkey");

            entity.Property(e => e.created_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(3) without time zone");
            entity.Property(e => e.deletedAt).HasColumnType("timestamp(3) without time zone");
            entity.Property(e => e.updated_at).HasColumnType("timestamp(3) without time zone");
        });

        modelBuilder.Entity<subcategory>(entity =>
        {
            entity.HasKey(e => e.id).HasName("subcategories_pkey");

            entity.HasIndex(e => e.alias, "subcategories_alias_key").IsUnique();

            entity.HasIndex(e => new { e.name, e.parentId }, "subcategories_name_parentId_key").IsUnique();

            entity.Property(e => e.created_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(3) without time zone");
            entity.Property(e => e.deletedAt).HasColumnType("timestamp(3) without time zone");
            entity.Property(e => e.updated_at).HasColumnType("timestamp(3) without time zone");

            entity.HasOne(d => d.parent).WithMany(p => p.subcategories)
                .HasForeignKey(d => d.parentId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("subcategories_parentId_fkey");
        });

        modelBuilder.Entity<user>(entity =>
        {
            entity.HasKey(e => e.id).HasName("users_pkey");

            entity.HasIndex(e => e.email, "users_email_key").IsUnique();

            entity.Property(e => e.created_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(3) without time zone");
            entity.Property(e => e.deletedAt).HasColumnType("timestamp(3) without time zone");
            entity.Property(e => e.updated_at).HasColumnType("timestamp(3) without time zone");
        });

        modelBuilder.Entity<user_role>(entity =>
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
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
