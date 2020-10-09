using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityIntro.Migrations
{
    public partial class AddedManyToManyStuff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Evidence",
                columns: table => new
                {
                    EvidenceId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evidence", x => x.EvidenceId);
                });

            migrationBuilder.CreateTable(
                name: "Ghosts",
                columns: table => new
                {
                    GhostId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ghosts", x => x.GhostId);
                });

            migrationBuilder.CreateTable(
                name: "GhostsHaveEvidence",
                columns: table => new
                {
                    GhostHasEvidenceId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    GhostId = table.Column<int>(nullable: false),
                    EvidenceId = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GhostsHaveEvidence", x => x.GhostHasEvidenceId);
                    table.ForeignKey(
                        name: "FK_GhostsHaveEvidence_Evidence_EvidenceId",
                        column: x => x.EvidenceId,
                        principalTable: "Evidence",
                        principalColumn: "EvidenceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GhostsHaveEvidence_Ghosts_GhostId",
                        column: x => x.GhostId,
                        principalTable: "Ghosts",
                        principalColumn: "GhostId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GhostsHaveEvidence_EvidenceId",
                table: "GhostsHaveEvidence",
                column: "EvidenceId");

            migrationBuilder.CreateIndex(
                name: "IX_GhostsHaveEvidence_GhostId",
                table: "GhostsHaveEvidence",
                column: "GhostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GhostsHaveEvidence");

            migrationBuilder.DropTable(
                name: "Evidence");

            migrationBuilder.DropTable(
                name: "Ghosts");
        }
    }
}
