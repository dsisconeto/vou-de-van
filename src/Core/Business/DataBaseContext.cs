using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using VouDeVan.Core.Business.Domains.Geo;
using VouDeVan.Core.Business.Domains.StopoverPoints;
using VouDeVan.Core.Business.Domains.TransportationCompanies;

namespace VouDeVan.Core.Business
{
    public class DataBaseContext : DbContext
    {
        public DbSet<TransportationCompany> TransportationCompanies { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<StopoverPoint> StopoverPoints { get; set; }


        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TransportationCompany>()
                .Property(t => t.Logo)
                .HasConversion(
                    logo => JsonConvert.SerializeObject(logo),
                    logo => JsonConvert.DeserializeObject<Logo>(logo));


            base.OnModelCreating(modelBuilder);
        }
    }
}