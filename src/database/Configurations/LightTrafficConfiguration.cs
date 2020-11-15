using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoborniyProject.database.Models;

namespace SoborniyProject.database.Configurations
{
    public class LightTrafficConfiguration: IEntityTypeConfiguration<LightTraffic>
    {
        public void Configure(EntityTypeBuilder<LightTraffic> builder)
        {
            builder.Property(c => c.Id).HasColumnType("bigint");
            builder.Property(c => c.SessionId).HasColumnType("bigint").IsRequired();
            builder.Property(c => c.PositionId).HasColumnType("bigint").IsRequired();
            builder.Property(c => c.PreviousDistance).HasColumnType("decimal(6, 2)").IsRequired();
            builder.Property(c => c.RedLightDurationSec).IsRequired();
            builder.Property(c => c.YellowLightDurationSec).IsRequired();
            builder.Property(c => c.GreenLightDurationSec).IsRequired();
            builder.Property(c => c.Status).HasDefaultValue(0);
            builder.Property(c => c.StartColor).IsRequired();
            builder.Property(c => c.NextColor).IsRequired();
            builder.Property(c => c.CreatedAt)
                .IsRowVersion();
            builder.Property(c => c.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate();
        }
    }
}