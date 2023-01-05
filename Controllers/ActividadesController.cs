using Microsoft.AspNetCore.Cors;
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
    public class ActividadesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetActividades()
        {
            Respuesta respuesta = new Respuesta();
            respuesta.Exito = 0;

            try
            {
                using (mantenimiento_totalContext db = new mantenimiento_totalContext())
                {
                    var lst = from a in db.Actividades
                              select new Actividade
                              {
                                  IdActividad = a.IdActividad,
                                  IdArea = a.IdArea,
                                  IdMaquina = a.IdMaquina,
                                  NombreActividad = a.NombreActividad,
                                  RecursoHumano = a.RecursoHumano,
                                  Descripcion = a.Descripcion,
                                  Tiempo = a.Tiempo,
                                  Periodo = a.Periodo,
                                  FechaProgramada = a.FechaProgramada,
                                  Asignada = a.Asignada,
                                  IdMaquinaNavigation = a.IdMaquinaNavigation
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
        public IActionResult AddActividad(ActividadRequest oModel)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                using (mantenimiento_totalContext db = new mantenimiento_totalContext())
                {
                    Actividade oActividad = new Actividade();
                    oActividad.IdArea = oModel.IdArea;
                    oActividad.IdMaquina = oModel.IdMaquina;
                    oActividad.NombreActividad = oModel.NombreActividad;
                    oActividad.RecursoHumano = oModel.RecursoHumano;
                    oActividad.Descripcion = oModel.Descripcion;
                    oActividad.Tiempo = oModel.Tiempo;
                    oActividad.Periodo = oModel.Periodo;
                    oActividad.FechaProgramada = oModel.FechaProgramada;
                    oActividad.Asignada = oModel.Asignada;
                    db.Actividades.Add(oActividad);
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

        [HttpPut]
        public IActionResult EditActividad(ActividadRequest oModel)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                using (mantenimiento_totalContext db = new mantenimiento_totalContext())
                {
                    Actividade oActividad = db.Actividades.Find(oModel.IdActividad);

                    oActividad.IdMaquina = oModel.IdMaquina;
                    oActividad.NombreActividad = oModel.NombreActividad;
                    oActividad.RecursoHumano = oModel.RecursoHumano;
                    oActividad.Descripcion = oModel.Descripcion;
                    oActividad.Tiempo = oModel.Tiempo;
                    oActividad.Periodo = oModel.Periodo;
                    oActividad.FechaProgramada = oModel.FechaProgramada;
                    oActividad.Asignada = oModel.Asignada;

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


        [HttpDelete("{IdActividad}")]
        public IActionResult Delete(int IdActividad)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                using (mantenimiento_totalContext db = new mantenimiento_totalContext())
                {
                    Actividade oActividad = db.Actividades.Find(IdActividad);
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
