using Microsoft.AspNetCore.Identity;
using System;

namespace User.Domain
{
    public class JBJJUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
