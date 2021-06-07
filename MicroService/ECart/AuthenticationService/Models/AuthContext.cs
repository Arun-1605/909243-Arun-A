using System;
using System.Data.Entity;
using System.Linq;

namespace AuthenticationService.Models
{
    public class AuthContext : DbContext
    {
        
        public AuthContext()
            : base("name=AuthContext")
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

    }

    
}