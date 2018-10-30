namespace irg.Domain.Models
{
    using System.Data.Entity;

    public class DataContext :DbContext
    {
        public DataContext() : base ("DefaultConnection")
        {

        }

        public System.Data.Entity.DbSet<irg.Common.Models.Pagos> Pagos { get; set; }
        public System.Data.Entity.DbSet<irg.Common.Models.Asistencia> Asistencias { get; set; }
    }
}
