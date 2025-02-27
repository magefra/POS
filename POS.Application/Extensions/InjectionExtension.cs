﻿using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using POS.Application.Interfaces;
using POS.Application.Services;
using System.Reflection;

namespace POS.Application.Extensions
{
    public static class InjectionExtension
    {
        public static IServiceCollection AddInjectionApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConfiguration>(configuration);

            services.AddFluentValidation(opt =>
            {
                opt.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies().Where(p => !p.IsDynamic));
            });


            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<ICategoryApplication, CategoryApplication>();
            services.AddScoped<IUserApplication, UserApplication>();

            return services;
        }
    }
}
