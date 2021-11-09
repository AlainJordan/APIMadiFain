using apiMF.Models;
using apiMF.Models.Request;
using apiMF.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiMF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpGet]
        public IActionResult get()
        {
            //Respuesta oRespuesta = new Respuesta();
            //oRespuesta.Exito = 1;
            try
            {
                using (PostDbContext db = new PostDbContext())
                {
                    var lst = db.Usuarios.OrderByDescending(d => d.IdUsuarios).ToList();
                    //oRespuesta.Exito = 1;
                    //oRespuesta.Data = lst;
                    return Ok(lst);

                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }

        }
      

        [HttpPost]
        public IActionResult Add(UsuarioRequest oModel)
        {
            //Respuesta oRespuesta = new Respuesta();
            try
            {
                using (PostDbContext db = new PostDbContext())
                {
                    Usuario oUsuario = new Usuario();
                    oUsuario.Correo = oModel.Correo;
                    oUsuario.Nombre = oModel.Nombre;
                    oUsuario.Password = oModel.Password;
                    oUsuario.IdTipoUsuario = oModel.IdTipoUsuario;
                    db.Usuarios.Add(oUsuario);
                    return Ok(db.SaveChanges());

                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }

        }

        [HttpPut]
        public IActionResult Edit(UsuarioRequest oModel)
        {
            //Respuesta oRespuesta = new Respuesta();
            try
            {
                using (PostDbContext db = new PostDbContext())
                {
                    Usuario oUsuario = db.Usuarios.Find(oModel.IdUsuarios);
                    oUsuario.Correo = oModel.Correo;
                    oUsuario.Nombre = oModel.Nombre;
                    oUsuario.Password = oModel.Password;
                    oUsuario.IdTipoUsuario = oModel.IdTipoUsuario;
                    db.Entry(oUsuario).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    return Ok(db.SaveChanges());

                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }

        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            //Respuesta oRespuesta = new Respuesta();
            try
            {
                using (PostDbContext db = new PostDbContext())
                {
                    Usuario oUsuario = db.Usuarios.Find(Id);
                    db.Remove(oUsuario);
                    return Ok(db.SaveChanges());

                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }


        }
    }
}
