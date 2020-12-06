using Microsoft.EntityFrameworkCore.Migrations;

namespace CustomInvoice.WebApp.Data.Migrations
{
    public partial class seedproducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                insert into [dbo].[Products] (Name, ShortName, Manufacturer, PartnerId, CategoryId, WarrantyInMonths, Type, UnitOfMeasure, PurchasePrice, SellingPrice) 
                values ('Intel Core i5 10400F BOX procesor, Comet Lake', 'i510400F', 'Intel', 1, 1, 36, 'Artikel', 'kos', 130.11, 174.93);

                insert into [dbo].[Products] (Name, ShortName, Manufacturer, PartnerId, CategoryId, WarrantyInMonths, Type, UnitOfMeasure, PurchasePrice, SellingPrice) 
                values ('AMD procesor Ryzen 5 2600 s hladilnikom Wraith Stealth', '1206870', 'AMD', 1, 1, 36, 'Artikel', 'kos', 98.75, 143.92);

                insert into [dbo].[Products] (Name, ShortName, Manufacturer, PartnerId, CategoryId, WarrantyInMonths, Type, UnitOfMeasure, PurchasePrice, SellingPrice) 
                values ('Noctua NH-L9i procesorski hladilnik z ventilatorjem, 92mm', 'Noctua NH-L9i', 'Noctua', 1, 2, 72, 'Artikel', 'kos', 29.99, 39.26);

                insert into [dbo].[Products] (Name, ShortName, Manufacturer, PartnerId, CategoryId, WarrantyInMonths, Type, UnitOfMeasure, PurchasePrice, SellingPrice) 
                values ('Čiščenje prenosnika', NULL, NULL, NULL, NULL, 0, 'Storitev', 'x', 0, 30);

                insert into [dbo].[Products] (Name, ShortName, Manufacturer, PartnerId, CategoryId, WarrantyInMonths, Type, UnitOfMeasure, PurchasePrice, SellingPrice) 
                values ('Namestitev operacijskega sistema Windows 10 Home', NULL, NULL, NULL, NULL, 0, 'Storitev', 'x', 0, 100);
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
