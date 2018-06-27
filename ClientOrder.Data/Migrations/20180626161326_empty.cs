using Microsoft.EntityFrameworkCore.Migrations;

namespace ClientOrder.Data.Migrations
{
    public partial class empty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            var spQuery = @"CREATE PROCEDURE [dbo].[GetClients]
                     @FirstName varchar(50)
                     AS
                     BEGIN
                         SET NOCOUNT ON;
                         select * from Clients where FirstName like @FirstName +'%'
                     END";
            migrationBuilder.Sql(spQuery);

            var spCommand = @"CREATE PROCEDURE CreateClient
                                @FirstName Varchar(50),
                                @LastName Varchar(50)
                            AS
                            BEGIN
                                SET NOCOUNT ON;
                                Insert into Clients(
                                       [FirstName]
                                       ,[LastName]
                                       )
                             Values (@FirstName, @LastName)
                            END
                            GO";

            migrationBuilder.Sql(spCommand);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
