using System;
using System.Collections.Generic;

#nullable disable

namespace WSMantenimiento.Models
{
    public partial class ListaRefaccionesMc
    {
        public int IdSerial { get; set; }
        public string IdOrden { get; set; }
        public int IdRefaccion { get; set; }
        public float? Cantidad { get; set; }

        public virtual Refaccione IdRefaccionNavigation { get; set; }
    }
}
