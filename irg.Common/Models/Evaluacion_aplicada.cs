using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace irg.Common.Models
{
    public class Evaluacion_aplicada
    {
        public decimal no_prueba { get; set; }
	    public string clave_prueba { get; set; }
        public string clave_evaluador { get; set; }
        public string clave_evaluado { get; set; }
        public string fecha { get; set; }
        public string ano { get; set; }
        public string no_cuatrimestre { get; set; }
        public string clave_materia { get; set; }
        public string dia { get; set; }
        public string hora { get; set; }
        public string salon { get; set; }
    }
}
