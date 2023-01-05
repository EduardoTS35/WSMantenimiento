using System;
using System.Collections.Generic;

#nullable disable

namespace WSMantenimiento.Models
{
    public partial class RegistroActividade
    {
        public int Id { get; set; }
        public string IdOrden { get; set; }
        public int IdActividad { get; set; }
        public int IdMaquina { get; set; }
        public int IdTrabajador { get; set; }
        public DateTime FechaProgramada { get; set; }
        public DateTime? FechaRealizacion { get; set; }
        public string Notas { get; set; }
        public int? IdTrabajadorSupervisor { get; set; }

        public virtual Actividade IdActividadNavigation { get; set; }
        public virtual Maquinarium IdMaquinaNavigation { get; set; }
        public virtual Trabajadore IdTrabajadorNavigation { get; set; }
        public string descripcionM { get;  set; }
    }
}
