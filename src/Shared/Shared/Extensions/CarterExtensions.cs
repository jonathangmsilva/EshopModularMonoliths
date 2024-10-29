﻿using System.Reflection;
using Carter;
using Microsoft.Extensions.DependencyInjection;

namespace Shared.Extensions;

public static class CarterExtensions
{
    public static IServiceCollection AddCarterWithAssemblies(this IServiceCollection services,
        params Assembly[] assemblies)
    {
        services.AddCarter(configurator: configurator =>
        {
            foreach (var assembly in assemblies)
            {
                var modules = assembly.GetTypes()
                    .Where(t => t.IsAssignableTo(typeof(ICarterModule))).ToArray();

                configurator.WithModules(modules);
            }
        });

        return services;
    }
}