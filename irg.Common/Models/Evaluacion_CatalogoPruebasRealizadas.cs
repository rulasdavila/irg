using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace irg.Common.Models
{
    public class Evaluacion_CatalogoPruebasRealizadas
    {
        public string noprueba { get; set; }
        public string matricula { get; set; }
        public DateTime fecha { get; set; }
        public string ano { get; set; }
        public string no_cuatrimestre { get; set; }
        public string estatus { get; set; }
        public string clavetiposevaluacion { get; set; }
        public string claveevaluador { get; set; }
        public string claveevaluado { get; set; }
        public string nomaterias { get; set; }
        public string analisisresultados { get; set; }
    }
}
