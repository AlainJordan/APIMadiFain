using apiMF.Models;
using apiMF.Models.Request;
using apiMF.Models.Response;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace apiMF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaConsumibleController : ControllerBase
    {
        private readonly PostDbContext context;
        private readonly IMapper mapper;


        public CategoriaConsumibleController(PostDbContext context,
                                                IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<List<Categoriaconsumible>>> get()
        {
            //Respuesta oRespuesta = new Respuesta();
            //oRespuesta.Exito = 1;
            try
            {
                //var categorias = await context.Categoriaconsumibles.FirstOrDefaultAsync();
                //return mapper.Map<List<CategoriaConsumibleRequest>>(categorias);
                return await context.Categoriaconsumibles.ToListAsync();
            }
            catch (Exception ex)
            {
                //oRespuesta.Mensaje = ex.Message;
                return BadRequest(ex.Message);
                throw;
            }


        }

        [HttpGet("{Id:int}")]
        public async Task<ActionResult<CategoriaConsumibleRequest>> get(int Id)
        {
            try
            {
                var categoria = await context.Categoriaconsumibles.FirstOrDefaultAsync(x => x.IdCategoriaConsumibles == Id);
                if (categoria == null)
                {
                    return NotFound();
                }
                return mapper.Map<CategoriaConsumibleRequest>(categoria);
            }

            catch (Exception ex)
            {
                //oRespuesta.Mensaje = ex.Message;
                return BadRequest(ex.Message);
                throw;
            }
        }
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] CategoriaConsumibleCreacionDTO categoriaConsumibleCreacionDTO)
        {
            //Respuesta oRespuesta = new Respuesta();
            try
            {
                var categoria = mapper.Map<Categoriaconsumible>(categoriaConsumibleCreacionDTO);
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
        public async Task<ActionResult> Edit(int Id, [FromBody] CategoriaConsumibleCreacionDTO categoriaConsumibleCreacionDTO)
        {
            //Respuesta oRespuesta = new Respuesta();
            try
            {
                var categoria = await context.Categoriaconsumibles.FirstOrDefaultAsync(x => x.IdCategoriaConsumibles == Id);
                if (categoria == null)
                {
                    return NotFound();
                }
                categoria = mapper.Map(categoriaConsumibleCreacionDTO, categoria);
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
                var existe = await context.Categoriaconsumibles.AnyAsync(x => x.IdCategoriaConsumibles == Id);
                if (!existe)
                {
                    return NotFound();
                }
                context.Remove(new Categoriaconsumible() { IdCategoriaConsumibles = Id });
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
    }
}
