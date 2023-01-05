using System;
using System.Collections.Generic;

#nullable disable

namespace WSMantenimiento.Models
{
    public partial class Maquinarium
    {
        public Maquinarium()
        {
            Actividades = new HashSet<Actividade>();
            RegistroActividades = new HashSet<RegistroActividade>();
            RegistroMantenimientoCorrectivos = new HashSet<RegistroMantenimientoCorrectivo>();
        }

        public int IdMaquina { get; set; }
        public int IdArea { get; set; }
        public string Descripcion { get; set; }
        public string Modelo { get; set; }
        public int? AñoFabricacion { get; set; }
        public string NumeroSerie { get; set; }

        public virtual Area IdAreaNavigation { get; set; }
        public virtual ICollection<Actividade> Actividades { get; set; }
        public virtual ICollection<RegistroActividade> RegistroActividades { get; set; }
        public virtual ICollection<RegistroMantenimientoCorrectivo> RegistroMantenimientoCorrectivos { get; set; }
    }
}
