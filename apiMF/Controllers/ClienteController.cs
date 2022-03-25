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
    public class ClienteController : ControllerBase
    {
        private readonly PostDbContext context;
        private readonly IMapper mapper;
        private readonly IAlmacenadorArchivos almacenadorArchivos;
        private readonly string contenedor = "clientes";


        public ClienteController(PostDbContext context,
                                                IMapper mapper,
                                                IAlmacenadorArchivos almacenadorArchivos)
        {
            this.context = context;
            this.mapper = mapper;
            this.almacenadorArchivos = almacenadorArchivos;

        }

        [HttpGet]
        public async Task<ActionResult<List<Cliente>>> get()
        {
            //Respuesta oRespuesta = new Respuesta();
            //oRespuesta.Exito = 1;
            try
            {
                return await context.Clientes.ToListAsync();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }

        }

        [HttpPost]
        public async Task<ActionResult> Post([FromForm] ClienteCreacionDTO clienteCreacionDTO)
        {
            try
            {
                var cliente = mapper.Map<Cliente>(clienteCreacionDTO);
                context.Add(cliente);
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
        public async Task<ActionResult> Put(int id, [FromForm] ClienteCreacionDTO clienteCreacionDTO)
        {
            try
            {
                var cliente = await context.Clientes.FirstOrDefaultAsync(x => x.IdCliente == id);
                if (cliente == null)
                {
                    return NotFound();
                }
                cliente = mapper.Map(clienteCreacionDTO, cliente);
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
        public async Task<ActionResult<ClienteRequest>> Get(int id)
        {

            try
            {
                var cliente = await context.Clientes.FirstOrDefaultAsync(x => x.IdCliente == id);
                if (cliente == null)
                {
                    return NotFound();
                }
                return mapper.Map<ClienteRequest>(cliente);
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
                var cliente = await context.Clientes.FirstOrDefaultAsync(x => x.IdCliente == id);
                if (cliente == null)
                {
                    return NotFound();
                }
                context.Remove(cliente);
                await context.SaveChangesAsync();
                //await almacenadorArchivos.BorrarArchivo(consumible.Imagen, contenedor);
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
