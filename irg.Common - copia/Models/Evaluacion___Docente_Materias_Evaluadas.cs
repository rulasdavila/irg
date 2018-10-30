using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace irg.Common.Models
{
    public class Evaluacion___Docente_Materias_Evaluadas
    {
        public string Materia { get; set; }
        public string Turno { get; set; }
        public string Dia { get; set; }
        public string Hora { get; set; }
        public string Salon { get; set; }
        public string Ano { get; set; }
        public string No_Cuatrimestre { get; set; }
        public int AlumnosLista { get; set; }
        public int AlumnosDescartados { get; set; }
        public int AlumnosSeleccionados { get; set; }
        public string FiltroFaltas { get; set; }
        public string C_Carrera { get; set; }
        public string C_Usuario { get; set; }
    }
}
