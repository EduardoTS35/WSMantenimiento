using System;
using System.Collections.Generic;

#nullable disable

namespace WSMantenimiento.Models
{
    public partial class Role
    {
        public Role()
        {
            Trabajadores = new HashSet<Trabajadore>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Trabajadore> Trabajadores { get; set; }
    }
}
