using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WSMantenimiento.Models.ViewModels
{
    public class MaquinariaRequest
    {
        public int IdMaquina { get; set; }
        public int IdArea { get; set; }
        public string Descripcion { get; set; }
        public string Modelo { get; set; }
        public int? AñoFabricacion { get; set; }
        public string NumeroSerie { get; set; }
    }
}
