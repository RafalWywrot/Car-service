using FluentMigrator;

namespace CarService.Repository.Migrations
{
    [Migration(1, "fsdaf htrsd")]
    public class Migration1_test : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("TestMigration.sql");
        }

        public override void Down()
        {
        }
    }
}