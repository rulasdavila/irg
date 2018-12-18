namespace irg.Common.Models
{
    using System.ComponentModel.DataAnnotations;

    public class BancosBbConsulta
    {
        [Required]
        string concepto { get; set; }
        string costo { get; set; }
        string recargos { get; set; }
        string carrera { get; set; }
        string cuatrimestres { get; set; }
        string alumno { get; set; }
        string vencimiento { get; set; }
        string tipo { get; set; }
        string claveConcepto { get; set; }
        string claveCarrera { get; set; }
    }
}