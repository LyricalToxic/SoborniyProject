using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoborniyProject.database.Models;
namespace SoborniyProject.database.Configurations
{
    public class SessionStatisticConfiguration: IEntityTypeConfiguration<SessionStatistic>
    {
        public void Configure(EntityTypeBuilder<SessionStatistic> builder)
        {
            builder.Property(c => c.Id).HasColumnType("bigint").IsRequired();
            builder.Property(c => c.SessionId).HasColumnType("bigint").IsRequired();
            builder.Property(c => c.PositionId).HasColumnType("bigint").IsRequired();
            builder.Property(c => c.CarSpeed).IsRequired().HasColumnType("decimal(5, 2)");
            builder.Property(c => c.SessionTime).IsRequired();
            builder.Property(c => c.DurationLeftSec);
            builder.Property(c => c.NextLightColor);
            builder.Property(c => c.LightColor);
            builder.Property(c => c.LightTrafficStatus).HasDefaultValue(0).IsRequired();
            builder.Property(c => c.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate().IsRequired();
            builder.HasIndex(c => c.CarSpeed);
            builder.HasIndex(c => c.UpdatedAt);
            builder.HasIndex(c => new {c.SessionId, c.PositionId}).IsUnique();
        }
    }
}