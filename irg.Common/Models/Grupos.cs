using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace irg.Common.Models
{
    public class Grupos
    {
        public string Clave_Instituto { get; set; }
        public string C_Grupo { get; set; }
        public string N_Grupo { get; set; }
        public string ImagenRef { get; set; }
	    public byte[] Imagen { get; set; }
        public string Departamento { get; set; }
    }
}
