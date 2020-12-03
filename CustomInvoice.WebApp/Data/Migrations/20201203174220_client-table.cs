using Microsoft.EntityFrameworkCore.Migrations;

namespace CustomInvoice.WebApp.Data.Migrations
{
    public partial class clienttable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<byte>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Type = table.Column<string>(nullable: false),
                    RegistrationNumber = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 20, nullable: true),
                    taxNumber = table.Column<string>(nullable: true),
                    taxPayer = table.Column<bool>(nullable: false),
                    StreetName = table.Column<string>(maxLength: 50, nullable: true),
                    StreetNumber = table.Column<string>(maxLength: 10, nullable: true),
                    PostNumber = table.Column<string>(maxLength: 10, nullable: true),
                    City = table.Column<string>(maxLength: 30, nullable: true),
                    Country = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });
            migrationBuilder.Sql(@"
                insert into [dbo].[Clients] (RegistrationNumber, Name, Type, Email, PhoneNumber, taxNumber, taxPayer, StreetName, StreetNumber, PostNumber, City, Country) values ('', 'Wilfred Ikringill', 's.p.', 'wikringill0@imgur.com', '821-563-5534', '42980722', 'true', 'Gerald', '516', '2710-257', 'Janas', 'Portugal');
                insert into [dbo].[Clients] (RegistrationNumber, Name, Type, Email, PhoneNumber, taxNumber, taxPayer, StreetName, StreetNumber, PostNumber, City, Country) values ('', 'Lolita List', 's.p.', 'llist1@miibeian.gov.cn', '433-606-0560', '44177093', 'false', 'Northland', '1165', '38-120', 'Czudec', 'Poland');
                insert into [dbo].[Clients] (RegistrationNumber, Name, Type, Email, PhoneNumber, taxNumber, taxPayer, StreetName, StreetNumber, PostNumber, City, Country) values ('', 'Adria Schaumann', 'pravna oseba', 'aschaumann2@wunderground.com', '173-904-6285', '88323374', 'true', 'Menomonie', '15', '', 'Fangfan', 'China');
                insert into [dbo].[Clients] (RegistrationNumber, Name, Type, Email, PhoneNumber, taxNumber, taxPayer, StreetName, StreetNumber, PostNumber, City, Country) values ('', 'Nora Leeb', 'fizicna oseba', 'nleeb3@howstuffworks.com', '383-592-3898', '33181109', 'false', 'Debra', '956', '692327', 'Grazhdanka', 'Russia');
                insert into [dbo].[Clients] (RegistrationNumber, Name, Type, Email, PhoneNumber, taxNumber, taxPayer, StreetName, StreetNumber, PostNumber, City, Country) values ('', 'Venita Harce', 'fizicna oseba', 'vharce4@rambler.ru', '376-255-9633', '64600331', 'true', 'Sherman', '9436', '13560-000', 'São Carlos', 'Brazil');
                insert into [dbo].[Clients] (RegistrationNumber, Name, Type, Email, PhoneNumber, taxNumber, taxPayer, StreetName, StreetNumber, PostNumber, City, Country) values ('', 'Taryn Menlow', 's.p.', 'tmenlow5@howstuffworks.com', '830-174-4879', '99266827', 'true', 'Becker', '1537', '33515', 'Orahovica', 'Croatia');
                insert into [dbo].[Clients] (RegistrationNumber, Name, Type, Email, PhoneNumber, taxNumber, taxPayer, StreetName, StreetNumber, PostNumber, City, Country) values ('', 'Dimitry Jest', 'pravna oseba', 'djest6@hhs.gov', '622-779-1818', '96141409', 'true', 'Glendale', '08086', '', 'Pisang', 'Indonesia');
                insert into [dbo].[Clients] (RegistrationNumber, Name, Type, Email, PhoneNumber, taxNumber, taxPayer, StreetName, StreetNumber, PostNumber, City, Country) values ('', 'Lenna Noriega', 'pravna oseba', 'lnoriega7@eventbrite.com', '642-970-2231', '28513512', 'true', 'Lien', '2769', '', 'Beiqi', 'China');
                insert into [dbo].[Clients] (RegistrationNumber, Name, Type, Email, PhoneNumber, taxNumber, taxPayer, StreetName, StreetNumber, PostNumber, City, Country) values ('', 'Dick Pomfrett', 'pravna oseba', 'dpomfrett8@bluehost.com', '112-893-5146', '81468773', 'false', 'Gateway', '9747', '', 'Matahuasi', 'Peru');
                insert into [dbo].[Clients] (RegistrationNumber, Name, Type, Email, PhoneNumber, taxNumber, taxPayer, StreetName, StreetNumber, PostNumber, City, Country) values ('', 'Dalt Maudson', 's.p.', 'dmaudson9@npr.org', '936-215-1737', '07281412', 'true', 'School', '089', '47897', 'Fiorentino', 'San Marino');
                insert into [dbo].[Clients] (RegistrationNumber, Name, Type, Email, PhoneNumber, taxNumber, taxPayer, StreetName, StreetNumber, PostNumber, City, Country) values ('', 'Conn MacMakin', 's.p.', 'cmacmakina@globo.com', '429-725-4343', '68266615', 'true', 'Dixon', '58', '', 'Xinxi', 'China');
                insert into [dbo].[Clients] (RegistrationNumber, Name, Type, Email, PhoneNumber, taxNumber, taxPayer, StreetName, StreetNumber, PostNumber, City, Country) values ('', 'Tomlin Hambers', 's.p.', 'thambersb@hc360.com', '180-391-0892', '54997135', 'false', 'Talmadge', '04', '', 'Parychy', 'Belarus');
                insert into [dbo].[Clients] (RegistrationNumber, Name, Type, Email, PhoneNumber, taxNumber, taxPayer, StreetName, StreetNumber, PostNumber, City, Country) values ('', 'Shina Denham', 's.p.', 'sdenhamc@ocn.ne.jp', '332-748-0209', '33516856', 'true', 'Johnson', '67', '3215', 'Trnovlje pri Celju', 'Slovenia');
                insert into [dbo].[Clients] (RegistrationNumber, Name, Type, Email, PhoneNumber, taxNumber, taxPayer, StreetName, StreetNumber, PostNumber, City, Country) values ('', 'Neel Joron', 's.p.', 'njorond@squidoo.com', '416-277-5490', '24697731', 'true', 'Thackeray', '18', '651 11', 'Karlstad', 'Sweden');
                insert into [dbo].[Clients] (RegistrationNumber, Name, Type, Email, PhoneNumber, taxNumber, taxPayer, StreetName, StreetNumber, PostNumber, City, Country) values ('', 'Halsey Felder', 's.p.', 'hfeldere@cmu.edu', '493-401-9758', '49476227', 'true', 'Northview', '23689', '287 32', 'Strömsnäsbruk', 'Sweden');
                insert into [dbo].[Clients] (RegistrationNumber, Name, Type, Email, PhoneNumber, taxNumber, taxPayer, StreetName, StreetNumber, PostNumber, City, Country) values ('', 'Pattie Cholonin', 'pravna oseba', 'pcholoninf@hexun.com', '719-738-6923', '54079625', 'true', 'Lawn', '5', '', 'Bonabéri', 'Cameroon');
                insert into [dbo].[Clients] (RegistrationNumber, Name, Type, Email, PhoneNumber, taxNumber, taxPayer, StreetName, StreetNumber, PostNumber, City, Country) values ('', 'Colman Urling', 's.p.', 'curlingg@ox.ac.uk', '578-131-8771', '89651048', 'false', 'Bobwhite', '09057', '23-415', 'Księżpol', 'Poland');
                insert into [dbo].[Clients] (RegistrationNumber, Name, Type, Email, PhoneNumber, taxNumber, taxPayer, StreetName, StreetNumber, PostNumber, City, Country) values ('', 'Ami Cowins', 's.p.', 'acowinsh@free.fr', '197-652-7944', '95578764', 'true', 'Spaight', '3', '', 'Damietta', 'Egypt');
                insert into [dbo].[Clients] (RegistrationNumber, Name, Type, Email, PhoneNumber, taxNumber, taxPayer, StreetName, StreetNumber, PostNumber, City, Country) values ('', 'Dorena Skett', 'fizicna oseba', 'dsketti@cargocollective.com', '900-819-5779', '97643089', 'true', '1st', '340', '2100-309', 'Couço', 'Portugal');
                insert into [dbo].[Clients] (RegistrationNumber, Name, Type, Email, PhoneNumber, taxNumber, taxPayer, StreetName, StreetNumber, PostNumber, City, Country) values ('', 'Peterus Ashingden', 'pravna oseba', 'pashingdenj@vistaprint.com', '119-381-1401', '55322940', 'false', 'Straubel', '39265', '13500-000', 'Rio Claro', 'Brazil');
                insert into [dbo].[Clients] (RegistrationNumber, Name, Type, Email, PhoneNumber, taxNumber, taxPayer, StreetName, StreetNumber, PostNumber, City, Country) values ('', 'Hayward Oddboy', 'pravna oseba', 'hoddboyk@tuttocitta.it', '561-262-9042', '43939337', 'true', 'Judy', '7718', '', 'Káto Miliá', 'Greece');
                insert into [dbo].[Clients] (RegistrationNumber, Name, Type, Email, PhoneNumber, taxNumber, taxPayer, StreetName, StreetNumber, PostNumber, City, Country) values ('', 'Kenny Francescone', 's.p.', 'kfrancesconel@cloudflare.com', '275-739-9476', '09603203', 'false', 'Lien', '69914', '', 'Bambas', 'Peru');
                insert into [dbo].[Clients] (RegistrationNumber, Name, Type, Email, PhoneNumber, taxNumber, taxPayer, StreetName, StreetNumber, PostNumber, City, Country) values ('', 'Devin Manilove', 'pravna oseba', 'dmanilovem@wikimedia.org', '889-483-4389', '78404866', 'true', 'Mayfield', '86', '46000', 'Thung Yang Daeng', 'Thailand');
                insert into [dbo].[Clients] (RegistrationNumber, Name, Type, Email, PhoneNumber, taxNumber, taxPayer, StreetName, StreetNumber, PostNumber, City, Country) values ('', 'Obadiah Manston', 'pravna oseba', 'omanstonn@hp.com', '840-918-8014', '09735223', 'false', 'Brown', '81', '', 'Alis', 'Peru');
                insert into [dbo].[Clients] (RegistrationNumber, Name, Type, Email, PhoneNumber, taxNumber, taxPayer, StreetName, StreetNumber, PostNumber, City, Country) values ('', 'Matty Peterson', 's.p.', 'mpetersono@furl.net', '407-463-8213', '04853627', 'true', 'West', '95304', '2914', 'Sula', 'Philippines');
                insert into [dbo].[Clients] (RegistrationNumber, Name, Type, Email, PhoneNumber, taxNumber, taxPayer, StreetName, StreetNumber, PostNumber, City, Country) values ('', 'Franni Strother', 'fizicna oseba', 'fstrotherp@buzzfeed.com', '854-470-1290', '97528071', 'false', 'Golf', '6', '', 'Bancak Wetan', 'Indonesia');
                insert into [dbo].[Clients] (RegistrationNumber, Name, Type, Email, PhoneNumber, taxNumber, taxPayer, StreetName, StreetNumber, PostNumber, City, Country) values ('', 'Marijn Symcock', 's.p.', 'msymcockq@sciencedirect.com', '992-304-6534', '10235243', 'true', 'Linden', '47318', '7645-215', 'Vila Nova de Milfontes', 'Portugal');
                insert into [dbo].[Clients] (RegistrationNumber, Name, Type, Email, PhoneNumber, taxNumber, taxPayer, StreetName, StreetNumber, PostNumber, City, Country) values ('', 'Paloma O''Mahoney', 's.p.', 'pomahoneyr@jalbum.net', '569-426-8639', '19520956', 'true', 'Havey', '60344', '9604', 'Parang', 'Philippines');
                insert into [dbo].[Clients] (RegistrationNumber, Name, Type, Email, PhoneNumber, taxNumber, taxPayer, StreetName, StreetNumber, PostNumber, City, Country) values ('', 'Everett Pitcock', 's.p.', 'epitcocks@abc.net.au', '216-801-6577', '50589887', 'false', 'Anhalt', '0564', '', 'Huangdu', 'China');
                insert into [dbo].[Clients] (RegistrationNumber, Name, Type, Email, PhoneNumber, taxNumber, taxPayer, StreetName, StreetNumber, PostNumber, City, Country) values ('', 'Audrye Fritchly', 'fizicna oseba', 'afritchlyt@ustream.tv', '601-103-3406', '37377372', 'false', 'Clarendon', '6856', '35890', 'Ovacik', 'Turkey');
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
