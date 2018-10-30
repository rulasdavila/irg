using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace irg.Common.Models
{
    public class Concepto
    {
        public string Clave_Instituto { get; set; }
        public string clave_concepto { get; set; }
        public string nombre_concepto { get; set; }
        public decimal costo { get; set; }
        public decimal Recargos { get; set; }
        public string C_Carrera { get; set; }
        public string Abonos { get; set; }
        public string PasPreFut { get; set; }
        public string Obliga_Inscripcion { get; set; }
        public string Repetible { get; set; }
        public string Monto_Variable { get; set; }
        public string Acumulativo { get; set; }
        public string Tipo { get; set; }
        public string Desgloce_IVA { get; set; }
        public int PorcentajeIncremento { get; set; }
        public int DiaVencimiento { get; set; }
    }
}
