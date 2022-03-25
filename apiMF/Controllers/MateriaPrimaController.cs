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
    public class MateriaPrimaController : ControllerBase
    {
        private readonly PostDbContext context;
        private readonly IMapper mapper;
        private readonly IAlmacenadorArchivos almacenadorArchivos;
        private readonly string contenedor = "materiaPrima";


        public MateriaPrimaController(PostDbContext context,
                                                IMapper mapper,
                                                IAlmacenadorArchivos almacenadorArchivos)
        {
            this.context = context;
            this.mapper = mapper;
            this.almacenadorArchivos = almacenadorArchivos;

        }

        [HttpGet]
        public async Task<ActionResult<List<Materiaprima>>> get()
        {
            //Respuesta oRespuesta = new Respuesta();
            //oRespuesta.Exito = 1;
            try
            {
                return await context.Materiaprimas.ToListAsync();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }

        }

        [HttpPost]
        public async Task<ActionResult> Post([FromForm] MateriaPrimaCreacionDTO materiaPrimaCreacionDTO)
        {
            try
            {
                var materiaPrima = mapper.Map<Consumible>(materiaPrimaCreacionDTO);
                if (materiaPrimaCreacionDTO.Imagen != null)
                {
                    materiaPrima.Imagen = await almacenadorArchivos.GuardarArchivo(contenedor, materiaPrimaCreacionDTO.Imagen);
                }
                context.Add(materiaPrima);
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
        public async Task<ActionResult> Put(int id, [FromForm] MateriaPrimaCreacionDTO materiaPrimaCreacionDTO)
        {
            try
            {
                var materiaPrima = await context.Materiaprimas.FirstOrDefaultAsync(x => x.IdMateriaPrima == id);
                if (materiaPrima == null)
                {
                    return NotFound();
                }
                materiaPrima = mapper.Map(materiaPrimaCreacionDTO, materiaPrima);
                if (materiaPrimaCreacionDTO.Imagen != null)
                {
                    materiaPrima.Imagen = await almacenadorArchivos.EditarArchivo(contenedor, materiaPrimaCreacionDTO.Imagen, materiaPrima.Imagen);
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
                var materiaPrima = await context.Materiaprimas.FirstOrDefaultAsync(x => x.IdMateriaPrima == id);
                if (materiaPrima == null)
                {
                    return NotFound();
                }
                return mapper.Map<ConsumibleRequest>(materiaPrima);
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
                var materiaPrima = await context.Materiaprimas.FirstOrDefaultAsync(x => x.IdMateriaPrima == id);
                if (materiaPrima == null)
                {
                    return NotFound();
                }
                context.Remove(materiaPrima);
                await context.SaveChangesAsync();
                await almacenadorArchivos.BorrarArchivo(materiaPrima.Imagen, contenedor);
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
