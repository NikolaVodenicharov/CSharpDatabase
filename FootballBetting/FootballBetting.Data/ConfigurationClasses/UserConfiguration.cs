﻿using FootballBetting.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballBetting.Data.ConfigurationClasses
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasKey(u => u.UserId);

            builder
                .Property(u => u.Username)
                .IsRequired(true)
                .HasMaxLength(80);

            builder
                .Property(u => u.Password)
                .IsRequired(true)
                .HasMaxLength(80);

            builder
                .Property(u => u.Email)
                .IsRequired(true)
                .HasMaxLength(80);
        }
    }
}
