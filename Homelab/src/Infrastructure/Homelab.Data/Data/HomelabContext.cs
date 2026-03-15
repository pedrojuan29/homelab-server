using System;
using System.Collections.Generic;
using Homelab.Data.Data.Audit.Entities;
using Homelab.Data.Data.Catalog.Entities;
using Homelab.Data.Data.Identity.Entities;
using Homelab.Data.Data.Inventory.Entities;
using Homelab.Data.Data.Location.Entities;
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

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(HomelabContext).Assembly);

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
