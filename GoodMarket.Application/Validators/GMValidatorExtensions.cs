using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace GoodMarket.Application
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
