using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WSMantenimiento.Models.ViewModels
{
    public class TrabajadoresRequest
    {
        public int IdTrabajador { get; set; }
        public int IdArea { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Puesto { get; set; }
        public string Usuario { get; set; }
        public string Pass { get; set; }
    }
}
