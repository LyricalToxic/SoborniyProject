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
            builder.Property(c => c.DurationLeftSec).IsRequired();
            builder.Property(c => c.NextLightColor).IsRequired();
            builder.Property(c => c.LightColor).IsRequired();
            builder.Property(c => c.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate();
        }
    }
}