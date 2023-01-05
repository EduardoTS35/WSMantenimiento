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
    public class RegistroActividadesController : ControllerBase
    {
        // GET: api/<RegistroActividadesController>
        [HttpGet]
        public IActionResult GetRegistroActividades()
        {
            Respuesta respuesta = new Respuesta();
            respuesta.Exito = 0;

            try
            {
                using (mantenimiento_totalContext db = new mantenimiento_totalContext())
                {
                    var lst = from r in db.RegistroActividades
                              join m in db.Maquinaria on r.IdMaquina equals m.IdMaquina
                              select new RegistroActividade
                              {
                                  Id = r.Id,
                                  IdOrden = r.IdOrden,
                                  IdActividad = r.IdActividad,
                                  IdMaquina = r.IdMaquina,
                                  descripcionM = m.Descripcion,
                                  IdTrabajador = r.IdTrabajador,
                                  FechaProgramada = r.FechaProgramada,
                                  FechaRealizacion = r.FechaRealizacion,
                                  Notas = r.Notas,
                                  IdTrabajadorSupervisor = r.IdTrabajadorSupervisor,
                                  IdActividadNavigation = r.IdActividadNavigation,
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
        public IActionResult AddActividad(RegistroActividadRequest oModel)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                using (mantenimiento_totalContext db = new mantenimiento_totalContext())
                {
                    RegistroActividade oActividad = new RegistroActividade();
                    oActividad.Id = oModel.id;
                    oActividad.IdOrden = oModel.idOrden;
                    oActividad.IdActividad = oModel.idActividad;
                    oActividad.IdMaquina = oModel.idMaquina;
                    oActividad.IdTrabajador = oModel.idTrabajador;
                    oActividad.FechaProgramada = oModel.fechaProgramada;
                    oActividad.FechaRealizacion = oModel.fechaRealizacion;
                    oActividad.Notas = oModel.notas;
                    oActividad.IdTrabajadorSupervisor = oModel.idTrabajadorSupervisor;
                    db.RegistroActividades.Add(oActividad);
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
        public IActionResult EditActividad(RegistroActividadRequest oModel)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                using (mantenimiento_totalContext db = new mantenimiento_totalContext())
                {
                    RegistroActividade oActividad = db.RegistroActividades.Find(oModel.id);

                    oActividad.IdOrden = oModel.idOrden;
                    oActividad.IdActividad = oModel.idActividad;
                    oActividad.IdMaquina = oModel.idMaquina;
                    oActividad.IdTrabajador = oModel.idTrabajador;
                    oActividad.FechaProgramada = oModel.fechaProgramada;
                    oActividad.FechaRealizacion = oModel.fechaRealizacion;
                    oActividad.Notas = oModel.notas;
                    oActividad.IdTrabajadorSupervisor = oModel.idTrabajadorSupervisor;

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
        [HttpDelete("{IdActividad}")]
        public IActionResult Delete(int IdActividad)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                using (mantenimiento_totalContext db = new mantenimiento_totalContext())
                {
                    RegistroActividade oActividad = db.RegistroActividades.Find(IdActividad);
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
