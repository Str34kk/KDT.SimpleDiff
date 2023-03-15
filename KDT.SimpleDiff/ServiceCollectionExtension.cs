using KDT.SimpleDiff.Factories;
using KDT.SimpleDiff.Initializers;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace KDT.SimpleDiff;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddSimpleDiff(this IServiceCollection services, string connectionString)
    {
         _ = services.AddSingleton<IDbConnectionFactory>(_ => new DbConnectionFactory(connectionString: connectionString));
         _ = services.AddSingleton<DbInitializer>();

        return services;
    }
    
    public static IApplicationBuilder UseSimpleDiff(this IApplicationBuilder builder)
    {
        var test = builder.ApplicationServices.GetRequiredService<DbInitializer>();
        test.InitializeAsync();
        
        return builder;
    }
}