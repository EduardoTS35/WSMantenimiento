using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WSMantenimiento.Models.ViewModels
{
    public class ActividadesCorrectivoRequest
    {
        public int id { get; set; }
        public string idOrden { get; set; }
        public int idMaquina { get; set; }
        public int idTrabajador { get; set; }
        public int tiempoParo { get; set; }
        public string descripcion { get; set; }
        public DateTime fecha { get; set; }
    }
}
