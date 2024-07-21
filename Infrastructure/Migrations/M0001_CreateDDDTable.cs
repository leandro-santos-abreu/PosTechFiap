using FluentMigrator;
namespace DatabaseMigration.Migrations
{
    [Migration(1)]
    public class M0001_CreateDDDTable : Migration
    {
        public override void Up()
        {
            Execute.Sql("CREATE TABLE [dbo].[DDD] ([DDD] INT NOT NULL PRIMARY KEY,[UF] CHAR(2) NOT NULL)");
        }

        public override void Down()
        {
            Delete.Table("DDD");
        }
    }
}