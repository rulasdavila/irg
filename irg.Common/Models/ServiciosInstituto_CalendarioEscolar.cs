using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace irg.Common.Models
{
    public class ServiciosInstituto_CalendarioEscolar
    {
        public int orden { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaTermino { get; set; }
        public string titulo { get; set; }
        public string evento { get; set; }
        public string año { get; set; }
        public string nocuatrimestre { get; set; }
    }
}
