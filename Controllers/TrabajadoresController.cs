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
    public class TrabajadoresController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetTrabajadores()
        {
            Respuesta respuesta = new Respuesta();
            respuesta.Exito = 0;

            try
            {
                using (mantenimiento_totalContext db = new mantenimiento_totalContext())
                {
                    var lst = from t in db.Trabajadores
                              select new Trabajadore
                              {
                                  IdTrabajador=t.IdTrabajador,
                                  IdArea=t.IdArea,
                                  Nombre=t.Nombre,
                                  Apellido=t.Apellido,
                                  Puesto=t.Puesto,
                                  Usuario=t.Usuario,
                                  Pass=t.Pass
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
        public IActionResult AddTrabajador(TrabajadoresRequest oModel)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                using (mantenimiento_totalContext db = new mantenimiento_totalContext())
                {
                    Trabajadore oTrabajador = new Trabajadore();
                    oTrabajador.IdTrabajador = oModel.IdTrabajador;
                    oTrabajador.IdArea = oModel.IdArea;
                    oTrabajador.Nombre = oModel.Nombre;
                    oTrabajador.Apellido = oModel.Apellido;
                    oTrabajador.Puesto = oModel.Puesto;
                    oTrabajador.Usuario = oModel.Usuario;
                    oTrabajador.Pass = oModel.Pass;
                    db.Trabajadores.Add(oTrabajador);
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
        public IActionResult EditTrabajador(TrabajadoresRequest oModel)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                using (mantenimiento_totalContext db = new mantenimiento_totalContext())
                {
                    Trabajadore oTrabajador = db.Trabajadores.Find(oModel.IdTrabajador);

                    oTrabajador.IdTrabajador = oModel.IdTrabajador;
                    oTrabajador.IdArea = oModel.IdArea;
                    oTrabajador.Nombre = oModel.Nombre;
                    oTrabajador.Apellido = oModel.Apellido;
                    oTrabajador.Puesto = oModel.Puesto;
                    oTrabajador.Usuario = oModel.Usuario;
                    oTrabajador.Pass = oModel.Pass;

                    db.Entry(oTrabajador).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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

        [HttpDelete("{idTrabajador}")]
        public IActionResult Delete(int idTrabajador)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                using (mantenimiento_totalContext db = new mantenimiento_totalContext())
                {
                    Trabajadore oTrabajador = db.Trabajadores.Find(idTrabajador);
                    db.Remove(oTrabajador);
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
