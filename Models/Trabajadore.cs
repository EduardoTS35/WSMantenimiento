using System;
using System.Collections.Generic;

#nullable disable

namespace WSMantenimiento.Models
{
    public partial class Trabajadore
    {
        public Trabajadore()
        {
            RegistroActividades = new HashSet<RegistroActividade>();
            RegistroMantenimientoCorrectivos = new HashSet<RegistroMantenimientoCorrectivo>();
        }

        public int IdTrabajador { get; set; }
        public int IdArea { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Puesto { get; set; }
        public string Usuario { get; set; }
        public string Pass { get; set; }
        public int? IdRol { get; set; }

        public virtual Area IdAreaNavigation { get; set; }
        public virtual Role IdRolNavigation { get; set; }
        public virtual ICollection<RegistroActividade> RegistroActividades { get; set; }
        public virtual ICollection<RegistroMantenimientoCorrectivo> RegistroMantenimientoCorrectivos { get; set; }
    }
}
