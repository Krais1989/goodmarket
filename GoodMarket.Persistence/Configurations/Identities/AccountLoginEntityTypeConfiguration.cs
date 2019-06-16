﻿using GoodMarket.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoodMarket.Persistence.Configurations
{
    /// <summary>
    /// Конфигурация Аккаунт - Утверждение
    /// </summary>
    public class AccountLoginEntityTypeConfiguration : IEntityTypeConfiguration<UserLogin>
    {
        public void Configure(EntityTypeBuilder<UserLogin> builder)
        {
            builder.HasKey(e => e.UserId);
            builder.HasOne(e => e.User).WithMany(e => e.UserLogins).HasForeignKey(e => e.UserId);
        }
    }

}