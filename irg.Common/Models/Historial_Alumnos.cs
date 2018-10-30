using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace irg.Common.Models
{
    public class Historial_Alumnos
    {
        public string Clave_Instituto { get; set; }
        public string Matricula { get; set; }
        public string Comentario { get; set; }
        public string C_Usuario { get; set; }
        public string Grupo { get; set; }
        public DateTime Fecha { get; set; }
        public string Privado { get; set; }
        public string Estatus { get; set; }
    }
}
