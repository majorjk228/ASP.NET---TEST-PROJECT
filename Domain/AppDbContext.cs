using Microsoft.EntityFrameworkCore;
using TEST_TPLUS.Domain.Entities;
using TEST_TPLUS.Service;

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
            var connectionString = Config.ConnectionString;

            optionsBuilder.UseSqlServer
            (
                connectionString
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
