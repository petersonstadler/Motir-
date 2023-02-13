using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace backend_api.Data
{
    public class AppPrincipalContext : IdentityDbContext
    {
        public AppPrincipalContext(DbContextOptions<AppPrincipalContext> options) : base(options)
        {
            
        }
    }
}