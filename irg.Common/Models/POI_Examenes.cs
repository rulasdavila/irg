using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace irg.Common.Models
{
    public class POI_Examenes
    {
        public int clave { get; set; }
        public string a_paterno { get; set; }
	    public string a_materno { get; set; }
	    public string nombre { get; set; }
	    public string nombre_2 { get; set; }
	    public string colonia { get; set; }
	    public string direccion { get; set; }
	    public string telefono { get; set; }
	    public string celular { get; set; }
	    public string email { get; set; }
	    public string cp { get; set; }
        public DateTime fecha { get; set; }
	    public Int16 Edad { get; set; }
	    public bool sexo { get; set; }
        public string genero { get; set; }
        public string Carrera { get; set; }
        public string Resultados { get; set; }
        public bool Impreso { get; set; }
    }
}
