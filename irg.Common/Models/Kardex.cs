using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace irg.Common.Models
{
    public class Kardex
    {
        public string Clave_Instituto { get; set; }
        public int matricula { get; set; }
        public string clave_materia { get; set; }
        public string turno { get; set; }
        public string dia { get; set; }
        public string hora { get; set; }
        public string Salon { get; set; }
        public string Bloque { get; set; }
        public string clave_forma { get; set; }
        public int ano { get; set; }
        public string no_cuatrimestre { get; set; }
        public string fecha_otros { get; set; }
        public string oportunidad { get; set; }
        public Single calificacion_1 { get; set; }
        public Single calificacion_2 { get; set; }
        public Single calificacion_3 { get; set; }
        public Single calificacion_4 { get; set; }
        public Single Calificacion_5 { get; set; }
        public Single Calificacion_6 { get; set; }
        public Single Calificacion_7 { get; set; }
        public Single Calificacion_8 { get; set; }
        public Single Calificacion_9 { get; set; }
        public Single Calificacion_10 { get; set; }
	    public Single Calificacion_11 { get; set; }
        public Single Calificacion_12 { get; set; }
        public Single final { get; set; }
        public string Especial { get; set; }
        public string Estatus { get; set; }
        public string VC1 { get; set; }
        public string VC2 { get; set; }
        public string VC3 { get; set; }
        public string VC4 { get; set; }
        public string VC5 { get; set; }
        public string VC6 { get; set; }
        public string VC7 { get; set; }
        public string VC8 { get; set; }
        public string VC9 { get; set; }
        public string VC10 { get; set; }
        public string VC11 { get; set; }
        public string VC12 { get; set; }
        public string VCF { get; set; }
        public string Registrado { get; set; }
        public string Academia_Nivel { get; set; }
        public DateTime? Fecha_Alta { get; set; }
        public DateTime? Fecha_UMov { get; set; }
        public string FinalLetra { get; set; }
    }
}
