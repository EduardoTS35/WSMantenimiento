using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WSMantenimiento.Models.ViewModels
{
    public class RegistroActividadRequest
    {
        public int id { get; set; }
        public string idOrden { get; set; }
        public int idActividad { get; set; }
        public int idMaquina { get; set; }
        public int idTrabajador { get; set; }
        public DateTime fechaProgramada { get; set; }
        public DateTime? fechaRealizacion { get; set; }
        public string notas { get; set; }
        public int idTrabajadorSupervisor { get; set; }
    }
}
