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
    public class ProductoTerminadoController : ControllerBase
    {
        [HttpGet]
        public IActionResult get()
        {
            Respuesta oRespuesta = new Respuesta();
            oRespuesta.Exito = 1;
            try
            {
                using (PostDbContext db = new PostDbContext())
                {
                    var lst = db.Productoterminados.OrderByDescending(d => d.IdProductoTerminado).ToList();
                    oRespuesta.Exito = 1;
                    oRespuesta.Data = lst;

                }

            }
            catch (Exception ex)
            {

                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);

        }
        [HttpPost]
        public IActionResult Add(ProductoTerminadoRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (PostDbContext db = new PostDbContext())
                {
                    Productoterminado oProductoTerminado = new Productoterminado();
                    oProductoTerminado.DescripcionProductoTerminado = oModel.DescripcionProductoTerminado;
                    oProductoTerminado.Empresa = oModel.Empresa;
                    oProductoTerminado.FechaLlegada = oModel.FechaLlegada;
                    oProductoTerminado.IdCliente = oModel.IdCliente;
                    oProductoTerminado.NombreProductoTerminado = oModel.NombreProductoTerminado;
                    oProductoTerminado.Status = oModel.Status;
                    oProductoTerminado.Stock = oModel.Stock;
                    db.Productoterminados.Add(oProductoTerminado);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;

                }
            }
            catch (Exception ex)
            {

                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);

        }

        [HttpPut]
        public IActionResult Edit(ProductoTerminadoRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (PostDbContext db = new PostDbContext())
                {
                    Productoterminado oProductoTerminado = db.Productoterminados.Find(oModel.IdProductoTerminado);
                    oProductoTerminado.DescripcionProductoTerminado = oModel.DescripcionProductoTerminado;
                    oProductoTerminado.Empresa = oModel.Empresa;
                    oProductoTerminado.FechaLlegada = oModel.FechaLlegada;
                    oProductoTerminado.IdCliente = oModel.IdCliente;
                    oProductoTerminado.NombreProductoTerminado = oModel.NombreProductoTerminado;
                    oProductoTerminado.Status = oModel.Status;
                    oProductoTerminado.Stock = oModel.Stock;
                    db.Entry(oProductoTerminado).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    oRespuesta.Exito = 1;

                }
            }
            catch (Exception ex)
            {

                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);

        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (PostDbContext db = new PostDbContext())
                {
                    Productoterminado oProductoTerminado = db.Productoterminados.Find(Id);
                    db.Remove(oProductoTerminado);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;

                }
            }
            catch (Exception ex)
            {

                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);


        }
    }
}
