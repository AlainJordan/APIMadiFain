using apiMF.Models;
using apiMF.Models.Common;
using apiMF.Models.Request;
using AutoMapper.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace apiMF.Utilidades
{
    public class UserService : IUserService
    {
        private readonly PostDbContext context;
        
        private readonly AppSettings _appSettings;

        public UserService(PostDbContext context,
                            IOptions<AppSettings>appSettings)
        {
            this.context = context;
            _appSettings = appSettings.Value;
        }

        public RespuestaAutenticacion Auth(CredencialesUsuario model)
        {

            RespuestaAutenticacion respuestaAutenticacion = new RespuestaAutenticacion();
            var user = context.Usuarios.Where(d=>d.Correo== model.Email && d.Password == model.password).FirstOrDefault();
            if (user == null) return null;
            
            respuestaAutenticacion.Token = GetToken(user);

            return respuestaAutenticacion;
        }


        private string GetToken(Usuario usuario)
        {
            var tokernHandler = new JwtSecurityTokenHandler();
            var llave = Encoding.ASCII.GetBytes(_appSettings.Secreto);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier,usuario.IdUsuarios.ToString()),
                        new Claim(ClaimTypes.Email,usuario.Correo)
                    }
                    ),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(llave), SecurityAlgorithms.HmacSha256Signature)
                
            };
            var Expires = DateTime.UtcNow.AddDays(1);
            var token = tokernHandler.CreateToken(tokenDescriptor);
            return tokernHandler.WriteToken(token);


        }
    }


}
