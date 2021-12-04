using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiMF.Models.Request
{
    public class ProductoTerminadoCreacionDTO
    {
        public int IdProductoTerminado { get; set; }
        public string DescripcionProductoTerminado { get; set; }
        public string Empresa { get; set; }
        public DateTime? FechaLlegada { get; set; }
        public int IdCliente { get; set; }
        public string NombreProductoTerminado { get; set; }
        public string Status { get; set; }
        public double Stock { get; set; }
    }
}
