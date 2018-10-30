using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace irg.Common.Models
{
    public class Asistencia
    {
        public string Clave_Instituto { get; set; }
        public int Matricula { get; set; }
        public string Clave_Materia { get; set; }
        public string Turno { get; set; }
        public string Dia { get; set; }
        public int Hora { get; set; }
        public int Ano { get; set; }
        public int No_Cuatrimestre { get; set; }
        public string Fecha_Falta { get; set; }
        public DateTime Fecha_Reporta { get; set; }
        public string Usuario { get; set; }
        public string estatus { get; set; }
        public int id { get; set; }
    }
}
