using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace irg.Common.Models
{
    class Evaluacion_AplicadosRespuestas
    {
        public string noprueba { get; set; }
	    public string n_pregunta { get; set; }
        public string materia { get; set; }
        public string turno { get; set; }
        public string dia { get; set; }
        public string hora { get; set; }
        public string salon { get; set; }
        public string bloque { get; set; }
        public string respuesta { get; set; }
        public string clave_profesor { get; set; }
    }
}
