using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSMantenimiento.Models;
using WSMantenimiento.Models.ViewModels;
using WSMantenimiento.Response;

namespace WSMantenimiento.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreaController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAreas()
        {
            Respuesta respuesta = new Respuesta();
            respuesta.Exito = 0;

            try
            {
                using (mantenimiento_totalContext db = new mantenimiento_totalContext())
                {
                    var lst = from a in db.Areas
                              select new Area
                              {
                                  IdArea = a.IdArea,
                                  Descripcion = a.Descripcion,
                              };
                    respuesta.Exito = 1;
                    respuesta.Data = lst.ToList();
                }
            }
            catch (Exception ex)
            {
                respuesta.Mensaje = ex.Message;
            }
            return Ok(respuesta);
        }

        [HttpPost]
        public IActionResult AddArea(AreaRequest oModel)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                using (mantenimiento_totalContext db = new mantenimiento_totalContext())
                {
                    Area oArea = new Area();
                    oArea.IdArea = oModel.IdArea;
                    oArea.Descripcion = oModel.Descripcion;
                    db.Areas.Add(oArea);
                    db.SaveChanges();
                    respuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                respuesta.Mensaje = ex.Message;
            }
            return Ok(respuesta);
        }

        [HttpPut()]
        public IActionResult EditArea(AreaRequest oModel)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                using (mantenimiento_totalContext db = new mantenimiento_totalContext())
                {
                    Area oArea = db.Areas.Find(oModel.IdArea);

                    oArea.IdArea = oModel.IdArea;
                    oArea.Descripcion = oModel.Descripcion;

                    db.Entry(oArea).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    respuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                respuesta.Mensaje = ex.Message;
            }
            return Ok(respuesta);
        }

        [HttpDelete("{IdArea}")]
        public IActionResult Delete(int IdArea)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                using (mantenimiento_totalContext db = new mantenimiento_totalContext())
                {
                    Area oArea = db.Areas.Find(IdArea);
                    db.Remove(oArea);
                    db.SaveChanges();
                    respuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                respuesta.Mensaje = ex.Message;
            }
            return Ok(respuesta);
        }
    }
}
