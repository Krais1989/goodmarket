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
    public class AccountEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasMany(e => e.UserRoles).WithOne(e => e.User).HasForeignKey(e => e.UserId);
            builder.HasMany(e => e.UserClaims).WithOne(e => e.User).HasForeignKey(e => e.UserId);
            builder.HasMany(e => e.UserLogins).WithOne(e => e.User).HasForeignKey(e => e.UserId);
            builder.HasMany(e => e.UserTokens).WithOne(e => e.User).HasForeignKey(e => e.UserId);
        }
    }
}
