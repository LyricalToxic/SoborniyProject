﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoborniyProject.database.Models;

namespace SoborniyProject.database.Configurations
{
    public class CarConfiguration: IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
           // builder.Property(c => c.Id).HasColumnType("bigint");
           // builder.Property(c => c.SessionId).HasColumnType("bigint");
            builder.Property(c => c.Name).HasMaxLength(128).IsRequired();
            builder.Property(c => c.MaxSpeed).HasColumnType("decimal(5, 2)");
            builder.Property(c => c.Acceleration).HasColumnType("decimal(5, 2)");
            builder.Property(c => c.Deceleration).HasColumnType("decimal(5, 2)");
            builder.Property(c => c.CreatedAt)
                .ValueGeneratedOnAdd().IsRequired();
            builder.Property(c => c.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate().IsRequired();
            
            builder.HasIndex(c => c.UpdatedAt);
            builder.ToTable("Cars");
        }
    }
}