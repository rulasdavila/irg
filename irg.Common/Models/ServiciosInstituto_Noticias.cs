using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace irg.Common.Models
{
    public class ServiciosInstituto_Noticias
    {
        public int orden { get; set; }
        public DateTime fechapublicacion { get; set; }
        public DateTime fechacaducidad { get; set; }
        public string titulo { get; set; }
        public string evento { get; set; }
        public string rutafoto { get; set; }
        public string usuario { get; set; }
        public byte[] foto { get; set; }
    }
}
