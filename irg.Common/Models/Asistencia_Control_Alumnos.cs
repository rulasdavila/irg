using System;

namespace irg.Common.Models
{
    public class Asistencia_Control_Alumnos
    {
        public string matricula { get; set; }
        public byte orden { get; set; }
        public string ano { get; set; }
        public string cuatrimestre { get; set; }
        public DateTime fecha { get; set; }
        public string telefono { get; set; }
        public int id_respuesta { get; set; }
        public string c_grupo { get; set; }
        public string c_usuario { get; set; }
    }
}
