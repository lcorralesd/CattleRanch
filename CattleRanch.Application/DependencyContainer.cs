using CattleRanch.Application.UseCases.Animals.Commands.Create;
using CattleRanch.Application.UseCases.Animals.Commands.Update;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CattleRanch.Application;
public static class DependencyContainer
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        // Validators
        services.AddScoped<Kernel.Exceptions.Interfaces.IValidator<CreateAnimalCommand>, CreateAnimalValidator>();
        services.AddScoped<Kernel.Exceptions.Interfaces.IValidator<CreateAnimalCommand>, CreateAnimalPersistenceValidator>();
        services.AddScoped<Kernel.Exceptions.Interfaces.IValidator<UpdateAnimalCommand>, UpdateAnimalValidator>();
        services.AddScoped<Kernel.Exceptions.Interfaces.IValidator<UpdateAnimalCommand>, UpdateAnimalPersistenceValidator>();

        return services;
    }
}
