using apiMF.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiMF.Utilidades
{
    public interface IUserService
    {
        RespuestaAutenticacion Auth(CredencialesUsuario model);

    }
}
