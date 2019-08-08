using Microsoft.EntityFrameworkCore;
using VouDeVan.Core.Business.Domains.StopoverPoints;
using VouDeVan.Core.Business.Domains.TransportationCompanies;

namespace VouDeVan.Core.Business
{
    public class DataBaseContext : DbContext
    {
        public DbSet<TransportationCompany> TransportationCompanies { get; set; }
        public DbSet<StopoverPoint> StopoverPoints { get; set; }

        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}