using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WSMantenimiento.Models;
using WSMantenimiento.Models.Common;
using WSMantenimiento.Models.ViewModels;
using WSMantenimiento.Response;
using WSMantenimiento.Tools;

namespace WSMantenimiento.Services
{
    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }
        public UserResponse Auth(AuthRequest model)
        {
            UserResponse userResponse = new UserResponse();
            using (var db= new mantenimiento_totalContext())
            {
                
                string spass = Encrypt.GetSHA256(model.Pass);
                var usuario = db.Trabajadores.Where(d => d.Usuario == model.Usuario &&
                                                    d.Pass==spass).FirstOrDefault();
                if (usuario == null)
                    return null;
                userResponse.Usuario = usuario.Usuario;
                userResponse.Token = GetToken(usuario);
                userResponse.idUsuario = usuario.IdTrabajador;
                userResponse.idRol = (int)usuario.IdRol;
            }
            return userResponse;
        }
        private string GetToken(Trabajadore usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var llave = Encoding.ASCII.GetBytes(_appSettings.Secreto);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, usuario.IdTrabajador.ToString()),
                        new Claim(ClaimTypes.Name, usuario.Usuario.ToString()),
                    }
                    ),
                Expires = DateTime.UtcNow.AddDays(60),
                SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(llave), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
