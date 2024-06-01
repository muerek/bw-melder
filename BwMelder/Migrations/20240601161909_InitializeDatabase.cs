using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BwMelder.Migrations
{
    /// <inheritdoc />
    public partial class InitializeDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Races",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Number = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    RowerCount = table.Column<int>(type: "INTEGER", nullable: false),
                    Coxed = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Races", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeamCoachKeys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Secret = table.Column<Guid>(type: "TEXT", nullable: false),
                    Comment = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamCoachKeys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Crews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ClubName = table.Column<string>(type: "TEXT", nullable: false),
                    RaceId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Crews_Races_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Races",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HomeCoaches",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Contact_Phone = table.Column<string>(type: "TEXT", nullable: false),
                    Contact_EmailAddress = table.Column<string>(type: "TEXT", nullable: false),
                    CrewId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeCoaches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HomeCoaches_Crews_CrewId",
                        column: x => x.CrewId,
                        principalTable: "Crews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Participants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Address_Street = table.Column<string>(type: "TEXT", nullable: false),
                    Address_Zip = table.Column<string>(type: "TEXT", nullable: false),
                    Address_City = table.Column<string>(type: "TEXT", nullable: false),
                    Diet_Choice = table.Column<int>(type: "INTEGER", nullable: false),
                    Diet_Restrictions = table.Column<string>(type: "TEXT", nullable: true),
                    ShirtSize = table.Column<int>(type: "INTEGER", nullable: false),
                    Comments = table.Column<string>(type: "TEXT", nullable: true),
                    HasPublicTransportTicket = table.Column<bool>(type: "INTEGER", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", maxLength: 13, nullable: false),
                    LegalGuardian_FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LegalGuardian_LastName = table.Column<string>(type: "TEXT", nullable: true),
                    LegalGuardian_Contact_Phone = table.Column<string>(type: "TEXT", nullable: true),
                    LegalGuardian_Contact_EmailAddress = table.Column<string>(type: "TEXT", nullable: true),
                    IsCox = table.Column<bool>(type: "INTEGER", nullable: true),
                    CrewId = table.Column<Guid>(type: "TEXT", nullable: true),
                    Contact_Phone = table.Column<string>(type: "TEXT", nullable: true),
                    Contact_EmailAddress = table.Column<string>(type: "TEXT", nullable: true),
                    ClubName = table.Column<string>(type: "TEXT", nullable: true),
                    DriversLicense = table.Column<int>(type: "INTEGER", nullable: true),
                    TeamCoachKeyId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Participants_Crews_CrewId",
                        column: x => x.CrewId,
                        principalTable: "Crews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Participants_TeamCoachKeys_TeamCoachKeyId",
                        column: x => x.TeamCoachKeyId,
                        principalTable: "TeamCoachKeys",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Races",
                columns: new[] { "Id", "Coxed", "Name", "Number", "RowerCount" },
                values: new object[,]
                {
                    { 1, false, "Jung 1x 13", "A", 1 },
                    { 2, false, "Jung 1x 13 LG", "B", 1 },
                    { 3, false, "Mäd 1x 13", "C", 1 },
                    { 4, false, "Mäd 1x 13 LG", "D", 1 },
                    { 5, false, "Jung 2x 12/13", "E", 2 },
                    { 6, false, "Jung 2x 12/13 LG", "F", 2 },
                    { 7, false, "Mäd 2x 12/13", "G", 2 },
                    { 8, false, "Mäd 2x 12/13 LG", "H", 2 },
                    { 9, true, "Jung 4x+ 12/13", "I", 4 },
                    { 10, true, "Mäd 4x+ 12/13", "J", 4 },
                    { 11, true, "Jung/Mäd 4x+ 12/13 Mix", "K", 4 },
                    { 12, false, "Jung 1x 14", "L", 1 },
                    { 13, false, "Jung 1x 14 LG", "M", 1 },
                    { 14, false, "Mäd 1x 14", "N", 1 },
                    { 15, false, "Mäd 1x 14 LG", "O", 1 },
                    { 16, false, "Jung 2x 13/14", "P", 2 },
                    { 17, false, "Jung 2x 13/14 LG", "Q", 2 },
                    { 18, false, "Mäd 2x 13/14", "R", 2 },
                    { 19, false, "Mäd 2x 13/14 LG", "S", 2 },
                    { 20, true, "Jung 4x+ 13/14", "T", 4 },
                    { 21, true, "Mäd 4x+ 13/14", "U", 4 },
                    { 22, true, "Jung/Mäd 4x+ 13/14 Mix", "V", 4 },
                    { 23, false, "SON 2x 12-14 Inklusion", "W", 2 },
                    { 24, false, "SON 1x 12-14 Para", "X", 1 },
                    { 25, false, "SON 2x 15-18 Inklusion", "1", 2 },
                    { 26, false, "SON 1x 15-18 Para", "2", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Crews_RaceId",
                table: "Crews",
                column: "RaceId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeCoaches_CrewId",
                table: "HomeCoaches",
                column: "CrewId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Participants_CrewId",
                table: "Participants",
                column: "CrewId");

            migrationBuilder.CreateIndex(
                name: "IX_Participants_TeamCoachKeyId",
                table: "Participants",
                column: "TeamCoachKeyId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HomeCoaches");

            migrationBuilder.DropTable(
                name: "Participants");

            migrationBuilder.DropTable(
                name: "Crews");

            migrationBuilder.DropTable(
                name: "TeamCoachKeys");

            migrationBuilder.DropTable(
                name: "Races");
        }
    }
}
