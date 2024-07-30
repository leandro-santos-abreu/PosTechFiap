namespace Persistence.Repositories;
public class ContactRepository(IDbContext db) : IContactRepository
{
    public async Task<bool> Create(string Telephone, string Name, int DDD, string Email)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@Name", Name);
        parameters.Add("@DDD", DDD);
        parameters.Add("@Telephone", Telephone);
        parameters.Add("@Email", Email);

        return await db.Context.ExecuteScalarAsync<bool>(ContactSql.Insert, parameters);
    }

    public async Task<IEnumerable<Contact>> Get() => await db.Context.QueryAsync<Contact>(ContactSql.Select);

    public async Task<bool> Exists(int DDD, string Telephone)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@DDD", DDD);
        parameters.Add("@Telephone", Telephone);

        return await db.Context.ExecuteScalarAsync<bool>(ContactSql.Exists, parameters);
    }

    public async Task<bool> Delete(int id)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@id", id);

        return !await db.Context.ExecuteScalarAsync<bool>(ContactSql.Delete, parameters);
    }

    public async Task<bool> Update(int Id, string Telephone, string Name, int DDD, string Email)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@Id", Id);
        parameters.Add("@Name", Name);
        parameters.Add("@DDD", DDD);
        parameters.Add("@Telephone", Telephone);
        parameters.Add("@Email", Email);

        return await db.Context.ExecuteScalarAsync<int>(ContactSql.Update, parameters) > 0;
    }
}