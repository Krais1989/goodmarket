using GoodMarket.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using GoodMarket.Domain.Entities.Identities;

namespace GoodMarket.Application
{
    /// <summary>
    /// Менеджер юзеров
    /// </summary>
    public class GMRoleManager : RoleManager<Role>
    {
        public GMRoleManager(IRoleStore<Role> store, IEnumerable<IRoleValidator<Role>> roleValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, ILogger<RoleManager<Role>> logger) 
            : base(store, roleValidators, keyNormalizer, errors, logger)
        {
        }
    }
}
