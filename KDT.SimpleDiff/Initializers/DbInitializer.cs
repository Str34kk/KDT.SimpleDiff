using System.Data;
using KDT.SimpleDiff.Factories;

namespace KDT.SimpleDiff.Initializers;

public class DbInitializer
{
    private readonly IDbConnectionFactory _connectionFactory;

    public DbInitializer(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }
    
    public async Task InitializeAsync()
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();
        
        using (IDbCommand command = connection.CreateCommand())
        {
            command.CommandText = 
                @"CREATE TABLE IF NOT EXISTS Diff (
                Id CHAR(36) PRIMARY KEY, 
                ObjectValue TEXT NOT NULL
                )";
            
            command.ExecuteNonQuery();
        }
    }
}