using System;
using System.Collections.Generic;

#nullable disable

namespace apiMF.Models
{
    public partial class Herramientum
    {
        public string ClaveHerramienta { get; set; }
        public string DescripcionHerramienta { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdCategoriaHerramienta { get; set; }
        public int IdHerramienta { get; set; }
        public string Imagen { get; set; }
        public string NombreHerramienta { get; set; }
        public double Stock { get; set; }
    }
}
