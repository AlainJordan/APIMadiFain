using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiMF.Models.Request
{
    public class CategoriaMateriaPrimaRequest
    {
        public string Descripcion { get; set; }
        public int IdCategoriaMateriaPrima { get; set; }
        public string NombreCategoriaMateriaPrima { get; set; }
    }
}
