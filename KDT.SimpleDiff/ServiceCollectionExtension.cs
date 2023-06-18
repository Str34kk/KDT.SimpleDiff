using KDT.SimpleDiff.Database;
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
        _ = services.AddDbContext<SimpleDiffDbContext>();
        //_ = services.AddSingleton<IDbConnectionFactory>(_ => new DbConnectionFactory(connectionString: connectionString));
        _ = services.AddScoped<IDbInitializer, DbInitializer>();

        return services;
    }
    
    public static IApplicationBuilder UseSimpleDiff(this IApplicationBuilder builder)
    {
        using var scope = builder.ApplicationServices.CreateScope();
        var test = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
        test?.InitializeAsync();
        
        return builder;
    }
}