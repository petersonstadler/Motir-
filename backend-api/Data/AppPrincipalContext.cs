using backend_api.Models;
using Microsoft.EntityFrameworkCore;

namespace backend_api.Data
{
    public class AppPrincipalContext : DbContext
    {
        public AppPrincipalContext(DbContextOptions<AppPrincipalContext> options) : base(options)
        {
            
        }

        public DbSet<Patrocinador> Patrocinadores { get; set; }

    }
}