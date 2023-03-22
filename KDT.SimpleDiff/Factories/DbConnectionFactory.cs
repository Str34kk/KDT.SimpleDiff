using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.Data.Sqlite;

namespace KDT.SimpleDiff.Factories;

public interface IDbConnectionFactory
{
    public Task<IDbConnection> CreateConnectionAsync();
}

public class DbConnectionFactory : IDbConnectionFactory
{
    private readonly string _connectionString;

    public DbConnectionFactory(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<IDbConnection> CreateConnectionAsync()
    {
        if (_connectionString.StartsWith("Data Source=:memory:", StringComparison.OrdinalIgnoreCase))
        {
            var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();

            return connection;
        }
        if (_connectionString.StartsWith("Data Source="))
        {
            var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();

            return connection;
        }
        if (_connectionString.StartsWith("Server="))
        {
            var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            return connection;
        }

        throw new ArgumentException("Unknown database type in connection string.");
    }
}