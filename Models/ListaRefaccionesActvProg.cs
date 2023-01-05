using System;
using System.Collections.Generic;

#nullable disable

namespace WSMantenimiento.Models
{
    public partial class ListaRefaccionesActvProg
    {
        public int IdSerial { get; set; }
        public int IdActividad { get; set; }
        public int IdRefaccion { get; set; }
        public float? Cantidad { get; set; }

        public virtual Actividade IdActividadNavigation { get; set; }
        public virtual Refaccione IdRefaccionNavigation { get; set; }
    }
}
