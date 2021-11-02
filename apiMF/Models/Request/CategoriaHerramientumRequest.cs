using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiMF.Models.Request
{
    public class CategoriaHerramientumRequest
    {
        public int IdCategoriaHerramienta { get; set; }
        public string Descripcion { get; set; }
        public string NombreCategoriaHerramienta { get; set; }
    }
}
