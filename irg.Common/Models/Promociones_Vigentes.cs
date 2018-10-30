using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace irg.Common.Models
{
    public class Promociones_Vigentes
    {
        public string Clave { get; set; }
        public string Promocion { get; set; }
        public string Descuento { get; set; }
        public int DescuentoMonto { get; set; }
        public string Tipo { get; set; }
        public string Vigente { get; set; }
        public string Exige_Puntualidad { get; set; }
        public string Acumulativo { get; set; }
    }
}
