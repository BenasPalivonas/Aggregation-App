using Microsoft.Extensions.DependencyInjection;
using AggregationApp.Application.Context;
using AggregationApp.Domain.Abstractions;
using AggregationApp.Domain.Apartments;

namespace AggregationApp.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Add MediatR with handlers from the Application assembly
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
        });

        // Register UoW, and other services
        // services.AddTransient<IUnitOfWork, DapperUnitOfWork>();
        services.AddTransient<PrioritySuggestionService>();

        return services;
    }
}