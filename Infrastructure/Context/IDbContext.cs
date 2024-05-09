using System.Data;

namespace Infrastructure.Context;
public interface IDbContext : IDisposable
{
    IDbConnection Context { get; }
}