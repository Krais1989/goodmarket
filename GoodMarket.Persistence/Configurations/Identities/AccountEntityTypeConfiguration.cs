using GoodMarket.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoodMarket.Persistence.Configurations
{
    /// <summary>
    /// Базовая конфигурация для Юзера
    /// </summary>
    public class AccountEntityTypeConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasOne(a => a.Profile).WithOne(p => p.Account).HasForeignKey<Profile>(p => p.AccountId);

            builder.HasMany(e => e.AccountRoles).WithOne(e => e.Account).HasForeignKey(e => e.UserId);
            builder.HasMany(e => e.Claims).WithOne(e => e.Account).HasForeignKey(e => e.UserId);
            builder.HasMany(e => e.Logins).WithOne(e => e.Account).HasForeignKey(e => e.UserId);
            builder.HasMany(e => e.Tokens).WithOne(e => e.Account).HasForeignKey(e => e.UserId);
        }
    }
}
