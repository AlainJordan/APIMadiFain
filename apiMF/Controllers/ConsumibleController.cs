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
    public class ConsumibleController : ControllerBase
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
                    var lst = db.Consumibles.OrderByDescending(d => d.IdConsumible).ToList();
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
        public IActionResult Add(ConsumibleRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (PostDbContext db = new PostDbContext())
                {
                    Consumible oConsumible = new Consumible();
                    oConsumible.ClaveConsumible = oModel.ClaveConsumible;
                    oConsumible.DescripcionConsumible = oModel.DescripcionConsumible;
                    oConsumible.FechaRegistro = oModel.FechaRegistro;
                    oConsumible.IdCategoriaConsumible = oModel.IdCategoriaConsumible;
                    oConsumible.Imagen = oModel.Imagen;
                    oConsumible.NombreConsumible = oModel.NombreConsumible;
                    oConsumible.Stock = oModel.Stock;
                    oConsumible.UnidadMedida = oModel.UnidadMedida;
                    db.Consumibles.Add(oConsumible);
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
        public IActionResult Edit(ConsumibleRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (PostDbContext db = new PostDbContext())
                {
                    Consumible oConsumible = db.Consumibles.Find(oModel.IdConsumible);
                    oConsumible.ClaveConsumible = oModel.ClaveConsumible;
                    oConsumible.DescripcionConsumible = oModel.DescripcionConsumible;
                    oConsumible.FechaRegistro = oModel.FechaRegistro;
                    oConsumible.IdCategoriaConsumible = oModel.IdCategoriaConsumible;
                    oConsumible.Imagen = oModel.Imagen;
                    oConsumible.NombreConsumible = oModel.NombreConsumible;
                    oConsumible.Stock = oModel.Stock;
                    oConsumible.UnidadMedida = oModel.UnidadMedida;
                    db.Entry(oConsumible).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                    Consumible oConsumible = db.Consumibles.Find(Id);
                    db.Remove(oConsumible);
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
