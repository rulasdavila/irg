using System;

namespace irg.Common.Models
{
    public class Pagos_Bancos
    {
        public DateTime Fecha_Alta { get; set; }
        public string Cuenta { get; set; }
        public string Fecha_dep { get; set; }
        public string Hora_Dep { get; set; }
        public string Sucursal { get; set; }
        public string Desgloce { get; set; }
        public string Cantidad { get; set; }
        public string Saldo { get; set; }
        public string Referencia { get; set; }
        public string Concepto { get; set; }
        public string Completo { get; set; }
        public string Estado { get; set; }
        public string Usuario { get; set; }
    }
}
