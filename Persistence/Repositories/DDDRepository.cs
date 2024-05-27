namespace Persistence.Repositories;
public class DDDRepository(IDbContext db) : IDDDRepository
{
    public Task<bool> Exists(int DDD)
    {
        return db.Context.ExecuteScalarAsync<bool>(DDDSql.Exists, new { DDD });
    }
}
