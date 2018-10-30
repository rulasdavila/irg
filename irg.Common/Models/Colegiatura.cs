using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace irg.Common.Models
{
    public class Colegiatura
    {
        public string Clave_Instituto { get; set; }
        public int Actual { get; set; }
        public int Actual2 { get; set; }
        public int Ano { get; set; }
	    public int No_Cuatrimestre { get; set; }
        public int Vigente { get; set; }
        public string C_Carrera { get; set; }
        public string turno { get; set; }
    }
}
