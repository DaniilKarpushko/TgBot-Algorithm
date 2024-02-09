using Application.Abstractions.Repositories;
using DataAccess.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureDataAccess(
        this IServiceCollection collection)
    {
        collection.AddScoped<IAlgorithmRepository, AlgorithmRepository>();

        return collection;
    }
}