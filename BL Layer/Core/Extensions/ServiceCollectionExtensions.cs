using Application.API.Commands;
using Application.API.Handlers;
using Application.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace Application.API.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddScoped<ICommand, GetAlgorithmCommand>();
        collection.AddScoped<ICommand, GetAlgorithmListCommand>();
        collection.AddScoped<ICommand, HelpCommand>();

        collection.AddScoped<IHandler, CommandHandler>();
        collection.AddScoped<CommandHandlerProxy>();

        return collection;
    }
}