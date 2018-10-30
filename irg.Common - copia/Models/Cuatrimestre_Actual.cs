using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace irg.Common.Models
{
    public class Cuatrimestre_Actual
    {
        public string Clave_Instituto { get; set; }
	    public int cuatrimestre_actual { get; set; }
        public int monto { get; set; }
        public string clave_pago { get; set; }
        public string mes { get; set; }
        public string folio { get; set; }
        public byte Inscripcion_Sabados { get; set; }
        public byte Inscribe_Cuatrimestre { get; set; }
        public Int16 ano { get; set; }
        public byte no_cuatrimestre { get; set; }
        public string C_Carrera { get; set; }
        public string Baja_Cuatrimestre { get; set; }
        public string Motivo_Baja { get; set; }
        public string Tarjeton_Credencial { get; set; }
        public string Grupo { get; set; }
        public string Fechaapp { get; set; }
    }
}
