namespace Persistence.Sql;
public static class DDDSql
{
    public static readonly string Exists = @"
        SELECT 
            1
        FROM 
            [dbo].[DDD] 
        WHERE 
            [DDD] = @DDD
    ";
}
