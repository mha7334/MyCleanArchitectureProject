﻿using System.Text;

using Application.Common.Interfaces.Persistence;
using Application.Services.Authentication;

using Infrastructure.Authentication;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Repositories;
using Infrastructure.Services;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;


namespace Infrastructure.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddAuth(configuration);
        services.AddPersistence(configuration);
        services.AddScoped<IDateTimeProvider, DateTimeProvider>();
        return services;
    }

    public static IServiceCollection AddPersistence(this IServiceCollection services,
                                                    ConfigurationManager configuration)
    {
        services.AddDbContext<MyCaDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), optionsBuilder =>
                    optionsBuilder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null)));

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IMenuRepository, MenuRepository>();

        return services;
    }
    public static IServiceCollection AddAuth(this IServiceCollection services,
                                             ConfigurationManager configuration)
    {
        var jwtSettings = new JwtSettings();

        configuration.Bind(JwtSettings.SectionName, jwtSettings);

        services.AddSingleton(Options.Create(jwtSettings));

        services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

        services.AddAuthentication()
            .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(jwtSettings.Secret))

            });

        return services;
    }
}
