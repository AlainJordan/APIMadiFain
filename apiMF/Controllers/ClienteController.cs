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
    public class ClienteController : ControllerBase
    {
        //[HttpGet]
        //public IActionResult get()
        //{
        //    //Respuesta oRespuesta = new Respuesta();
        //    //oRespuesta.Exito = 1;
        //    try
        //    {
        //        using (PostDbContext db = new PostDbContext())
        //        {
        //            var lst = db.Clientes.OrderByDescending(d => d.IdCliente).ToList();
        //            //oRespuesta.Exito = 1;
        //            //oRespuesta.Data = lst;
        //            return Ok(lst);

        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //        throw;
        //        //oRespuesta.Mensaje = ex.Message;
        //    }
        //    //return Ok(oRespuesta);

        //}
        //[HttpPost]
        //public IActionResult Add(ClienteRequest oModel)
        //{
        //    //Respuesta oRespuesta = new Respuesta();
        //    try
        //    {
        //        using (PostDbContext db = new PostDbContext())
        //        {
        //            Cliente oCliente = new Cliente();
        //            oCliente.Correo = oModel.Correo;
        //            oCliente.NombreCliente = oModel.NombreCliente;
        //            oCliente.ProductoTerminado = oModel.ProductoTerminado;
        //            oCliente.Telefono = oModel.Telefono;
        //            db.Clientes.Add(oCliente);
        //            return Ok(db.SaveChanges());

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //        throw;
        //        //oRespuesta.Mensaje = ex.Message;
        //    }
        //    //return Ok(oRespuesta);

        //}

        //[HttpPut]
        //public IActionResult Edit(ClienteRequest oModel)
        //{
        //    //Respuesta oRespuesta = new Respuesta();
        //    try
        //    {
        //        using (PostDbContext db = new PostDbContext())
        //        {
        //            Cliente oCliente = db.Clientes.Find(oModel.IdCliente);
        //            oCliente.Correo = oModel.Correo;
        //            oCliente.NombreCliente = oModel.NombreCliente;
        //            oCliente.ProductoTerminado = oModel.ProductoTerminado;
        //            oCliente.Telefono = oModel.Telefono;
        //            db.Entry(oCliente).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        //            return Ok(db.SaveChanges());

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //        throw;
        //        //oRespuesta.Mensaje = ex.Message;
        //    }
        //    //return Ok(oRespuesta);

        //}

        //[HttpDelete("{Id}")]
        //public IActionResult Delete(int Id)
        //{
        //    //Respuesta oRespuesta = new Respuesta();
        //    try
        //    {
        //        using (PostDbContext db = new PostDbContext())
        //        {
        //            Cliente oCliente = db.Clientes.Find(Id);
        //            db.Remove(oCliente);
        //            return Ok(db.SaveChanges());

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //        throw;
        //        //oRespuesta.Mensaje = ex.Message;
        //    }
        //    //return Ok(oRespuesta);


        //}
    }
}
