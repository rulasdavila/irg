namespace irg.Backend.Models
{
    using Domain.Models;

    public class LocalDataContext : DataContext
    {
        public System.Data.Entity.DbSet<irg.Common.Models.Pagos> Pagos { get; set; }
    }
}