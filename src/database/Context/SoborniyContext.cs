using Microsoft.EntityFrameworkCore;
using SoborniyProject.database.Configurations;
using SoborniyProject.database.Models;

namespace SoborniyProject.database.Context
{
    public class SoborniyContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(Connection.GetString());
        }
        public SoborniyContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

       protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SessionConfiguration());
            modelBuilder.ApplyConfiguration(new CarConfiguration());
            modelBuilder.ApplyConfiguration(new LightTrafficConfiguration());
            modelBuilder.ApplyConfiguration(new SessionStatisticConfiguration());
        }
        public DbSet<Session> Session { get; set; }
        public DbSet<Car> Car { get; set; }
        public DbSet<LightTraffic> LightTraffic { get; set; }
    }
}