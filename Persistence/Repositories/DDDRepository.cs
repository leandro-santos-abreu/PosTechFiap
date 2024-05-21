namespace Persistence.Repositories;
public class DDDRepository(IDbContext db)
{
    public Task<bool> Exist(int DDD)
    {
        return db.Context.ExecuteScalarAsync<bool>(DDDSql.Exists, new { DDD });
    }
}
