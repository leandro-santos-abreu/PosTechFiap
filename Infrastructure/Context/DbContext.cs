using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Context;
public sealed class DbContext : IDbContext
{
    public IDbConnection Context { get; }
    public IDbTransaction Transaction { get; set; } = default!;

    public DbContext(IConfiguration configuration)
    {
        var connectionString = configuration["Settings:DbConnectionString"];
        Context = new SqlConnection(connectionString);
        Context.Open();
    }

    public void Dispose()
    {
        Context.Dispose();
    }
}