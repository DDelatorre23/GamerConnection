using TermProject296N.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace TermProject296N.Repository
{
    public class AppIdentityDbContext : IdentityDbContext<User> {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options)
        : base(options) { }

        
    }
}
