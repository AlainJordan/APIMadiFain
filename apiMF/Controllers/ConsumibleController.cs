using apiMF.Models;
using apiMF.Models.Common;
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
    public class ConsumibleController : ControllerBase
    {
        private readonly PostDbContext context;
        private readonly IMapper mapper;
        private readonly IAlmacenadorArchivos almacenadorArchivos;
        private readonly string contenedor = "consumibles";


        public ConsumibleController(PostDbContext context,
                                                IMapper mapper,
                                                IAlmacenadorArchivos almacenadorArchivos)
        {
            this.context = context;
            this.mapper = mapper;
            this.almacenadorArchivos = almacenadorArchivos;

        }

        [HttpGet]
        public async Task<ActionResult<List<ConsumibleModificado>>> get()
        {
            List<ConsumibleModificado> consumible = new List<ConsumibleModificado>();
            List<Categoriaconsumible> categoriaConsumible = new List<Categoriaconsumible>();
            foreach (var CConsumible in context.Categoriaconsumibles)
            {
                categoriaConsumible.Add(CConsumible);

            }
            //Respuesta oRespuesta = new Respuesta();
            //oRespuesta.Exito = 1;
            try
            {
                foreach (var item in context.Consumibles)
                {
                    foreach (var CConsumible in categoriaConsumible)
                    {
                        if (item.IdCategoriaConsumible == CConsumible.IdCategoriaConsumibles.ToString())
                        {
                            ConsumibleModificado oConsumible = new ConsumibleModificado();
                            oConsumible.ClaveConsumible = item.ClaveConsumible;
                            oConsumible.DescripcionConsumible = item.DescripcionConsumible;
                            oConsumible.FechaRegistro = item.FechaRegistro;
                            oConsumible.IdCategoriaConsumible = CConsumible.NombreCategoriaConsumibles;
                            oConsumible.IdConsumible = item.IdConsumible;
                            oConsumible.Imagen = item.Imagen;
                            oConsumible.NombreConsumible = item.NombreConsumible;
                            oConsumible.Stock = item.Stock;
                            oConsumible.UnidadMedida = item.UnidadMedida;
                            consumible.Add(oConsumible);
                            break;
                        }

                    }
                }

                return consumible;
                //return await context.Consumibles.ToListAsync();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }

        }
        
        [HttpPost]
        public async Task<ActionResult> Post([FromForm] ConsumibleCreacionDTO consumibleCreacionDTO)
        {
            try
            {
                var consumible = mapper.Map<Consumible>(consumibleCreacionDTO);
                if (consumibleCreacionDTO.Imagen != null)
                {
                    consumible.Imagen = await almacenadorArchivos.GuardarArchivo(contenedor, consumibleCreacionDTO.Imagen);
                }
                context.Add(consumible);
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
        public async Task<ActionResult> Put(int id, [FromForm] ConsumibleCreacionDTO consumibleCreacionDTO)
        {
            try
            {
                var consumible = await context.Consumibles.FirstOrDefaultAsync(x => x.IdConsumible == id);
                if (consumible == null)
                {
                    return NotFound();
                }
                consumible = mapper.Map(consumibleCreacionDTO, consumible);
                if (consumibleCreacionDTO.Imagen != null)
                {
                    consumible.Imagen = await almacenadorArchivos.EditarArchivo(contenedor, consumibleCreacionDTO.Imagen, consumible.Imagen);
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
        public async Task<ActionResult<ConsumibleRequest>>Get(int id)
        {

            try
            {
                var consumible = await context.Consumibles.FirstOrDefaultAsync(x => x.IdConsumible == id);
                if (consumible == null)
                {
                    return NotFound();
                }
                return mapper.Map<ConsumibleRequest>(consumible);
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
                var consumible = await context.Consumibles.FirstOrDefaultAsync(x => x.IdConsumible == id);
                if (consumible == null)
                {
                    return NotFound();
                }
                context.Remove(consumible);
                await context.SaveChangesAsync();
                await almacenadorArchivos.BorrarArchivo(consumible.Imagen, contenedor);
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
