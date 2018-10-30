using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace irg.Common.Models
{
    public class Log_Movimientos
    {
        public string Clave_Instituto { get; set; }
	    public DateTime fecha { get; set; }
        public string Suceso { get; set; }
        public string Matricula { get; set; }
        public string Tabla { get; set; }
        public string Ano { get; set; }
        public string NoCuatrimestre { get; set; }
        public string Accion { get; set; }
        public string C_Usuario { get; set; }
    }
}
