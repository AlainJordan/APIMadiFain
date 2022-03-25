using System;
using System.Collections.Generic;

#nullable disable

namespace apiMF.Models
{
    public partial class Materiaprima
    {
        public int CategoriaMateriaPrima { get; set; }
        public string ClaveMateriaPrima { get; set; }
        public string DescripcionMateriaPrima { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdCategoriaMateriaPrima { get; set; }
        public int IdMateriaPrima { get; set; }
        public string Imagen { get; set; }
        public string NombreMateriaPrima { get; set; }
        public double Stock { get; set; }
        public decimal? UnidadMedida { get; set; }
    }
}
