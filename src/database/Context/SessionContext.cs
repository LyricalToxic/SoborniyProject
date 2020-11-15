using Microsoft.EntityFrameworkCore;
using SoborniyProject.database.Models;

namespace SoborniyProject.database.Context
{
    public class SessionContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(Connection.GetString());
        }
        public SessionContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Session>().Property(c => c.Key).IsRequired().HasMaxLength(32);
            modelBuilder.Entity<Session>().Property(c => c.TotalTime).HasDefaultValue("0");
            modelBuilder.Entity<Session>().Property(c => c.CreatedAt)
                .IsRowVersion();
            modelBuilder.Entity<Session>().Property(c => c.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate();
        }
        public DbSet<Session> Session { get; set; }
    }
}