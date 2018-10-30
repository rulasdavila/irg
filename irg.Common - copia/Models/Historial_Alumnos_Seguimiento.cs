using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace irg.Common.Models
{
    public class Historial_Alumnos_Seguimiento
    {
        public string Folio { get; set; }
        public byte Orden { get; set; }
        public string Comentario { get; set; }
        public DateTime Fecha { get; set; }
        public string C_Usuario { get; set; }
    }
}
