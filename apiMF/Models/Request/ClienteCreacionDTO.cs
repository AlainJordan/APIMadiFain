using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiMF.Models.Request
{
    public class ClienteCreacionDTO
    {
        public string Correo { get; set; }
        public string NombreCliente { get; set; }
        public int? ProductoTerminado { get; set; }
        public string Telefono { get; set; }
    }
}
