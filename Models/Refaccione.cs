using System;
using System.Collections.Generic;

#nullable disable

namespace WSMantenimiento.Models
{
    public partial class Refaccione
    {
        public Refaccione()
        {
            AlmacenRefacciones = new HashSet<AlmacenRefaccione>();
            ListaRefaccionesActvProgs = new HashSet<ListaRefaccionesActvProg>();
            ListaRefaccionesMcs = new HashSet<ListaRefaccionesMc>();
        }

        public int IdRefaccion { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public float Precio { get; set; }
        public string Unidad { get; set; }

        public virtual ICollection<AlmacenRefaccione> AlmacenRefacciones { get; set; }
        public virtual ICollection<ListaRefaccionesActvProg> ListaRefaccionesActvProgs { get; set; }
        public virtual ICollection<ListaRefaccionesMc> ListaRefaccionesMcs { get; set; }
    }
}
