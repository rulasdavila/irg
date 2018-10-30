using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace irg.Common.Models
{
    public class Interconexion_Usuarios_Dirigido
    {
        public string Folio { get; set; }
	    public string Ano { get; set; }
        public string Mes { get; set; }
        public string Dia { get; set; }
        public string Consecutivo { get; set; }
        public string Seguimiento { get; set; }
        public string Usuario { get; set; }
        public string TablaUsuario { get; set; }
        public string Leido { get; set; }
        public string Importante { get; set; }
        public string Vencimiento { get; set; }
    }
}
