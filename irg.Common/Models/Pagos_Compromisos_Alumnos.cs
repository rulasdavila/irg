using System;

namespace irg.Common.Models
{
    public class Pagos_Compromisos_Alumnos
    {
        public string Clave_Instituto { get; set; }
        public int orden { get; set; }
        public string Matricula { get; set; }
        public string Clave_Concepto { get; set; }
        public string Ano { get; set; }
        public string No_Cuatrimestre { get; set; }
        public string Mes { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha_Vencimiento { get; set; }
        public string Status { get; set; }
        public string C_Carrera { get; set; }
        public string clave_departamento { get; set; }
        public string clave_usuario { get; set; }
        public decimal costo_reportado { get; set; }
        public DateTime fecha_recargos { get; set; }
    }
}
