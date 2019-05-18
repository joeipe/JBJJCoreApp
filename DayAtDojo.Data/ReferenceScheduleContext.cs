using DayAtDojo.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DayAtDojo.Data
{
    public class ReferenceScheduleContext : DbContext
    {
        public ReferenceScheduleContext(DbContextOptions<ReferenceScheduleContext> options)
            : base(options)
        {

        }

        public DbSet<TimeTableClassAttended> TimeTableClassAttended { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Schedule");
            modelBuilder.Entity<TimeTableClassAttended>().ToTable("TimeTableList");
            base.OnModelCreating(modelBuilder);
        }
    }
}
