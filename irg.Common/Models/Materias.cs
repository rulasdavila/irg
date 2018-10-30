using System;

namespace irg.Common.Models
{
    public class Materias
    {
        public string Clave_Instituto { get; set; }
        public string clave_materia { get; set; }
        public string nombre_materia { get; set; }
        public string Clave_Area { get; set; }
        public byte horas { get; set; }
        public byte Horas_de_Materia { get; set; }
        public int faltas_permitidas { get; set; }
        public string C_Carrera { get; set; }
        public Int16 Cuatrimestre { get; set; }
        public Int16 Orden { get; set; }
        public string Seriada { get; set; }
        public string Academia { get; set; }
    }
}
