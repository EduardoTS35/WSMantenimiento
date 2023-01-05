using System;
using System.Collections.Generic;

#nullable disable

namespace WSMantenimiento.Models
{
    public partial class AlmacenRefaccione
    {
        public int IdSerial { get; set; }
        public int IdRefaccion { get; set; }
        public int IdStatus { get; set; }
        public DateTime FechaMovimiento { get; set; }
        public float Cantidad { get; set; }

        public virtual Refaccione IdRefaccionNavigation { get; set; }
        public virtual ListaStatus IdStatusNavigation { get; set; }
    }
}
