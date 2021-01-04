using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoborniyProject.database.Models;
namespace SoborniyProject.database.Configurations
{
    public class SessionStatisticConfiguration: IEntityTypeConfiguration<SessionStatistic>
    {
        public void Configure(EntityTypeBuilder<SessionStatistic> builder)
        {
            //builder.Property(c => c.Id).HasColumnType("bigint").IsRequired();
            builder.Property(c => c.Id).IsRequired();
            //builder.Property(c => c.SessionId).HasColumnType("bigint").IsRequired();
            builder.Property(c => c.SessionId).IsRequired();
            //builder.Property(c => c.PositionId).HasColumnType("bigint").IsRequired();
            builder.Property(c => c.PositionId).IsRequired();
            builder.Property(c => c.CarSpeed).IsRequired().HasColumnType("decimal(5, 2)");
            builder.Property(c => c.SessionTime).IsRequired();
            builder.Property(c => c.AccelerationTime);
            builder.Property(c => c.AccelerationDistance).HasColumnType("decimal(5, 2)");
            builder.Property(c => c.DecelerationTime);
            builder.Property(c => c.DecelerationDistance).HasColumnType("decimal(5, 2)");
            builder.Property(c => c.DistanceBetweenLightTraffic).IsRequired();
            builder.Property(c => c.TimeBetweenLightTraffic);
            builder.Property(c => c.LightTrafficStatus).HasDefaultValue(0).IsRequired();
            builder.Property(c => c.CreatedAt)
                .IsRequired().IsRowVersion().HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Property(c => c.UpdatedAt)
                .IsRequired().IsRowVersion().HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.HasIndex(c => c.CarSpeed);
            builder.HasIndex(c => c.UpdatedAt);
            builder.HasIndex(c => new {c.SessionId, c.PositionId}).IsUnique();
            builder.ToTable("SessionStatistics");
        }
    }
}