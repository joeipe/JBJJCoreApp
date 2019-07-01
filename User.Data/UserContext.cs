using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using User.Domain;

namespace User.Data
{
    public class UserContext : IdentityDbContext<JBJJUser>
    {
        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema("User");
            base.OnModelCreating(builder);
        }
    }
}
