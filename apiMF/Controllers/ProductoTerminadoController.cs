using apiMF.Models;
using apiMF.Models.Request;
using apiMF.Models.Response;
using apiMF.Utilidades;
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
    public class ProductoTerminadoController : ControllerBase
    {
        private readonly PostDbContext context;
        private readonly IMapper mapper;
        private readonly IAlmacenadorArchivos almacenadorArchivos;
        private readonly string contenedor = "productoTerminado";


        public ProductoTerminadoController(PostDbContext context,
                                                IMapper mapper,
                                                IAlmacenadorArchivos almacenadorArchivos)
        {
            this.context = context;
            this.mapper = mapper;
            this.almacenadorArchivos = almacenadorArchivos;

        }

        [HttpGet]
        public async Task<ActionResult<List<Productoterminado>>> get()
        {
            //Respuesta oRespuesta = new Respuesta();
            //oRespuesta.Exito = 1;
            try
            {
                return await context.Productoterminados.ToListAsync();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }

        }

        [HttpPost]
        public async Task<ActionResult> Post([FromForm] ProductoTerminadoCreacionDTO productoTerminadoCreacionDTO)
        {
            try
            {
                var productoTerminado = mapper.Map<Productoterminado>(productoTerminadoCreacionDTO);
                
                context.Add(productoTerminado);
                await context.SaveChangesAsync();
                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromForm] ProductoTerminadoCreacionDTO productoTerminadoCreacionDTO)
        {
            try
            {
                var productoTerminado = await context.Productoterminados.FirstOrDefaultAsync(x => x.IdProductoTerminado == id);
                if (productoTerminado == null)
                {
                    return NotFound();
                }
                productoTerminado = mapper.Map(productoTerminadoCreacionDTO, productoTerminado);
               
                await context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }

        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductoTerminadoRequest>> Get(int id)
        {

            try
            {
                var productoTerminado = await context.Productoterminados.FirstOrDefaultAsync(x => x.IdProductoTerminado == id);
                if (productoTerminado == null)
                {
                    return NotFound();
                }
                return mapper.Map<ProductoTerminadoRequest>(productoTerminado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {

            try
            {
                var productoTerminado = await context.Productoterminados.FirstOrDefaultAsync(x => x.IdProductoTerminado == id);
                if (productoTerminado == null)
                {
                    return NotFound();
                }
                context.Remove(productoTerminado);
                await context.SaveChangesAsync();
                
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }


        }
    }
}
