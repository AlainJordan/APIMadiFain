using apiMF.Models;
using apiMF.Models.Request;
using apiMF.Utilidades;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace apiMF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController:ControllerBase
    {
        private readonly PostDbContext context;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        private IUserService _userService;

        public UserController(PostDbContext context,
                                  IMapper mapper,
                                   IConfiguration configuration,
                                   IUserService userService
                                   )
        {
            this.context = context;
            this.mapper = mapper;
            this.configuration = configuration;
            _userService = userService;
        }
        [HttpPost("login")]
        public IActionResult Autentificar([FromBody] CredencialesUsuario credenciales)
        {
            var userResponse = _userService.Auth(credenciales);
            if (userResponse == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(userResponse);
            }
        }




        //var llave = Encoding.ASCII.GetBytes(_appSettings.Secreto);
        //var tokenDescriptor = new SecurityTokenDescriptor
        //{
        //    Subject = new System.Security.Claims.ClaimsIdentity(
        //        new Claim[]
        //        {
        //                new Claim(ClaimTypes.NameIdentifier,usuario.IdUsuarios.ToString()),
        //                new Claim(ClaimTypes.Email,usuario.Correo)
        //        }
        //        ),

        //};
        //var creds = new SigningCredentials(new SymmetricSecurityKey(llave), SecurityAlgorithms.HmacSha256Signature);
        //var expiracion = DateTime.UtcNow.AddDays(1);
        //var tokenq = new JwtSecurityToken(issuer: null, audience: null, expires: expiracion, signingCredentials: creds);


        //[HttpPost("login")]
        //public async Task<ActionResult<RespuestaAutenticacion>> Login([FromBody] CredencialesUsuario credenciales)
        //{
        //    var respuesta = this.userService.Auth(credenciales);


        //   var resultado = await context.Usuarios.Where(d => d.Correo == credenciales.Email && d.Password == credenciales.password).FirstOrDefaultAsync();
        //       // var resultado = await signInManager.PasswordSignInAsync(credenciales.Email, credenciales.password, isPersistent: false,
        //        //    lockoutOnFailure: false);

        //    if (resultado.Succeeded)
        //    {
        //        return await ConstruirToken(credenciales);

        //    }
        //    else
        //    {
        //        return BadRequest("login incorrecto");
        //    }
        //}





        //private async Task<RespuestaAutenticacion> ConstruirToken(CredencialesUsuario credenciales)
        //{
        //    var claims = new List<Claim>()
        //    {
        //        new Claim("email", credenciales.Email)
        //    };
        //    //var usuario = await context.Usuarios.Where(d => d.Correo == credenciales.Email).FindByEmailAsync();
        //    //var usuario = await userManager.FindByEmailAsync(credenciales.Email);
        //    //var claimsDB = await userManager.GetClaimsAsync(usuario);
        //    // claims.AddRange(claimsDB);

        //    Subject = new System.Security.Claims.ClaimsIdentity(
        //          new Claim[]
        //          {
        //                new Claim(ClaimTypes.NameIdentifier, credenciales.ToString()),
        //                new Claim(ClaimTypes.Email,usuario.Email)
        //          }
        //          );

        //    var llave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["llavejwt"]));
        //    var creds = new SigningCredentials(llave, SecurityAlgorithms.HmacSha256);
        //    var expiracion = DateTime.UtcNow.AddDays(1);
        //    var token = new JwtSecurityToken(issuer: null, audience: null, claims: claims, expires: expiracion, signingCredentials: creds);
        //    return new RespuestaAutenticacion()
        //    {
        //        Token = new JwtSecurityTokenHandler().WriteToken(token),
        //        Expiracion = expiracion
        //    };

        //}

    }
}
