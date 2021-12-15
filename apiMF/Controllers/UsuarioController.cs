using apiMF.Models;
using apiMF.Models.Common;
using apiMF.Models.Request;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly PostDbContext context;
        private readonly IMapper mapper;


        public UsuarioController(PostDbContext context,
                                                IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<List<UsuarioModificado>>> get()
        {
            List<UsuarioModificado> usuario = new List<UsuarioModificado>();
            List<Tipousuario> tipoUsuario = new List<Tipousuario>();
             foreach (var TUsuario in context.Tipousuarios)
            {
                tipoUsuario.Add(TUsuario);

            }
            try
            {
                //var categorias = await context.Categoriaconsumibles.FirstOrDefaultAsync();
                //return mapper.Map<List<CategoriaConsumibleRequest>>(categorias);
                foreach (var item in context.Usuarios)
                {
                    foreach (var TUsuario in tipoUsuario)
                    {
                        if (item.IdTipoUsuario == TUsuario.IdTipoUsuario)
                        {
                            UsuarioModificado oUsuario = new UsuarioModificado();
                            oUsuario.IdUsuarios = item.IdUsuarios;
                            oUsuario.Correo = item.Correo;
                            oUsuario.Nombre = item.Nombre;
                            oUsuario.Password = item.Password;
                            oUsuario.IdTipoUsuario = TUsuario.TipoUsuario1;
                            usuario.Add(oUsuario);
                            break;
                        }

                    }
                }
            
                return  usuario;
            }
            catch (Exception ex)
            {
                //oRespuesta.Mensaje = ex.Message;
                return BadRequest(ex.Message);
                throw;
            }


        }

        [HttpGet("{Id:int}")]
        public async Task<ActionResult<UsuarioModificado>> get(int Id)
        {
            try
            {
                List<Tipousuario> tipoUsuario = new List<Tipousuario>();
                UsuarioModificado oUsuario = new UsuarioModificado();
                foreach (var TUsuario in context.Tipousuarios)
                {
                    tipoUsuario.Add(TUsuario);

                }
                var categoria = await context.Usuarios.FirstOrDefaultAsync(x => x.IdUsuarios == Id);
                if (categoria == null)
                {
                    return NotFound();
                }
                    foreach (var TUsuario in tipoUsuario)
                    {
                        if (categoria.IdTipoUsuario == TUsuario.IdTipoUsuario)
                        {
                      
                            oUsuario.IdUsuarios = categoria.IdUsuarios;
                            oUsuario.Correo = categoria.Correo;
                            oUsuario.Nombre = categoria.Nombre;
                            oUsuario.Password = categoria.Password;
                            oUsuario.IdTipoUsuario = TUsuario.TipoUsuario1;
                            break;
                        }

                    }
             
                return oUsuario;
            }

            catch (Exception ex)
            {
                //oRespuesta.Mensaje = ex.Message;
                return BadRequest(ex.Message);
                throw;
            }
        }
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] UsuarioCreacionDTO usuarioCreacionDTO)
        {
            //Respuesta oRespuesta = new Respuesta();
            try
            {
                var categoria = mapper.Map<Usuario>(usuarioCreacionDTO);
                context.Add(categoria);
                await context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
                //oRespuesta.Mensaje = ex.Message;
            }
        }

        [HttpPut("{Id:int}")]
        public async Task<ActionResult> Edit(int Id, [FromBody] UsuarioCreacionDTO usuarioCreacionDTO)
        {
            //Respuesta oRespuesta = new Respuesta();
            try
            {
                var categoria = await context.Usuarios.FirstOrDefaultAsync(x => x.IdUsuarios == Id);
                if (categoria == null)
                {
                    return NotFound();
                }
                categoria = mapper.Map(usuarioCreacionDTO, categoria);
                await context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
                //oRespuesta.Mensaje = ex.Message;
            }

        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> delete(int Id)
        {
            try
            {
                var existe = await context.Usuarios.AnyAsync(x => x.IdUsuarios == Id);
                if (!existe)
                {
                    return NotFound();
                }
                context.Remove(new Usuario() { IdUsuarios = Id });
                await context.SaveChangesAsync();
                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
                //oRespuesta.Mensaje = ex.Message;
            }


        }
        /*
        [HttpGet]
        public IActionResult get()
        {
            return Ok();
            //Respuesta oRespuesta = new Respuesta();
            //oRespuesta.Exito = 1;
            //try
            //{
            //    using (PostDbContext db = new PostDbContext())
            //    {
            //        var lst = db.Usuarios.OrderByDescending(d => d.IdUsuarios).ToList();
            //        //oRespuesta.Exito = 1;
            //        //oRespuesta.Data = lst;
            //        return Ok(lst);

            //    }

            //}
            //catch (Exception ex)
            //{
            //    return BadRequest(ex.Message);
            //    throw;
            //}

        }


        [HttpPost]
        public IActionResult Add(UsuarioRequest oModel)
        {
            return Ok();
            //Respuesta oRespuesta = new Respuesta();
            //try
            //{
            //    using (PostDbContext db = new PostDbContext())
            //    {
            //        Usuario oUsuario = new Usuario();
            //        oUsuario.Correo = oModel.Correo;
            //        oUsuario.Nombre = oModel.Nombre;
            //        oUsuario.Password = oModel.Password;
            //        oUsuario.IdTipoUsuario = oModel.IdTipoUsuario;
            //        db.Usuarios.Add(oUsuario);
            //        return Ok(db.SaveChanges());

            //    }
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest(ex.Message);
            //    throw;
            //}

        }

        [HttpPut]
        public IActionResult Edit(UsuarioRequest oModel)
        {
            return Ok();
            //Respuesta oRespuesta = new Respuesta();
            //try
            //{
            //    using (PostDbContext db = new PostDbContext())
            //    {
            //        Usuario oUsuario = db.Usuarios.Find(oModel.IdUsuarios);
            //        oUsuario.Correo = oModel.Correo;
            //        oUsuario.Nombre = oModel.Nombre;
            //        oUsuario.Password = oModel.Password;
            //        oUsuario.IdTipoUsuario = oModel.IdTipoUsuario;
            //        db.Entry(oUsuario).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            //        return Ok(db.SaveChanges());

            //    }
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest(ex.Message);
            //    throw;
            //}

        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            return Ok();
            //Respuesta oRespuesta = new Respuesta();
            //try
            //{
            //    using (PostDbContext db = new PostDbContext())
            //    {
            //        Usuario oUsuario = db.Usuarios.Find(Id);
            //        db.Remove(oUsuario);
            //        return Ok(db.SaveChanges());

            //    }
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest(ex.Message);
            //    throw;
            //}


        }*/
    }
}
