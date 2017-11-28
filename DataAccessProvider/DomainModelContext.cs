using System;
using System.Linq;
using DomainModel.Model;
using Microsoft.EntityFrameworkCore;

namespace DataAccessProvider
{
    public class DomainModelContext : DbContext
    {
        public DomainModelContext(DbContextOptions<DomainModelContext> options) :base(options)
        {
        }

        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Image>().HasKey(m => m.ImageId);

            // shadow properties
            builder.Entity<Image>().Property<DateTime>("UpdatedTimestamp");

            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();

            updateUpdatedProperty<Image>();

            return base.SaveChanges();
        }

        private void updateUpdatedProperty<T>() where T : class
        {
            var modifiedSourceInfo =
                ChangeTracker.Entries<T>()
                    .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            foreach (var entry in modifiedSourceInfo)
            {
                entry.Property("UpdatedTimestamp").CurrentValue = DateTime.UtcNow;
            }
        }
    }
}
