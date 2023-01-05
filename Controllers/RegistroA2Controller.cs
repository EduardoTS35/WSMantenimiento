using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSMantenimiento.Models;
using WSMantenimiento.Response;

namespace WSMantenimiento.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistroA2Controller : ControllerBase
    {
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
                              join t in db.Trabajadores on r.IdTrabajador equals t.IdTrabajador
                              group r by new { r.IdOrden, r.IdTrabajador, t.Nombre } into o
                              select new
                              {
                                  o.Key
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
    }
}
