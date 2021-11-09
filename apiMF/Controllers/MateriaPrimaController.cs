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
    public class MateriaPrimaController : ControllerBase
    {
    //    [HttpGet]
    //    public IActionResult get()
    //    {
    //        //Respuesta oRespuesta = new Respuesta();
    //        //oRespuesta.Exito = 1;
    //        try
    //        {
    //            using (PostDbContext db = new PostDbContext())
    //            {
    //                var lst = db.Materiaprimas.OrderByDescending(d => d.IdMateriaPrima).ToList();
    //                //oRespuesta.Exito = 1;
    //                //oRespuesta.Data = lst;
    //                return Ok(lst);

    //            }

    //        }
    //        catch (Exception ex)
    //        {
    //            return BadRequest(ex.Message);
    //            throw;
    //        }
    //        //return Ok(oRespuesta);

    //    }
    //    [HttpPost]
    //    public IActionResult Add(MateriaPrimaRequest oModel)
    //    {
    //        //Respuesta oRespuesta = new Respuesta();
    //        try
    //        {
    //            using (PostDbContext db = new PostDbContext())
    //            {
    //                Materiaprima oMateriaPrima = new Materiaprima();
    //                oMateriaPrima.CategoriaMateriaPrima = oModel.CategoriaMateriaPrima;
    //                oMateriaPrima.DescripcionMateriaPrima = oModel.DescripcionMateriaPrima;
    //                oMateriaPrima.ClaveMateriaPrima = oModel.ClaveMateriaPrima;
    //                oMateriaPrima.FechaRegistro = oModel.FechaRegistro;
    //                oMateriaPrima.IdCategoriaMateriaPrima = oModel.IdCategoriaMateriaPrima;
    //                oMateriaPrima.Imagen = oModel.Imagen;
    //                oMateriaPrima.NombreMateriaPrima = oModel.NombreMateriaPrima;
    //                oMateriaPrima.Stock = oModel.Stock;
    //                oMateriaPrima.UnidadMedida = oModel.UnidadMedida;
    //                db.Materiaprimas.Add(oMateriaPrima);
    //                return Ok(db.SaveChanges());

    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            return BadRequest(ex.Message);
    //            throw;
    //        }
    //        //return Ok(oRespuesta);

    //    }

    //    [HttpPut]
    //    public IActionResult Edit(MateriaPrimaRequest oModel)
    //    {
    //        //Respuesta oRespuesta = new Respuesta();
    //        try
    //        {
    //            using (PostDbContext db = new PostDbContext())
    //            {
    //                Materiaprima oMateriaPrima = db.Materiaprimas.Find(oModel.IdMateriaPrima);
    //                oMateriaPrima.CategoriaMateriaPrima = oModel.CategoriaMateriaPrima;
    //                oMateriaPrima.DescripcionMateriaPrima = oModel.DescripcionMateriaPrima;
    //                oMateriaPrima.ClaveMateriaPrima = oModel.ClaveMateriaPrima;
    //                oMateriaPrima.FechaRegistro = oModel.FechaRegistro;
    //                oMateriaPrima.IdCategoriaMateriaPrima = oModel.IdCategoriaMateriaPrima;
    //                oMateriaPrima.Imagen = oModel.Imagen;
    //                oMateriaPrima.NombreMateriaPrima = oModel.NombreMateriaPrima;
    //                oMateriaPrima.Stock = oModel.Stock;
    //                oMateriaPrima.UnidadMedida = oModel.UnidadMedida;
    //                db.Entry(oMateriaPrima).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
    //                return Ok(db.SaveChanges());

    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            return BadRequest(ex.Message);
    //            throw;
    //        }
    //        //return Ok(oRespuesta);

    //    }

    //    [HttpDelete("{Id}")]
    //    public IActionResult Delete(int Id)
    //    {
    //        //Respuesta oRespuesta = new Respuesta();
    //        try
    //        {
    //            using (PostDbContext db = new PostDbContext())
    //            {
    //                Materiaprima oMateriaPrima = db.Materiaprimas.Find(Id);
    //                db.Remove(oMateriaPrima);
    //                return Ok(db.SaveChanges());

    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            return BadRequest(ex.Message);
    //            throw;
    //        }
    //        //return Ok(oRespuesta);


    //    }
    }
}
