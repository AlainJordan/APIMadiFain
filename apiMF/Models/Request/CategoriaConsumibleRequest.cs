using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiMF.Models.Request
{
    public class CategoriaConsumibleRequest
    {
        public int IdCategoriaConsumibles { get; set; }
        public string Descripcion { get; set; }
        public string NombreCategoriaConsumibles { get; set; }
    }
}
