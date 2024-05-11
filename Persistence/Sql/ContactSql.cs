namespace Persistence.Sql;
public class ContactSql
{
    public static readonly string Select = @"
        SELECT 
            [Id],
            [Name],
            [DDD],
            [Telephone],
            [Email]
        FROM 
            [dbo].[Contact]
    ";

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

    public static readonly string Exists = @"
        SELECT 
            1
        FROM 
            [dbo].[Contact] 
        WHERE 
            [DDD] = @DDD AND [Telephone] = @Telephone
    ";

    public static readonly string Update = @"
        UPDATE 
            [dbo].[Contact]
        SET 
            [Name] = @Name,
            [DDD] = @DDD,
            [Telephone] = @Telephone,
            [Email] = @Email
        WHERE 
            [Id] = @Id
    ";

    public static readonly string Delete = @"
        DELETE FROM 
            [dbo].[Contact]
        WHERE 
            [Id] = @id
    ";
}
