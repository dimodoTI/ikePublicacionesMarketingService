using System.Linq;
using Microsoft.AspNetCore.Mvc;
using IkePublicacionesMarketingService.Models;
using Microsoft.AspNet.OData;

namespace IkePublicacionesMarketingService.Controllers
{

    public class PublicacionesQueryController : ControllerBase
    {
        private readonly IkePublicacionesMarketingServiceContext _context;


        public PublicacionesQueryController(IkePublicacionesMarketingServiceContext context)
        {
            _context = context;

        }

        // GET: api/Mascotas

        [EnableQuery(MaxExpansionDepth = 3)]
        public IQueryable<Publicacion> Get()
        {

            IQueryable<Publicacion> publicaciones = _context.Publicaciones.AsQueryable();


            return publicaciones;
        }
    }
}
