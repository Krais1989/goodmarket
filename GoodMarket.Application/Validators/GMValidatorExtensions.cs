using System.Reflection;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace GoodMarket.Application.Validators
{
    public static class GMValidatorExtensions
    {
        public static IMvcBuilder AddGMValidators(this IMvcBuilder mvc)
        {
            mvc.AddFluentValidation(cfg =>
            {
                cfg.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            });
            return mvc;
        }
    }
}
