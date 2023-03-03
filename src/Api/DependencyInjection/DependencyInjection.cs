using Api.Common.Mappings;
using Api.Errors;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Api.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {

        services.AddControllers();

        services.AddSingleton<ProblemDetailsFactory, MyCleanArchitectureProblemDetailsFactory>();

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddMappings();

        return services;
    }
}
