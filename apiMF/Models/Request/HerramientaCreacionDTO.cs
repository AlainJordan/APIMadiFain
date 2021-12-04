using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiMF.Models.Request
{
    public class HerramientaCreacionDTO
    {
        public string ClaveHerramienta { get; set; }
        public string DescripcionHerramienta { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdCategoriaHerramienta { get; set; }
        public IFormFile Imagen { get; set; }
        public string NombreHerramienta { get; set; }
        public double Stock { get; set; }
    }
}
