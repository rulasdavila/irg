using System;

namespace irg.Common.Models
{
    public class _CarrerasAtleticas
    {
        public int idCarrera { get; set; }
        public string nombreCarrera { get; set; }
        public DateTime fechaCarrera { get; set; }
        public decimal Costo { get; set; }
        public string vigente { get; set; }
        public string ubicacion { get; set; }
        public int participantes { get; set; }
    }
}
