using Microsoft.EntityFrameworkCore.Migrations;

namespace ClientOrder.Data.Migrations
{
    public partial class empty_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var spCommand = @"CREATE PROCEDURE CreateClient
                                @FirstName Varchar(50),
                                @LastName Varchar(50),
                                @MiddleName Varchar(50)

                            AS
                            BEGIN
                                SET NOCOUNT ON;
                                Insert into Clients(
                                       [FirstName]
                                       ,[LastName]
                                       ,[MiddleName]
                                       )
                             Values (@FirstName, @LastName, @MiddleName)
                            END
                            GO";

            migrationBuilder.Sql(spCommand);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
