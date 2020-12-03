using Microsoft.EntityFrameworkCore.Migrations;

namespace CustomInvoice.WebApp.Data.Migrations
{
    public partial class categoriestable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<byte>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

                migrationBuilder.Sql(@"
                    insert into [dbo].[Categories] (Name, Description) values ('Procesorji', 'Procesorji Intel in AMD');
                    insert into [dbo].[Categories] (Name, Description) values ('Hladilniki', 'Zračni in vodni hladilniki za procesor');
                    insert into [dbo].[Categories] (Name, Description) values ('Kabli in pretvorniki', 'Kabli in pretvorniki');
                    insert into [dbo].[Categories] (Name, Description) values ('Krmilniki', 'Krmilniki');
                    insert into [dbo].[Categories] (Name, Description) values ('Miške', 'Žične in brezžične miške');
                    insert into [dbo].[Categories] (Name, Description) values ('Napajalniki', 'ATX napajalniki in napajlaniki za prenosnike');
                    insert into [dbo].[Categories] (Name, Description) values ('Ohišja', 'Ohišja za računalnike: Full tower, Mid-tower, Mini-tower');
                    insert into [dbo].[Categories] (Name, Description) values ('Ohišja ostalo', 'Dodatki za računalniška ohišja');
                    insert into [dbo].[Categories] (Name, Description) values ('Pomnilniki', 'RAM pomnilniki');
                    insert into [dbo].[Categories] (Name, Description) values ('Slušalke', '');
                    insert into [dbo].[Categories] (Name, Description) values ('SSD', 'SSD diski');
                    insert into [dbo].[Categories] (Name, Description) values ('HDD', 'HDD diski');
                    insert into [dbo].[Categories] (Name) values ('Tipkovnice');                    
                ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
