using System;

namespace irg.Common.Models
{
    public class _CarrerasParticipantes
    {
        public int idparticipante { get; set; }
        public int idCarrera { get; set; }
        public string participante { get; set; }
        public int idgenero { get; set; }
        public string email { get; set; }
        public string telefono { get; set; }
        public int idTalla { get; set; }
        public int idCategoria { get; set; }
        public int idDistancia { get; set; }
        public DateTime fechanacimiento { get; set; }
        public int idreferencia { get; set; }
        public string otros { get; set; }
        public string contacto { get; set; }
        public string telefonocontacto { get; set; }
        public decimal pago { get; set; }
        public string idusuario { get; set; }
        public DateTime fecharegistro { get; set; }
        public string confirmacionPaquete { get; set; }
        public int numeroCorredor { get; set; }
    }
}
