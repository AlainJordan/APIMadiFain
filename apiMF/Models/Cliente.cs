using System;
using System.Collections.Generic;

#nullable disable

namespace apiMF.Models
{
    public partial class Cliente
    {
        public string Correo { get; set; }
        public int IdCliente { get; set; }
        public string NombreCliente { get; set; }
        public int? ProductoTerminado { get; set; }
        public string Telefono { get; set; }
    }
}
