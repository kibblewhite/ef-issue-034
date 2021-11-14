using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ef_issue_034.Migrations
{
    public partial class Initialise_Database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.CreateTable(
                name: "Business",
                columns: table => new
                {
                    BusinessId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true, collation: "und-x-icu"),
                    Description = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true, collation: "und-x-icu")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Business", x => x.BusinessId);
                });

            migrationBuilder.CreateTable(
                name: "Subsidiary",
                columns: table => new
                {
                    SubsidiaryId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true, collation: "und-x-icu"),
                    Description = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true, collation: "und-x-icu")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subsidiary", x => x.SubsidiaryId);
                });

            migrationBuilder.CreateTable(
                name: "BusinessSubsidiary",
                columns: table => new
                {
                    BusinessSubsidiaryId = table.Column<Guid>(type: "uuid", nullable: false),
                    BusinessId = table.Column<Guid>(type: "uuid", nullable: false),
                    SubsidiaryId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessSubsidiary", x => x.BusinessSubsidiaryId);
                    table.ForeignKey(
                        name: "FK_BusinessSubsidiary_Business_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Business",
                        principalColumn: "BusinessId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusinessSubsidiary_Subsidiary_SubsidiaryId",
                        column: x => x.SubsidiaryId,
                        principalTable: "Subsidiary",
                        principalColumn: "SubsidiaryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Business_BusinessId",
                table: "Business",
                column: "BusinessId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BusinessSubsidiary_BusinessId",
                table: "BusinessSubsidiary",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessSubsidiary_BusinessSubsidiaryId",
                table: "BusinessSubsidiary",
                column: "BusinessSubsidiaryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BusinessSubsidiary_SubsidiaryId",
                table: "BusinessSubsidiary",
                column: "SubsidiaryId");

            migrationBuilder.CreateIndex(
                name: "IX_Subsidiary_SubsidiaryId",
                table: "Subsidiary",
                column: "SubsidiaryId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusinessSubsidiary");

            migrationBuilder.DropTable(
                name: "Business");

            migrationBuilder.DropTable(
                name: "Subsidiary");
        }
    }
}
