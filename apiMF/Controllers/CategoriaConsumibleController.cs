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
            //Respuesta oRespuesta = new Respuesta();
            //oRespuesta.Exito = 1;
            try
            {
                using (PostDbContext db = new PostDbContext())
                {
                    var lst = db.Categoriaconsumibles.OrderByDescending(d => d.IdCategoriaConsumibles).ToList();
                    //oRespuesta.Exito = 1;
                    //oRespuesta.Data = lst;
                    return Ok(lst);

                }

            }
            catch (Exception ex)
            {

                //oRespuesta.Mensaje = ex.Message;
                return BadRequest(ex.Message);
                throw;
            }
          

        }
        [HttpPost]
        public IActionResult Add(CategoriaConsumibleRequest oModel)
        {
            //Respuesta oRespuesta = new Respuesta();
            try
            {
                using (PostDbContext db = new PostDbContext())
                {
                    Categoriaconsumible oCategoriaConsumible = new Categoriaconsumible();
                    oCategoriaConsumible.Descripcion = oModel.Descripcion;
                    oCategoriaConsumible.NombreCategoriaConsumibles = oModel.NombreCategoriaConsumibles;
                    db.Categoriaconsumibles.Add(oCategoriaConsumible);
                    return Ok(db.SaveChanges());

                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
                //oRespuesta.Mensaje = ex.Message;
            }
            

        }

        [HttpPut]
        public IActionResult Edit(CategoriaConsumibleRequest oModel)
        {
            //Respuesta oRespuesta = new Respuesta();
            try
            {
                using (PostDbContext db = new PostDbContext())
                {
                    Categoriaconsumible oCategoriaConsumible = db.Categoriaconsumibles.Find(oModel.IdCategoriaConsumibles);
                    oCategoriaConsumible.Descripcion = oModel.Descripcion;
                    oCategoriaConsumible.NombreCategoriaConsumibles = oModel.NombreCategoriaConsumibles;
                    db.Entry(oCategoriaConsumible).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    return Ok(db.SaveChanges());
                    //oRespuesta.Exito = 1;

                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
                //oRespuesta.Mensaje = ex.Message;
            }
           

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
                    return Ok(db.SaveChanges()); 
                    //oRespuesta.Exito = 1;

                }
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
