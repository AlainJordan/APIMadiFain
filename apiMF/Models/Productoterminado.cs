using System;
using System.Collections.Generic;

#nullable disable

namespace apiMF.Models
{
    public partial class Productoterminado
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
