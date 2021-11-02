using System;
using System.Collections.Generic;

#nullable disable

namespace apiMF.Models
{
    public partial class Usuario
    {
        public int IdUsuarios { get; set; }
        public string Correo { get; set; }
        public string Nombre { get; set; }
        public string Password { get; set; }
        public int IdTipoUsuario { get; set; }
    }
}
