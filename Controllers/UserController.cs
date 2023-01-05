using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSMantenimiento.Models.ViewModels;
using WSMantenimiento.Response;
using WSMantenimiento.Services;

namespace WSMantenimiento.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("/login")]
        public IActionResult Autentificar([FromBody] AuthRequest model)
        {
            Respuesta response = new Respuesta();
            var userResponse = _userService.Auth(model);
            if (userResponse == null)
            {
                response.Exito = 0;
                response.Mensaje = "Usuario o Contraseña incorrecta";
                return BadRequest(response);
            }

            response.Exito = 1;
            response.Data = userResponse;
            return Ok(response);
        }
    }
}
