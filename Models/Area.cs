using System;
using System.Collections.Generic;

#nullable disable

namespace WSMantenimiento.Models
{
    public partial class Area
    {
        public Area()
        {
            Actividades = new HashSet<Actividade>();
            Maquinaria = new HashSet<Maquinarium>();
            Trabajadores = new HashSet<Trabajadore>();
        }

        public int IdArea { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Actividade> Actividades { get; set; }
        public virtual ICollection<Maquinarium> Maquinaria { get; set; }
        public virtual ICollection<Trabajadore> Trabajadores { get; set; }
    }
}
