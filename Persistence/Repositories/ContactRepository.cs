using Dapper;
using Domain.Request;
using Infrastructure.Context;
using Persistence.Contract;
using Persistence.Sql;

namespace Persistence.Repositories;
public class ContactRepository(IDbContext db) : IContactRepository
{
    public async Task<bool> Create(CreateContactRequest request)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@Name", request.Name);
        parameters.Add("@DDD", request.DDD);
        parameters.Add("@Telephone", request.Telephone);
        parameters.Add("@Email", request.Email);

        return await db.Context.ExecuteScalarAsync<bool>(ContactSql.Insert, parameters);
    }
}
