using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;
using User.Domain;

namespace User.Data
{
    public class UserSeeder
    {
        private readonly UserContext _userContext;
        private readonly UserManager<JBJJUser> _userManager;

        public UserSeeder(UserContext userContext, UserManager<JBJJUser> userManager)
        {
            _userContext = userContext;
            _userManager = userManager;
        }

        public async Task SeedAsync()
        {
            _userContext.Database.EnsureCreated();

            // Seed the Main User
            string email = "joe.ipe@hotmail.com";
            JBJJUser user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                user = new JBJJUser()
                {
                    LastName = "Joe",
                    FirstName = "Ipe",
                    Email = email,
                    UserName = "jipe"
                };

                var result = await _userManager.CreateAsync(user, "Jbjj123$");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create user in Seeding");
                }
            }
        }
    }
}