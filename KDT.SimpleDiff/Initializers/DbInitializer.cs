using System.Data;
using KDT.SimpleDiff.Database;
using KDT.SimpleDiff.Factories;
using Microsoft.EntityFrameworkCore;

namespace KDT.SimpleDiff.Initializers;

public class DbInitializer : IDbInitializer
{
    // private readonly IDbConnectionFactory _connectionFactory;
    private readonly SimpleDiffDbContext _dbContext;

    public DbInitializer( SimpleDiffDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task InitializeAsync()
    {
        // using var connection = await _connectionFactory.CreateConnectionAsync();
        //
        // using (IDbCommand command = connection.CreateCommand())
        // {
        //     command.CommandText = 
        //         @"CREATE TABLE IF NOT EXISTS Diff (
        //         Id CHAR(36) PRIMARY KEY, 
        //         ObjectValue TEXT NOT NULL
        //         )";
        //     
        //     command.ExecuteNonQuery();
        // }

        await _dbContext.Database.MigrateAsync();
    }
}