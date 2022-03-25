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
    public class HerramientumController : ControllerBase
    {
        private readonly PostDbContext context;
        private readonly IMapper mapper;
        private readonly IAlmacenadorArchivos almacenadorArchivos;
        private readonly string contenedor = "herramienta";


        public HerramientumController(PostDbContext context,
                                                IMapper mapper,
                                                IAlmacenadorArchivos almacenadorArchivos)
        {
            this.context = context;
            this.mapper = mapper;
            this.almacenadorArchivos = almacenadorArchivos;

        }

        [HttpGet]
        public async Task<ActionResult<List<Herramientum>>> get()
        {
            //Respuesta oRespuesta = new Respuesta();
            //oRespuesta.Exito = 1;
            try
            {
                return await context.Herramienta.ToListAsync();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }

        }

        [HttpPost]
        public async Task<ActionResult> Post([FromForm] HerramientaCreacionDTO herramientaCreacionDTO)
        {
            try
            {
                var herramienta = mapper.Map<Herramientum>(herramientaCreacionDTO);
                if (herramientaCreacionDTO.Imagen != null)
                {
                    herramienta.Imagen = await almacenadorArchivos.GuardarArchivo(contenedor, herramientaCreacionDTO.Imagen);
                }
                context.Add(herramienta);
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
        public async Task<ActionResult> Put(int id, [FromForm] HerramientaCreacionDTO herramientaCreacionDTO)
        {
            try
            {
                var herramienta = await context.Herramienta.FirstOrDefaultAsync(x => x.IdHerramienta == id);
                if (herramienta == null)
                {
                    return NotFound();
                }
                herramienta = mapper.Map(herramientaCreacionDTO, herramienta);
                if (herramientaCreacionDTO.Imagen != null)
                {
                    herramienta.Imagen = await almacenadorArchivos.EditarArchivo(contenedor, herramientaCreacionDTO.Imagen, herramienta.Imagen);
                }
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
        public async Task<ActionResult<ConsumibleRequest>> Get(int id)
        {

            try
            {
                var herramienta = await context.Herramienta.FirstOrDefaultAsync(x => x.IdHerramienta == id);
                if (herramienta == null)
                {
                    return NotFound();
                }
                return mapper.Map<ConsumibleRequest>(herramienta);
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
                var herramienta = await context.Herramienta.FirstOrDefaultAsync(x => x.IdHerramienta == id);
                if (herramienta == null)
                {
                    return NotFound();
                }
                context.Remove(herramienta);
                await context.SaveChangesAsync();
                await almacenadorArchivos.BorrarArchivo(herramienta.Imagen, contenedor);
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
