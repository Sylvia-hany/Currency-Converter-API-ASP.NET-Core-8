using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CurrencyConvertor.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Conversion> Conversions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Conversion>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.FromCurrency)
                      .IsRequired()
                      .HasMaxLength(3)
                      .IsFixedLength(true);

                entity.Property(e => e.ToCurrency)
                      .IsRequired()
                      .HasMaxLength(3)
                      .IsFixedLength(true);

                entity.Property(e => e.Amount)
                      .IsRequired()
                      .HasColumnType("decimal(18,6)");

                entity.Property(e => e.Rate)
                      .IsRequired()
                      .HasColumnType("decimal(18,6)");

                entity.Property(e => e.Result)
                      .IsRequired()
                      .HasColumnType("decimal(18,6)");

                // BaseEntity properties configuration
                entity.Property<DateTime>(e => e.CreatedAt)
                      .IsRequired()
                      .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property<bool>(e => e.IsDeleted)
                      .IsRequired()
                      .HasDefaultValue(false);
            });

            base.OnModelCreating(modelBuilder);
        }

        // Ensure CreatedAt is set in the application layer before saving.
        public override int SaveChanges()
        {
            SetCreatedTimestamps();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            SetCreatedTimestamps();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void SetCreatedTimestamps()
        {
            var utcNow = DateTime.UtcNow;

            foreach (var entry in ChangeTracker.Entries<BaseEntity>().Where(e => e.State == EntityState.Added))
            {
                if (entry.Entity.CreatedAt == default)
                {
                    entry.Entity.CreatedAt = utcNow;
                }
            }
        }
    }
}

