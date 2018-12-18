using System;

namespace irg.Common.Models
{
    public class Documentos_Alumnos
    {
        public string clave_instituto { get; set; }
        public string matricula { get; set; }
        public string id_documento { get; set; }
        public string respaldado { get; set; }
        public string entregado_autoridad { get; set; }
        public DateTime fecha { get; set; }
        public string ruta_documento { get; set; }
    }
}