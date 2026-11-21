using Microsoft.EntityFrameworkCore;
using PCBForge.backend.Models;

namespace PCBForge.backend.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ComponentType> ComponentTypes { get; set; }
        public DbSet<ComponentPrice> ComponentPrices { get; set; }
        public DbSet<Component> Components { get; set; }
        public DbSet<Template> Templates { get; set; }
        public DbSet<TemplatePrice> TemplatePrices { get; set; }
        public DbSet<BomItem> BomItems { get; set; }
        public DbSet<Purchase> Purchases { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(u => u.CreatedAt)
                .HasDefaultValueSql("now()");

            modelBuilder.Entity<ComponentPrice>()
                        .Property(cp => cp.ValidFrom)
                        .HasDefaultValueSql("now()");

            modelBuilder.Entity<Template>()
                        .Property(t => t.CreatedAt)
                        .HasDefaultValueSql("now()");

            modelBuilder.Entity<Template>()
                        .Property(t => t.UpdatedAt)
                        .HasDefaultValueSql("now()");

            modelBuilder.Entity<TemplatePrice>()
                        .Property(tp => tp.ValidFrom)
                        .HasDefaultValueSql("now()");

            modelBuilder.Entity<Purchase>()
                        .Property(p => p.PurchasedAt)
                        .HasDefaultValueSql("now()");

            modelBuilder.Entity<Template>()
                .HasIndex(t => new { t.OwnerId, t.Name })
                .IsUnique();

            modelBuilder.Entity<BomItem>()
                .HasIndex(t => new { t.TemplateId, t.ComponentId })
                .IsUnique();

            modelBuilder.Entity<ComponentPrice>()
                .HasIndex(cp => new { cp.ComponentId, cp.ValidFrom })
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => new { u.Email })
                .IsUnique();

            modelBuilder.Entity<ComponentType>()
                .HasIndex(ct => new { ct.Name })
                .IsUnique();

            modelBuilder.Entity<Purchase>()
                .HasIndex(p => new { p.PaymentReference })
                .IsUnique();

            modelBuilder.Entity<Role>()
                .HasIndex(r => new { r.Name })
                .IsUnique();
        }
    }
}
