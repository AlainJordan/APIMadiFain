using apiMF.Models;
using apiMF.Models.Request;
using apiMF.Models.Response;
using AutoMapper;
using Microsoft.AspNetCore.Http;
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
    public class TipoUsuarioController : ControllerBase
    {
        private readonly PostDbContext context;
        private readonly IMapper mapper;


        public TipoUsuarioController(PostDbContext context,
                                                IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<List<Tipousuario>>> get()
        {
            //Respuesta oRespuesta = new Respuesta();
            //oRespuesta.Exito = 1;
            try
            {
                //var categorias = await context.Categoriaconsumibles.FirstOrDefaultAsync();
                //return mapper.Map<List<CategoriaConsumibleRequest>>(categorias);
                return await context.Tipousuarios.ToListAsync();
            }
            catch (Exception ex)
            {
                //oRespuesta.Mensaje = ex.Message;
                return BadRequest(ex.Message);
                throw;
            }


        }

        [HttpGet("{Id:int}")]
        public async Task<ActionResult<TipoUsuarioRequest>> get(int Id)
        {
            try
            {
                var categoria = await context.Tipousuarios.FirstOrDefaultAsync(x => x.IdTipoUsuario == Id);
                if (categoria == null)
                {
                    return NotFound();
                }
                return mapper.Map<TipoUsuarioRequest>(categoria);
            }

            catch (Exception ex)
            {
                //oRespuesta.Mensaje = ex.Message;
                return BadRequest(ex.Message);
                throw;
            }
        }
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] TipoUsuarioCreacionDTO tipoUsuarioCreacionDTO)
        {
            //Respuesta oRespuesta = new Respuesta();
            try
            {
                var categoria = mapper.Map<Tipousuario>(tipoUsuarioCreacionDTO);
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
        public async Task<ActionResult> Edit(int Id, [FromBody] TipoUsuarioCreacionDTO tipoUsuarioCreacionDTO)
        {
            //Respuesta oRespuesta = new Respuesta();
            try
            {
                var categoria = await context.Tipousuarios.FirstOrDefaultAsync(x => x.IdTipoUsuario == Id);
                if (categoria == null)
                {
                    return NotFound();
                }
                categoria = mapper.Map(tipoUsuarioCreacionDTO, categoria);
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
                var existe = await context.Tipousuarios.AnyAsync(x => x.IdTipoUsuario == Id);
                if (!existe)
                {
                    return NotFound();
                }
                context.Remove(new Tipousuario() { IdTipoUsuario = Id });
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
        //[HttpGet]
        //public IActionResult get()
        //{
        //   // Respuesta oRespuesta = new Respuesta();
        //    //oRespuesta.Exito = 1;
        //    try
        //    {
        //        using (PostDbContext db = new PostDbContext())
        //        {
        //            var lst = db.Tipousuarios.OrderByDescending(d => d.IdTipoUsuario).ToList();
        //            //oRespuesta.Exito = 1;
        //            //oRespuesta.Data = lst;
        //            return Ok(lst);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //        throw;
        //    }

        //}
        //[HttpPost]
        //public IActionResult Add(TipoUsuarioRequest oModel)
        //{
        //    //Respuesta oRespuesta = new Respuesta();
        //    try
        //    {
        //        using (PostDbContext db = new PostDbContext())
        //        {
        //            Tipousuario oTipousuario = new Tipousuario();
        //            oTipousuario.TipoUsuario1 = oModel.TipoUsuario1;
        //            db.Tipousuarios.Add(oTipousuario);
        //            return Ok(db.SaveChanges());

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //        throw;
        //    }

        //}

        //[HttpPut]
        //public IActionResult Edit(TipoUsuarioRequest oModel)
        //{
        //    //Respuesta oRespuesta = new Respuesta();
        //    try
        //    {
        //        using (PostDbContext db = new PostDbContext())
        //        {
        //            Tipousuario oTipousuario = db.Tipousuarios.Find(oModel.IdTipoUsuario);
        //            oTipousuario.TipoUsuario1 = oModel.TipoUsuario1;
        //            db.Entry(oTipousuario).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        //            return Ok(db.SaveChanges());

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //        throw;
        //    }


        //}

        //[HttpDelete("{Id}")]
        //public IActionResult Delete(int Id)
        //{
        //    //Respuesta oRespuesta = new Respuesta();
        //    try
        //    {
        //        using (PostDbContext db = new PostDbContext())
        //        {
        //            Tipousuario oTipousuario = db.Tipousuarios.Find(Id);
        //            db.Remove(oTipousuario);
        //            return Ok(db.SaveChanges());

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //        throw;
        //    }
        //    //return Ok(oRespuesta);


        //}
    }
}
