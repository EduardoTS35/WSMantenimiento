using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WSMantenimiento.Response
{
    public class UserResponse
    {
        public string Usuario { get; set; }
        public string Token { get; set; }

        public int idUsuario { get; set; }

        public int idRol { get; set; }
    }
}
