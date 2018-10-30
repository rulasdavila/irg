using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace irg.Common.Models
{
    public class Interconexion_Usuarios_Comentarios
    {
        public string Folio { get; set; }
	    public string Ano { get; set; }
        public string Mes { get; set; }
        public string Dia { get; set; }
        public string Consecutivo { get; set; }
        public string Seguimiento { get; set; }
        public string Usuario { get; set; }
        public string TablaUsuario { get; set; }
        public string Referido { get; set; }
        public string TablaReferido { get; set; }
        public string Comentario { get; set; }
        public string Privado { get; set; }
        public string Dirigido { get; set; }
        public string Estatus { get; set; }
        public DateTime Fecha { get; set; }
    }
}
