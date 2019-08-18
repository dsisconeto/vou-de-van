using Business.Geo;
using Business.StopoverPoints;
using Business.TransportationCompanies;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Business
{
    public class DataBaseContext : DbContext
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<StopoverPoint> StopoverPoints { get; set; }
        public DbSet<TransportationCompany> TransportationCompanies { get; set; }

        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TransportationCompany>()
                .Property(t => t.Logo)
                .HasConversion(
                    logo => JsonConvert.SerializeObject(logo),
                    logo => JsonConvert.DeserializeObject<Logo>(logo));

            base.OnModelCreating(modelBuilder);
        }
    }
}