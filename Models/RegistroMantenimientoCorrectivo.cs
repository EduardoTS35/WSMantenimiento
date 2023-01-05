using System;
using System.Collections.Generic;

#nullable disable

namespace WSMantenimiento.Models
{
    public partial class RegistroMantenimientoCorrectivo
    {
        public int Id { get; set; }
        public string IdOrden { get; set; }
        public int IdMaquina { get; set; }
        public int IdTrabajador { get; set; }
        public float TiempoParo { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }

        public virtual Maquinarium IdMaquinaNavigation { get; set; }
        public virtual Trabajadore IdTrabajadorNavigation { get; set; }
    }
}
