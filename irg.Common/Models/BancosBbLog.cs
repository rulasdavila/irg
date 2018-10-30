namespace irg.Common.Models
{
    public class BancosBbLog
    {
        public int id { get; set; }
        public string accion { get; set; }
        public string referencia { get; set; }
        public string bancoemisor { get; set; }
        public string serviciobb { get; set; }
        public string monto { get; set; }
        public string formapago { get; set; }
        public string firma { get; set; }
        public string fecha { get; set; }
        public string ip { get; set; }
    }
}
