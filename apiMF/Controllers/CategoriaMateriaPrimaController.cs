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
    public class CategoriaMateriaPrimaController : ControllerBase
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
                    var lst = db.Categoriamateriaprimas.OrderByDescending(d => d.IdCategoriaMateriaPrima).ToList();
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
        public IActionResult Add(CategoriaMateriaPrimaRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (PostDbContext db = new PostDbContext())
                {
                    Categoriamateriaprima oCategoriaMateriaPrima = new Categoriamateriaprima();
                    oCategoriaMateriaPrima.Descripcion = oModel.Descripcion;
                    oCategoriaMateriaPrima.NombreCategoriaMateriaPrima = oModel.NombreCategoriaMateriaPrima;
                    db.Categoriamateriaprimas.Add(oCategoriaMateriaPrima);
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
        public IActionResult Edit(CategoriaMateriaPrimaRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (PostDbContext db = new PostDbContext())
                {
                    Categoriamateriaprima oCategoriaMateriaPrima = db.Categoriamateriaprimas.Find(oModel.IdCategoriaMateriaPrima);
                    oCategoriaMateriaPrima.Descripcion = oModel.Descripcion;
                    oCategoriaMateriaPrima.NombreCategoriaMateriaPrima = oModel.NombreCategoriaMateriaPrima;
                    db.Entry(oCategoriaMateriaPrima).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                    Categoriamateriaprima oCategoriaMateriaPrima = db.Categoriamateriaprimas.Find(Id);
                    db.Remove(oCategoriaMateriaPrima);
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
