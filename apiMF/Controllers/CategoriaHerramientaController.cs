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
    public class CategoriaHerramientaController : ControllerBase
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
                    var lst = db.Categoriaherramienta.OrderByDescending(d => d.IdCategoriaHerramienta).ToList();
                    //oRespuesta.Exito = 1;
                    //oRespuesta.Data = lst;
                    return Ok(lst);

                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
                //oRespuesta.Mensaje = ex.Message;
            }
            //return Ok(oRespuesta);

        }
        [HttpPost]
        public IActionResult Add(CategoriaHerramientumRequest oModel)
        {
            //Respuesta oRespuesta = new Respuesta();
            try
            {
                using (PostDbContext db = new PostDbContext())
                {
                    Categoriaherramientum oCategoriaHerramienta = new Categoriaherramientum();
                    oCategoriaHerramienta.Descripcion = oModel.Descripcion;
                    oCategoriaHerramienta.NombreCategoriaHerramienta = oModel.NombreCategoriaHerramienta;
                    db.Categoriaherramienta.Add(oCategoriaHerramienta);
                    return Ok(db.SaveChanges());

                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
                //oRespuesta.Mensaje = ex.Message;
            }
            //return Ok(oRespuesta);

        }

        [HttpPut]
        public IActionResult Edit(CategoriaHerramientumRequest oModel)
        {
            //Respuesta oRespuesta = new Respuesta();
            try
            {
                using (PostDbContext db = new PostDbContext())
                {
                    Categoriaherramientum oCategoriaHerramienta = db.Categoriaherramienta.Find(oModel.IdCategoriaHerramienta);
                    oCategoriaHerramienta.Descripcion = oModel.Descripcion;
                    oCategoriaHerramienta.NombreCategoriaHerramienta = oModel.NombreCategoriaHerramienta;
                    db.Entry(oCategoriaHerramienta).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    return Ok(db.SaveChanges());

                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
                //oRespuesta.Mensaje = ex.Message;
            }
            //return Ok(oRespuesta);

        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            //Respuesta oRespuesta = new Respuesta();
            try
            {
                using (PostDbContext db = new PostDbContext())
                {
                    Categoriaherramientum oCategoriaHerramienta = db.Categoriaherramienta.Find(Id);
                    db.Remove(oCategoriaHerramienta);
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
            //return Ok(oRespuesta);


        }
    }
}
