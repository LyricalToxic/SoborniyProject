using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoborniyProject.database.Models;

namespace SoborniyProject.database.Configurations
{
    public class LightTrafficConfiguration: IEntityTypeConfiguration<LightTraffic>
    {
        public void Configure(EntityTypeBuilder<LightTraffic> builder)
        {
            // builder.Property(c => c.Id).HasColumnType("bigint");
            // builder.Property(c => c.SessionId).HasColumnType("bigint").IsRequired();
            builder.Property(c => c.SessionId).IsRequired();
            //builder.Property(c => c.PositionId).HasColumnType("bigint").IsRequired();
            builder.Property(c => c.PositionId).IsRequired();
            builder.Property(c => c.PreviousDistance).HasColumnType("decimal(6, 2)").IsRequired();
            builder.Property(c => c.RedLightDuration);
            builder.Property(c => c.YellowLightDuration);
            builder.Property(c => c.GreenLightDuration);
            builder.Property(c => c.Status).HasDefaultValue(0).IsRequired();
            builder.Property(c => c.StartColor);
            builder.Property(c => c.NextColor);
            builder.Property(c => c.CreatedAt)
                .IsRequired().IsRowVersion().HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Property(c => c.UpdatedAt)
                .IsRequired().IsRowVersion().HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.HasIndex(c => c.UpdatedAt);
            builder.HasIndex(c => new {c.SessionId, c.PositionId}).IsUnique();
            builder.ToTable("LightTraffics");
        }
    }
}