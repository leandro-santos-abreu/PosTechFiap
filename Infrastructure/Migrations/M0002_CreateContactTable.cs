using FluentMigrator;

namespace DatabaseMigration.Migrations
{
    [Migration(2)]
    public class M0002_CreateContactTable : Migration
    {
        public override void Up()
        {
            Execute.Sql(@"
            CREATE TABLE [Contact]
            (
	            [Id] INT IDENTITY (1, 1) NOT NULL,
	            [Name] NVARCHAR(200) NOT NULL,
	            [DDD] INT NOT NULL,
	            [Telephone] NVARCHAR(9) NOT NULL,
	            [Email] NVARCHAR(100) NULL
	            CONSTRAINT [PK_ContactId] PRIMARY KEY NONCLUSTERED ([Id] ASC)
	            CONSTRAINT [FK_Contact_DDD] FOREIGN KEY ([DDD]) REFERENCES [dbo].[DDD] ([DDD])
            )
            ");
        }

        public override void Down()
        {
            Delete.Table("Contact");
        }
    }
}