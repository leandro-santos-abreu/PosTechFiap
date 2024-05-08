namespace Persistence.Sql;
public class ContactSql
{
    public static readonly string Insert = @"
        INSERT INTO 
        [dbo].[Contact] (
            [Name],
            [DDD],
            [Telephone],
            [Email]
        ) OUTPUT INSERTED.ID VALUES (
            @Name,
            @DDD,
            @Telephone,
            @email
            )
    ";
}
