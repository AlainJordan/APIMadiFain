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
    public class CategoriaConsumibleController : ControllerBase
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
                    var lst = db.Categoriaconsumibles.OrderByDescending(d => d.IdCategoriaConsumibles).ToList();
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
        public IActionResult Add(CategoriaConsumibleRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (PostDbContext db = new PostDbContext())
                {
                    Categoriaconsumible oCategoriaConsumible = new Categoriaconsumible();
                    oCategoriaConsumible.Descripcion = oModel.Descripcion;
                    oCategoriaConsumible.NombreCategoriaConsumibles = oModel.NombreCategoriaConsumibles;
                    db.Categoriaconsumibles.Add(oCategoriaConsumible);
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
        public IActionResult Edit(CategoriaConsumibleRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (PostDbContext db = new PostDbContext())
                {
                    Categoriaconsumible oCategoriaConsumible = db.Categoriaconsumibles.Find(oModel.IdCategoriaConsumibles);
                    oCategoriaConsumible.Descripcion = oModel.Descripcion;
                    oCategoriaConsumible.NombreCategoriaConsumibles = oModel.NombreCategoriaConsumibles;
                    db.Entry(oCategoriaConsumible).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                    Categoriaconsumible oCategoriaConsumible = db.Categoriaconsumibles.Find(Id);
                    db.Remove(oCategoriaConsumible);
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
