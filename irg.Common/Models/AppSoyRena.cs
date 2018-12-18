using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace irg.Common.Models
{
    public class AppSoyRena
    {
        public int id { get; set; }
        public string descripcion { get; set; }
        public string version { get; set; }
    }

    public enum TipoAppSoyRena
    {
        SoyRenaDocentes = 1,
        SoyRenaAlumnos = 2,
        SoyRenaAdministrativos = 3,
        SoyRenaDirectivos = 4,
    }
}
