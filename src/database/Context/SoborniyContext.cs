using System;
using Microsoft.EntityFrameworkCore;
using SoborniyProject.database.Configurations;
using SoborniyProject.database.Models;

namespace SoborniyProject.database.Context
{
    public class SoborniyContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseMySql(Connection.GetMysqlString());
            optionsBuilder.UseSqlite(Connection.GetSqliteString());
            
        }
        private static bool _recreated = true;
        public SoborniyContext()
        {

            if (_recreated) {
                Database.EnsureDeleted();
            }

            Database.EnsureCreated();
        }

       protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SessionConfiguration());
            modelBuilder.ApplyConfiguration(new CarConfiguration());
            modelBuilder.ApplyConfiguration(new LightTrafficConfiguration());
            modelBuilder.ApplyConfiguration(new SessionStatisticConfiguration());
            modelBuilder.Entity<LightTraffic>()
                .HasOne<Session>(c => c.Session)
                .WithMany(c => c.LightTraffics)
                .HasForeignKey(c => c.SessionId);
            modelBuilder.Entity<Car>()
                .HasOne<Session>(c => c.Session)
                .WithOne(c => c.Car)
                .HasForeignKey<Car>(c => c.SessionId);
            modelBuilder.Entity<SessionStatistic>()
                .HasOne<Session>(c => c.Session)
                .WithMany(c => c.SessionStatistics)
                .HasForeignKey(c => c.SessionId);
        }
        public DbSet<Session> Session { get; set; }
        public DbSet<Car> Car { get; set; }
        public DbSet<LightTraffic> LightTraffic { get; set; }
        public DbSet<SessionStatistic> SessionStatistics { get; set; }
    }
}
