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
    public class ActividadesCorrectivasController : ControllerBase
    {
        // GET: api/<RegistroActividadesController>
        [HttpGet]
        public IActionResult GetRegistroActividadesCorrectivas()
        {
            Respuesta respuesta = new Respuesta();
            respuesta.Exito = 0;

            try
            {
                using (mantenimiento_totalContext db = new mantenimiento_totalContext())
                {
                    var lst = from r in db.RegistroMantenimientoCorrectivos
                              select new RegistroMantenimientoCorrectivo
                              {
                                  Id = r.Id,
                                  IdOrden = r.IdOrden,
                                  IdMaquina = r.IdMaquina,
                                  IdTrabajador = r.IdTrabajador,
                                  TiempoParo = r.TiempoParo,
                                  Descripcion = r.Descripcion,
                                  Fecha = r.Fecha,
                                  IdTrabajadorNavigation = r.IdTrabajadorNavigation
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



        // POST api/<RegistroActividadesController>
        [HttpPost]
        public IActionResult AddActividadesCorrectivas(ActividadesCorrectivoRequest oModel)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                using (mantenimiento_totalContext db = new mantenimiento_totalContext())
                {
                    RegistroMantenimientoCorrectivo oActividad = new RegistroMantenimientoCorrectivo();
                    oActividad.IdOrden = oModel.idOrden;
                    oActividad.IdMaquina = oModel.idMaquina;
                    oActividad.IdTrabajador = oModel.idTrabajador;
                    oActividad.Descripcion = oModel.descripcion;
                    oActividad.Fecha = oModel.fecha;
                    db.RegistroMantenimientoCorrectivos.Add(oActividad);
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

        // PUT api/<RegistroActividadesController>/5
        [HttpPut()]
        public IActionResult EditActividadesCorrectivas(ActividadesCorrectivoRequest oModel)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                using (mantenimiento_totalContext db = new mantenimiento_totalContext())
                {
                    RegistroMantenimientoCorrectivo oActividad = db.RegistroMantenimientoCorrectivos.Find(oModel.id);

                    oActividad.IdOrden = oModel.idOrden;
                    oActividad.IdMaquina = oModel.idMaquina;
                    oActividad.IdTrabajador = oModel.idTrabajador;
                    oActividad.Descripcion = oModel.descripcion;
                    oActividad.Fecha = oModel.fecha;

                    db.Entry(oActividad).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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

        // DELETE api/<RegistroActividadesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                using (mantenimiento_totalContext db = new mantenimiento_totalContext())
                {
                    RegistroMantenimientoCorrectivo oActividad = db.RegistroMantenimientoCorrectivos.Find(id);
                    db.Remove(oActividad);
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
