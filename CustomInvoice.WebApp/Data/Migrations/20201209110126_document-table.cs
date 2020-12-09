using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CustomInvoice.WebApp.Data.Migrations
{
    public partial class documenttable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<byte>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<byte>(nullable: false),
                    OfferDate = table.Column<DateTime>(nullable: true),
                    OfferValidityDays = table.Column<int>(nullable: true),
                    OfferDateOfOrder = table.Column<DateTime>(nullable: true),
                    InvoiceDate = table.Column<DateTime>(nullable: true),
                    InvoiceServiceFrom = table.Column<DateTime>(nullable: true),
                    InvoiceServiceUntil = table.Column<DateTime>(nullable: true),
                    InvoiceDateOfMaturity = table.Column<DateTime>(nullable: true),
                    InvoiceDateOfOrder = table.Column<DateTime>(nullable: true),
                    DeliveryNoteDate = table.Column<DateTime>(nullable: true),
                    TotalExcludingVAT = table.Column<decimal>(nullable: true),
                    DiscountPercent = table.Column<decimal>(nullable: true),
                    DiscountAmount = table.Column<decimal>(nullable: true),
                    AmountExcludingVAT = table.Column<decimal>(nullable: true),
                    AmountIncludingVAT = table.Column<decimal>(nullable: true),
                    PaidAmount = table.Column<decimal>(nullable: true),
                    IsPreforma = table.Column<bool>(nullable: false),
                    IsInvoice = table.Column<bool>(nullable: false),
                    IsDeliveryNote = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documents_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Documents_ClientId",
                table: "Documents",
                column: "ClientId");

            migrationBuilder.Sql(@"
                insert into [dbo].[Documents] (ClientId, IsPreforma, IsInvoice, IsDeliveryNote) values (1, 'true', 'false', 'false');
                insert into [dbo].[Documents] (ClientId, IsPreforma, IsInvoice, IsDeliveryNote) values (2, 'true', 'true', 'false');
                insert into [dbo].[Documents] (ClientId, IsPreforma, IsInvoice, IsDeliveryNote) values (3, 'true', 'true', 'true');
            ");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Documents");
        }
    }
}
