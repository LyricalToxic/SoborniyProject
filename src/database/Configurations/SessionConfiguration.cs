using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoborniyProject.database.Models;

namespace SoborniyProject.database.Configurations
{
    public class SessionConfiguration: IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            builder.Property(c => c.Id).HasColumnType("bigint");
            builder.Property(c => c.Key).IsRequired().HasMaxLength(32);
            builder.Property(c => c.TotalTime).HasDefaultValue(0).IsRequired();
            builder.Property(c => c.Status).HasDefaultValue(0).IsRequired();
            builder.Property(c => c.CreatedAt)
                .IsRowVersion().IsRequired();
            builder.Property(c => c.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate().IsRequired();
            builder.HasIndex(c => c.Key).IsUnique();
            builder.HasIndex(c => c.UpdatedAt);
        }
    }
}