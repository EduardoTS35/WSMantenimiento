using System;
using System.Collections.Generic;

#nullable disable

namespace WSMantenimiento.Models
{
    public partial class ListaStatus
    {
        public ListaStatus()
        {
            AlmacenRefacciones = new HashSet<AlmacenRefaccione>();
        }

        public int IdStatus { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<AlmacenRefaccione> AlmacenRefacciones { get; set; }
    }
}
