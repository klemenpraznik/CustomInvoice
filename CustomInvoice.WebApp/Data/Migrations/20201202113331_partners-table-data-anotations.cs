using Microsoft.EntityFrameworkCore.Migrations;

namespace CustomInvoice.WebApp.Data.Migrations
{
    public partial class partnerstabledataanotations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "StreetNumber",
                table: "Partners",
                maxLength: 5,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StreetName",
                table: "Partners",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PostNumber",
                table: "Partners",
                maxLength: 8,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Partners",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Partners",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Partners",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.Sql(@"
                insert into [dbo].[Partners] (Name, StreetName, StreetNumber, PostNumber, City, Country, Email, PhoneNumber) values ('Skynoodle', 'Emmet', '6076', null, 'Tianzhen', 'China', 'inurden0@prnewswire.com', '(391) 4265004');
                insert into [dbo].[Partners] (Name, StreetName, StreetNumber, PostNumber, City, Country, Email, PhoneNumber) values ('Oozz', 'Dorton', '7', null, 'Mariara', 'Venezuela', 'ekosel1@mail.ru', '(682) 3192322');
                insert into [dbo].[Partners] (Name, StreetName, StreetNumber, PostNumber, City, Country, Email, PhoneNumber) values ('Skivee', 'Vidon', '3836', null, 'Íasmos', 'Greece', 'fantonoczyk2@arstechnica.com', '(571) 2859443');
                insert into [dbo].[Partners] (Name, StreetName, StreetNumber, PostNumber, City, Country, Email, PhoneNumber) values ('Mita', 'Johnson', '3', null, 'Kilju', 'North Korea', 'nniese3@flavors.me', '(428) 7753627');
                insert into [dbo].[Partners] (Name, StreetName, StreetNumber, PostNumber, City, Country, Email, PhoneNumber) values ('Midel', 'Autumn Leaf', '299', null, 'Yueyang', 'China', 'pcuppitt4@delicious.com', '(370) 1254395');
                insert into [dbo].[Partners] (Name, StreetName, StreetNumber, PostNumber, City, Country, Email, PhoneNumber) values ('Edgeblab', 'Lakeland', '06920', null, 'Aradac', 'Serbia', 'ksaville5@nbcnews.com', '(557) 7987671');
                insert into [dbo].[Partners] (Name, StreetName, StreetNumber, PostNumber, City, Country, Email, PhoneNumber) values ('Myworks', 'Elka', '0466', null, 'Karangsembung', 'Indonesia', 'sblumire6@g.co', '(317) 6071196');
                insert into [dbo].[Partners] (Name, StreetName, StreetNumber, PostNumber, City, Country, Email, PhoneNumber) values ('Flashset', 'Commercial', '4', null, 'Tundagan', 'Indonesia', 'hpicott7@multiply.com', '(690) 2355155');
                insert into [dbo].[Partners] (Name, StreetName, StreetNumber, PostNumber, City, Country, Email, PhoneNumber) values ('Chatterbridge', 'Golden Leaf', '61', '445564', 'Severomorsk', 'Russia', 'owardrope8@youtu.be', '(622) 5805148');
                insert into [dbo].[Partners] (Name, StreetName, StreetNumber, PostNumber, City, Country, Email, PhoneNumber) values ('Twitterworks', 'Park Meadow', '4842', '11705', 'Pedro Santana', 'Dominican Republic', 'bimloch9@desdev.cn', '(346) 2462097');
                insert into [dbo].[Partners] (Name, StreetName, StreetNumber, PostNumber, City, Country, Email, PhoneNumber) values ('Vidoo', 'Orin', '68841', null, 'Burūm', 'Yemen', 'sbraysona@behance.net', '(911) 3789181');
                insert into [dbo].[Partners] (Name, StreetName, StreetNumber, PostNumber, City, Country, Email, PhoneNumber) values ('LiveZ', 'Lotheville', '187', null, 'Jianjiang', 'China', 'gpuddinb@lycos.com', '(974) 3781666');
                insert into [dbo].[Partners] (Name, StreetName, StreetNumber, PostNumber, City, Country, Email, PhoneNumber) values ('Skiba', 'Clarendon', '88', null, 'Methóni', 'Greece', 'sbelsherc@wordpress.com', '(968) 6557332');
                insert into [dbo].[Partners] (Name, StreetName, StreetNumber, PostNumber, City, Country, Email, PhoneNumber) values ('Agivu', 'Maywood', '598', null, 'Caopie', 'China', 'asteansond@reference.com', '(242) 9730852');
                insert into [dbo].[Partners] (Name, StreetName, StreetNumber, PostNumber, City, Country, Email, PhoneNumber) values ('Jaxnation', 'Roth', '02526', null, 'Pecoro', 'Indonesia', 'wlarkinge@archive.org', '(160) 4327524');
                insert into [dbo].[Partners] (Name, StreetName, StreetNumber, PostNumber, City, Country, Email, PhoneNumber) values ('Browseblab', 'Graedel', '6873', '4750-584', 'Oliveira', 'Portugal', 'dffrenchbeytaghf@desdev.cn', '(794) 4553104');
                insert into [dbo].[Partners] (Name, StreetName, StreetNumber, PostNumber, City, Country, Email, PhoneNumber) values ('Twimm', 'Old Gate', '34460', null, 'Dongkengkou', 'China', 'ddeshong@mozilla.org', '(784) 3169350');
                insert into [dbo].[Partners] (Name, StreetName, StreetNumber, PostNumber, City, Country, Email, PhoneNumber) values ('Topdrive', 'Doe Crossing', '8418', null, 'Xitianwei', 'China', 'mgludorh@trellian.com', '(131) 4970897');
                insert into [dbo].[Partners] (Name, StreetName, StreetNumber, PostNumber, City, Country, Email, PhoneNumber) values ('Twitterwire', 'Dottie', '7', '1751', 'La Hacienda', 'Philippines', 'djerchei@google.de', '(349) 3574861');
                insert into [dbo].[Partners] (Name, StreetName, StreetNumber, PostNumber, City, Country, Email, PhoneNumber) values ('Shufflebeat', 'Dennis', '84', '43-365', 'Wilkowice', 'Poland', 'dvanderveldtj@geocities.com', '(971) 1611381');
                insert into [dbo].[Partners] (Name, StreetName, StreetNumber, PostNumber, City, Country, Email, PhoneNumber) values ('Vinder', 'Boyd', '4535', '3720-546', 'Quintã', 'Portugal', 'jcampbelldunlopk@geocities.jp', '(759) 6031226');
                insert into [dbo].[Partners] (Name, StreetName, StreetNumber, PostNumber, City, Country, Email, PhoneNumber) values ('Skippad', 'Pleasure', '202', '679 21', 'Černá Hora', 'Czech Republic', 'jgraeserl@businessweek.com', '(573) 2892883');
                insert into [dbo].[Partners] (Name, StreetName, StreetNumber, PostNumber, City, Country, Email, PhoneNumber) values ('Rhyzio', 'Scott', '9070', null, 'Khawr Fakkān', 'United Arab Emirates', 'gglynnm@amazon.com', '(151) 3374071');
                insert into [dbo].[Partners] (Name, StreetName, StreetNumber, PostNumber, City, Country, Email, PhoneNumber) values ('Centimia', 'Anzinger', '02848', null, 'Pakemitan Dua', 'Indonesia', 'agrahamn@yellowpages.com', '(843) 8391535');
                insert into [dbo].[Partners] (Name, StreetName, StreetNumber, PostNumber, City, Country, Email, PhoneNumber) values ('Skippad', 'Vernon', '28', null, 'Gunungmalang Satu', 'Indonesia', 'mbremingo@google.com.au', '(162) 5067401');
                insert into [dbo].[Partners] (Name, StreetName, StreetNumber, PostNumber, City, Country, Email, PhoneNumber) values ('Wikizz', 'Talisman', '1', null, 'Shaxi', 'China', 'gslesserp@uol.com.br', '(504) 9634832');
                insert into [dbo].[Partners] (Name, StreetName, StreetNumber, PostNumber, City, Country, Email, PhoneNumber) values ('Oyoyo', 'Dryden', '8916', null, 'Cikujang', 'Indonesia', 'rplumq@google.de', '(164) 3316780');
                insert into [dbo].[Partners] (Name, StreetName, StreetNumber, PostNumber, City, Country, Email, PhoneNumber) values ('Layo', 'Glendale', '6766', '59058', 'Jieznas', 'Lithuania', 'amerlinr@printfriendly.com', '(822) 7448939');
                insert into [dbo].[Partners] (Name, StreetName, StreetNumber, PostNumber, City, Country, Email, PhoneNumber) values ('Ooba', 'Prairieview', '33213', '1171', 'Sydney', 'Australia', 'holunnys@telegraph.co.uk', '(897) 2246774');
                insert into [dbo].[Partners] (Name, StreetName, StreetNumber, PostNumber, City, Country, Email, PhoneNumber) values ('Blogtag', 'Esker', '69', null, 'Chalchuapa', 'El Salvador', 'csofet@rambler.ru', '(877) 3335608');
            ");

            //migrationBuilder.CreateTable(
            //    name: "PartnerFormViewModel",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        PartnerId = table.Column<byte>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_PartnerFormViewModel", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_PartnerFormViewModel_Partners_PartnerId",
            //            column: x => x.PartnerId,
            //            principalTable: "Partners",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_PartnerFormViewModel_PartnerId",
            //    table: "PartnerFormViewModel",
            //    column: "PartnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PartnerFormViewModel");

            migrationBuilder.AlterColumn<string>(
                name: "StreetNumber",
                table: "Partners",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 5,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StreetName",
                table: "Partners",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PostNumber",
                table: "Partners",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 8,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Partners",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Partners",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Partners",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 30,
                oldNullable: true);
        }
    }
}
