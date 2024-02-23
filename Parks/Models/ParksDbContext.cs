using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Parks.Models
{
    public class ParksDbContext : IdentityDbContext<ApplicationUser>
    {
        public ParksDbContext(DbContextOptions options) : base(options) { }

    }

}