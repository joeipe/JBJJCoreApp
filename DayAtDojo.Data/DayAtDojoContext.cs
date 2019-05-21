using DayAtDojo.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace DayAtDojo.Data
{
    public class DayAtDojoContext : DbContext
    {
        public DayAtDojoContext(DbContextOptions<DayAtDojoContext> options)
            : base(options)
        {
        }

        public DbSet<Outcome> Outcomes { get; set; }
        public DbSet<Attendance> Attendance { get; set; }
        public DbSet<SparringDetails> SparringDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("DayAtDojo");
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                modelBuilder.Entity(entityType.Name).Property<DateTime>("CreatedDate");
                modelBuilder.Entity(entityType.Name).Property<DateTime>("UpdatedDate");
                modelBuilder.Entity(entityType.Name).Ignore("IsDirty");
            }
            modelBuilder.Ignore<TimeTableClassAttended>();
            modelBuilder.Ignore<PersonSparringPartner>();
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            var now = DateTime.Now;

            foreach (var changedEntity in ChangeTracker.Entries()
            .Where(e => e.State == EntityState.Added ||
                        e.State == EntityState.Modified))
            {
                switch (changedEntity.State)
                {
                    case EntityState.Added:
                        changedEntity.Property("CreatedDate").CurrentValue = now;
                        changedEntity.Property("UpdatedDate").CurrentValue = now;
                        break;

                    case EntityState.Modified:
                        changedEntity.Property("UpdatedDate").CurrentValue = now;
                        break;
                }
            }

            return base.SaveChanges();
        }
    }
}