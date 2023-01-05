using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WSMantenimiento.Models.ViewModels
{
    public class ActividadRequest
    {
        public int IdActividad { get; set; }
        public int IdArea { get; set; }
        public int? IdMaquina { get; set; }
        public string NombreActividad { get; set; }
        public int? RecursoHumano { get; set; }
        public string Descripcion { get; set; }
        public Single? Tiempo { get; set; }
        public int? Periodo { get; set; }
        public DateTime? FechaProgramada { get; set; }
        public int? Asignada { get; set; }
    }
}
