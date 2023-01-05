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
    public class MaquinariaController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetMaquinaria()
        {
            Respuesta respuesta = new Respuesta();
            respuesta.Exito = 0;

            try
            {
                using (mantenimiento_totalContext db = new mantenimiento_totalContext())
                {
                    var lst = from m in db.Maquinaria
                              select new Maquinarium
                              {
                                  IdMaquina = m.IdMaquina,
                                  IdArea = m.IdArea,
                                  Descripcion = m.Descripcion,
                                  Modelo = m.Modelo,
                                  AñoFabricacion = m.AñoFabricacion,
                                  NumeroSerie = m.NumeroSerie
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
        public IActionResult AddMaquina(MaquinariaRequest oModel)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                using (mantenimiento_totalContext db = new mantenimiento_totalContext())
                {
                    Maquinarium oMaquina = new Maquinarium();
                    oMaquina.IdMaquina = oModel.IdMaquina;
                    oMaquina.IdArea = oModel.IdArea;
                    oMaquina.Descripcion = oModel.Descripcion;
                    oMaquina.Modelo = oModel.Modelo;
                    oMaquina.AñoFabricacion = oModel.AñoFabricacion;
                    oMaquina.NumeroSerie = oModel.NumeroSerie;
                    db.Maquinaria.Add(oMaquina);
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
        public IActionResult EditMaquina(MaquinariaRequest oModel)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                using (mantenimiento_totalContext db = new mantenimiento_totalContext())
                {
                    Maquinarium oMaquina = db.Maquinaria.Find(oModel.IdMaquina);

                    oMaquina.IdMaquina = oModel.IdMaquina;
                    oMaquina.IdArea = oModel.IdArea;
                    oMaquina.Descripcion = oModel.Descripcion;
                    oMaquina.Modelo = oModel.Modelo;
                    oMaquina.AñoFabricacion = oModel.AñoFabricacion;
                    oMaquina.NumeroSerie = oModel.NumeroSerie;

                    db.Entry(oMaquina).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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

        [HttpDelete("{IdMaquina}")]
        public IActionResult Delete(int IdMaquina)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                using (mantenimiento_totalContext db = new mantenimiento_totalContext())
                {
                    Maquinarium oMaquina = db.Maquinaria.Find(IdMaquina);
                    db.Remove(oMaquina);
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
