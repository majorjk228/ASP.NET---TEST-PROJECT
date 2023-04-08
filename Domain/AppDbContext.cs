using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using TEST_TPLUS.Domain.Entities;
using static TEST_TPLUS.Controllers.HouseController;

namespace TEST_TPLUS.Domains
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        { }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public virtual DbSet<House> Houses { get; set; }

        public virtual DbSet<HouseConsumption> HouseConsumptions { get; set; }

        public virtual DbSet<Plant> Plants { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
            (
                "Data Source = TYPAKEK\\SQLEXPRESS;Trusted_Connection=True;Initial Catalog = T_PLUS;User ID = sa;Password = sa;Connect Timeout = 30;Encrypt = False;TrustServerCertificate = False;ApplicationIntent = ReadWrite;MultiSubnetFailover = False"
            );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
