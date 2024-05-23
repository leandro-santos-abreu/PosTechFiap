namespace Persistence.Repositories;
public class DDDRepository(IDbContext db)
{
    public Task<bool> Exists(int DDD)
    {
        return db.Context.ExecuteScalarAsync<bool>(DDDSql.Exists, new { DDD });
    }
}
