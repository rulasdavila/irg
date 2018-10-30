using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace irg.Common.Models
{
    public class ServiciosInstituto_ActivacionUsuarios
    {
        public string device { get; set; }
        public string matricula { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public DateTime fecha { get; set; }
        public string confirmado { get; set; }
    }
}
