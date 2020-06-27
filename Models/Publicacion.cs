using System;

namespace IkePublicacionesMarketingService.Models
{
    public class Publicacion
    {
        public long Id { get; set; }
        public string Tipo { get; set; }
        public string Imagen { get; set; }
        public string Titulo { get; set; }
        public string Leyenda { get; set; }
        public string BtnCaption { get; set; }
        public string Color { get; set; }
        public string Http { get; set; }
        public long Orden { get; set; }

    }
}
