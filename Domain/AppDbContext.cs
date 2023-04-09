using Microsoft.EntityFrameworkCore;
using TEST_TPLUS.Domain.Entities;


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

        public virtual DbSet<PlantConsumption> PlantConsumptions { get; set; }

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

            modelBuilder.Entity<House>()
            .HasMany(h => h.Consumptions)
            .WithOne(c => c.House)
            .HasForeignKey(c => c.HouseConsumerId);

            modelBuilder.Entity<HouseConsumption>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<HouseConsumption>()
                .HasOne(c => c.House)
                .WithMany(h => h.Consumptions)
                .HasForeignKey(c => c.HouseConsumerId);


            modelBuilder.Entity<Plant>()
           .HasMany(h => h.Consumptions)
           .WithOne(c => c.Plant)
           .HasForeignKey(c => c.PlantConsumerId);

            modelBuilder.Entity<PlantConsumption>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<PlantConsumption>()
                .HasOne(c => c.Plant)
                .WithMany(h => h.Consumptions)
                .HasForeignKey(c => c.PlantConsumerId);
        }

    }
}
