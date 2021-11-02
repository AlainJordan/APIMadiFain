﻿using apiMF.Models;
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
    public class TipoUsuarioController : ControllerBase
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
                    var lst = db.Tipousuarios.OrderByDescending(d => d.IdTipoUsuario).ToList();
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
        public IActionResult Add(TipoUsuarioRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (PostDbContext db = new PostDbContext())
                {
                    Tipousuario oTipousuario = new Tipousuario();
                    oTipousuario.TipoUsuario1 = oModel.TipoUsuario1;
                    db.Tipousuarios.Add(oTipousuario);
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
        public IActionResult Edit(TipoUsuarioRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (PostDbContext db = new PostDbContext())
                {
                    Tipousuario oTipousuario = db.Tipousuarios.Find(oModel.IdTipoUsuario);
                    oTipousuario.TipoUsuario1 = oModel.TipoUsuario1;
                    db.Entry(oTipousuario).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                    Tipousuario oTipousuario = db.Tipousuarios.Find(Id);
                    db.Remove(oTipousuario);
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
