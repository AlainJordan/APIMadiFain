using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiMF.Models.Request
{
    public class CredencialesUsuario
    {
        //entidad para las credenciales del usuario
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        public string password { get; set; }
    }
}
