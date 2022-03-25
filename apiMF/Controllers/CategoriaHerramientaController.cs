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
    public class CategoriaHerramientaController : ControllerBase
    {
        private readonly PostDbContext context;
        private readonly IMapper mapper;


        public CategoriaHerramientaController(PostDbContext context,
                                                IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<List<Categoriaherramienta>>> get()
        {
            //Respuesta oRespuesta = new Respuesta();
            //oRespuesta.Exito = 1;
            try
            {
                //var categorias = await context.Categoriaconsumibles.FirstOrDefaultAsync();
                //return mapper.Map<List<CategoriaConsumibleRequest>>(categorias);
                return await context.Categoriaherramienta.ToListAsync();
            }
            catch (Exception ex)
            {
                //oRespuesta.Mensaje = ex.Message;
                return BadRequest(ex.Message);
                throw;
            }


        }

        [HttpGet("{Id:int}")]
        public async Task<ActionResult<CategoriaHerramientumRequest>> get(int Id)
        {
            try
            {
                var categoria = await context.Categoriaherramienta.FirstOrDefaultAsync(x => x.IdCategoriaHerramienta == Id);
                if (categoria == null)
                {
                    return NotFound();
                }
                return mapper.Map<CategoriaHerramientumRequest>(categoria);
            }

            catch (Exception ex)
            {
                //oRespuesta.Mensaje = ex.Message;
                return BadRequest(ex.Message);
                throw;
            }
        }
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] CategoriaHerramientaCreacionDTO categoriaHerramientaCreacionDTO)
        {
            //Respuesta oRespuesta = new Respuesta();
            try
            {
                var categoria = mapper.Map<Categoriaherramienta>(categoriaHerramientaCreacionDTO);
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
        public async Task<ActionResult> Edit(int Id, [FromBody] CategoriaHerramientaCreacionDTO categoriaHerramientaCreacionDTO)
        {
            //Respuesta oRespuesta = new Respuesta();
            try
            {
                var categoria = await context.Categoriaherramienta.FirstOrDefaultAsync(x => x.IdCategoriaHerramienta == Id);
                if (categoria == null)
                {
                    return NotFound();
                }
                categoria = mapper.Map(categoriaHerramientaCreacionDTO, categoria);
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
                var existe = await context.Categoriaherramienta.AnyAsync(x => x.IdCategoriaHerramienta == Id);
                if (!existe)
                {
                    return NotFound();
                }
                context.Remove(new Categoriaherramienta() { IdCategoriaHerramienta = Id });
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
        //    //Respuesta oRespuesta = new Respuesta();
        //    //oRespuesta.Exito = 1;
        //    try
        //    {
        //        using (PostDbContext db = new PostDbContext())
        //        {
        //            var lst = db.Categoriaherramienta.OrderByDescending(d => d.IdCategoriaHerramienta).ToList();
        //            //oRespuesta.Exito = 1;
        //            //oRespuesta.Data = lst;
        //            return Ok(lst);

        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //        throw;
        //        //oRespuesta.Mensaje = ex.Message;
        //    }
        //    //return Ok(oRespuesta);

        //}
        //[HttpPost]
        //public IActionResult Add(CategoriaHerramientumRequest oModel)
        //{
        //    //Respuesta oRespuesta = new Respuesta();
        //    try
        //    {
        //        using (PostDbContext db = new PostDbContext())
        //        {
        //            Categoriaherramientum oCategoriaHerramienta = new Categoriaherramientum();
        //            oCategoriaHerramienta.Descripcion = oModel.Descripcion;
        //            oCategoriaHerramienta.NombreCategoriaHerramienta = oModel.NombreCategoriaHerramienta;
        //            db.Categoriaherramienta.Add(oCategoriaHerramienta);
        //            return Ok(db.SaveChanges());

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //        throw;
        //        //oRespuesta.Mensaje = ex.Message;
        //    }
        //    //return Ok(oRespuesta);

        //}

        //[HttpPut]
        //public IActionResult Edit(CategoriaHerramientumRequest oModel)
        //{
        //    //Respuesta oRespuesta = new Respuesta();
        //    try
        //    {
        //        using (PostDbContext db = new PostDbContext())
        //        {
        //            Categoriaherramientum oCategoriaHerramienta = db.Categoriaherramienta.Find(oModel.IdCategoriaHerramienta);
        //            oCategoriaHerramienta.Descripcion = oModel.Descripcion;
        //            oCategoriaHerramienta.NombreCategoriaHerramienta = oModel.NombreCategoriaHerramienta;
        //            db.Entry(oCategoriaHerramienta).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        //            return Ok(db.SaveChanges());

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //        throw;
        //        //oRespuesta.Mensaje = ex.Message;
        //    }
        //    //return Ok(oRespuesta);

        //}

        //[HttpDelete("{Id}")]
        //public IActionResult Delete(int Id)
        //{
        //    //Respuesta oRespuesta = new Respuesta();
        //    try
        //    {
        //        using (PostDbContext db = new PostDbContext())
        //        {
        //            Categoriaherramientum oCategoriaHerramienta = db.Categoriaherramienta.Find(Id);
        //            db.Remove(oCategoriaHerramienta);
        //            return Ok(db.SaveChanges());
        //            //oRespuesta.Exito = 1;

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //        throw;
        //        //oRespuesta.Mensaje = ex.Message;
        //    }
        //    //return Ok(oRespuesta);


        //}
    }
}
