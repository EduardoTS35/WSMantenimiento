using System;
using System.Collections.Generic;

#nullable disable

namespace WSMantenimiento.Models
{
    public partial class Actividade
    {
        public Actividade()
        {
            ListaRefaccionesActvProgs = new HashSet<ListaRefaccionesActvProg>();
            RegistroActividades = new HashSet<RegistroActividade>();
        }

        public int IdActividad { get; set; }
        public int IdArea { get; set; }
        public int? IdMaquina { get; set; }
        public string NombreActividad { get; set; }
        public int? RecursoHumano { get; set; }
        public string Descripcion { get; set; }
        public float? Tiempo { get; set; }
        public int? Periodo { get; set; }
        public DateTime? FechaProgramada { get; set; }
        public int? Asignada { get; set; }

        public virtual Area IdAreaNavigation { get; set; }
        public virtual Maquinarium IdMaquinaNavigation { get; set; }
        public virtual ICollection<ListaRefaccionesActvProg> ListaRefaccionesActvProgs { get; set; }
        public virtual ICollection<RegistroActividade> RegistroActividades { get; set; }
    }
}
