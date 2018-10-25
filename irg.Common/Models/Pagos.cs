
namespace irg.Common.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Pagos
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string Clave_Instituto { get; set; }
        [Required]
        public string Folio { get; set; }
        [Required]
        public int Matricula { get; set; }
        [Required]
        public string Clave_Concepto { get; set; }
        public string CC { get; set; }
        
        public string ME { get; set; }
        public string CV { get; set; }
        public string LI { get; set; }
        public string NA { get; set; }
        public string Detalles { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
        [Required]
        public decimal Costo { get; set; }
        [Required]
        public decimal Recargos { get; set; }
        [Required]
        public decimal Pagado { get; set; }
        [Required]
        public decimal Total_Calculado { get; set; }
        [Required]
        public string Usuario { get; set; }
        [Required]
        public int Ano { get; set; }
        [Required]
        public int No_Cuatrimestre { get; set; }
        [Required]
        public string F_Bancario { get; set; }
        [Required]
        public int Cancelado { get; set; }
        [Required]
        public int H_Clase { get; set; }
        [Required]
        public string Detalle_Descuento { get; set; }
        [Required]
        public string Fecha_Banco { get; set; }
        [Required]
        public string Forma_Pago { get; set; }
        [Required]
        public string Estatus { get; set; }
        [Required]
        public string Factura { get; set; }
    }

}

