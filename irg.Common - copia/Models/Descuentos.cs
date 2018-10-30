using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace irg.Common.Models
{
    public class Descuentos
    {
        public string Clave_Instituto { get; set; }
	    public string Aplica { get; set; }
        public string Porcentaje_Descuento { get; set; }
        public string Motivo { get; set; }
        public Boolean Aplicable { get; set; }
        public string C_Carrera { get; set; }
    }
}
