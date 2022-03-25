using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiMF.Models.Request
{
    public class ConsumibleCreacionDTO
    {
        public string ClaveConsumible { get; set; }
        public string DescripcionConsumible { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string IdCategoriaConsumible { get; set; }
        public IFormFile Imagen { get; set; }
        public string NombreConsumible { get; set; }
        public double Stock { get; set; }
        public string UnidadMedida { get; set; }
    }
}
