using Microsoft.EntityFrameworkCore;

namespace IkePublicacionesMarketingService.Models
{
    public class IkePublicacionesMarketingServiceContext : DbContext
    {
        public IkePublicacionesMarketingServiceContext(DbContextOptions<IkePublicacionesMarketingServiceContext> options)
            : base(options)
        {
        }

        public DbSet<Publicacion> Publicaciones { get; set; }

    }
}
