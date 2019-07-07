using Microsoft.EntityFrameworkCore;
using VouDeVan.Infrastructure.Database.TransportationCompanies;

namespace VouDeVan.Infrastructure.Database
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<TransportationCompanyDataRow>()
                .HasIndex(tc => tc.Status);
        }
    }
}