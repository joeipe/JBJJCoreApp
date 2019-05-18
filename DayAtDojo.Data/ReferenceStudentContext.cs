using DayAtDojo.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DayAtDojo.Data
{
    public class ReferenceStudentContext : DbContext
    {
        public ReferenceStudentContext(DbContextOptions<ReferenceStudentContext> options)
            : base(options)
        {

        }

        public DbSet<PersonSparringPartner> PersonSparringPartners { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Student");
            modelBuilder.Entity<PersonSparringPartner>().ToTable("PersonList");
            base.OnModelCreating(modelBuilder);
        }
    }
}
