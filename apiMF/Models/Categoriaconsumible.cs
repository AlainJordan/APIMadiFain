using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiMF.Models
{
    public partial class Categoriaconsumible
    {
        public int IdCategoriaConsumibles { get; set; }
        public string Descripcion { get; set; }
        public string NombreCategoriaConsumibles { get; set; }
    }
}
