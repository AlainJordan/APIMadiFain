using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiMF.Models.Request
{
    public class MateriaPrimaCreacionDTO
    {
        public int CategoriaMateriaPrima { get; set; }
        public string ClaveMateriaPrima { get; set; }
        public string DescripcionMateriaPrima { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdCategoriaMateriaPrima { get; set; }
        public IFormFile Imagen { get; set; }
        public string NombreMateriaPrima { get; set; }
        public double Stock { get; set; }
        public decimal? UnidadMedida { get; set; }
    }
}
