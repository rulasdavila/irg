using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace irg.Common.Models
{
    public class Planteles_Disponibles
    { 
        public int orden { get; set; }
	    public string ip { get; set; }
        public string nombre { get; set; }
        public string usuario { get; set; }
        public string clave { get; set; }
        public string bd { get; set; }
        public string siglas { get; set; }
    }
}
