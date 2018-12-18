namespace irg.Common.Models
{
    using System.ComponentModel.DataAnnotations;

    public class BancosBbLog
    {
        [Key]
        public int id { get; set; }
        //[Required]
        public string accion { get; set; }
        //[Required]
        public string referencia { get; set; }
        //[Required]
        public string bancoemisor { get; set; }
        //[Required]
        public string serviciobb { get; set; }
        //[Required]
        public string monto { get; set; }
        //[Required]
        public string formapago { get; set; }
        //[Required]
        public string firma { get; set; }
        [Required]
        public string fecha { get; set; }
        [Required]
        public string ip { get; set; }
    }
}
