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
            builder.Property(c => c.TotalTime).HasDefaultValue("0");
            builder.Property(c => c.Status).HasDefaultValue(0);
            builder.Property(c => c.CreatedAt)
                .IsRowVersion();
            builder.Property(c => c.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate();
        }
    }
}