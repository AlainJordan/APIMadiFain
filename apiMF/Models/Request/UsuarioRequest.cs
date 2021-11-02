using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiMF.Models.Request
{
    public class UsuarioRequest
    {
        public int IdUsuarios { get; set; }
        public string Correo { get; set; }
        public string Nombre { get; set; }
        public string Password { get; set; }
        public int IdTipoUsuario { get; set; }
    }
}
