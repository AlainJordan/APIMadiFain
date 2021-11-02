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
    public class HerramientumController : ControllerBase
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
                    var lst = db.Herramienta.OrderByDescending(d => d.IdHerramienta).ToList();
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
        public IActionResult Add(HerramientumRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (PostDbContext db = new PostDbContext())
                {
                    Herramientum oHerramienta = new Herramientum();
                    oHerramienta.ClaveHerramienta = oModel.ClaveHerramienta;
                    oHerramienta.DescripcionHerramienta = oModel.DescripcionHerramienta;
                    oHerramienta.FechaRegistro = oModel.FechaRegistro;
                    oHerramienta.IdCategoriaHerramienta = oModel.IdCategoriaHerramienta;
                    oHerramienta.Imagen = oModel.Imagen;
                    oHerramienta.NombreHerramienta = oModel.NombreHerramienta;
                    oHerramienta.Stock = oModel.Stock;
                    db.Herramienta.Add(oHerramienta);
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
        public IActionResult Edit(HerramientumRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (PostDbContext db = new PostDbContext())
                {
                    Herramientum oHerramienta = db.Herramienta.Find(oModel.IdHerramienta);
                    oHerramienta.ClaveHerramienta = oModel.ClaveHerramienta;
                    oHerramienta.DescripcionHerramienta = oModel.DescripcionHerramienta;
                    oHerramienta.FechaRegistro = oModel.FechaRegistro;
                    oHerramienta.IdCategoriaHerramienta = oModel.IdCategoriaHerramienta;
                    oHerramienta.Imagen = oModel.Imagen;
                    oHerramienta.NombreHerramienta = oModel.NombreHerramienta;
                    oHerramienta.Stock = oModel.Stock;
                    db.Entry(oHerramienta).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                    Herramientum oHerramienta = db.Herramienta.Find(Id);
                    db.Remove(oHerramienta);
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
