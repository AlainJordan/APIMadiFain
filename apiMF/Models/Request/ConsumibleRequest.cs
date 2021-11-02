using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiMF.Models.Request
{
    public class ConsumibleRequest
    {
        public string ClaveConsumible { get; set; }
        public string DescripcionConsumible { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdCategoriaConsumible { get; set; }
        public int IdConsumible { get; set; }
        public string Imagen { get; set; }
        public string NombreConsumible { get; set; }
        public double Stock { get; set; }
        public decimal UnidadMedida { get; set; }
    }
}
