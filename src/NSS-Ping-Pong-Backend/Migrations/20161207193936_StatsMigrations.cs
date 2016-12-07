using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NSSPingPongBackend.Migrations
{
    public partial class StatsMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "FirebaseId",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "GamePlayer");

            migrationBuilder.CreateTable(
                name: "Stats",
                columns: table => new
                {
                    StatsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AvgPointDiff = table.Column<int>(nullable: true),
                    Games = table.Column<int>(nullable: false),
                    Losses = table.Column<int>(nullable: false),
                    PlayerId = table.Column<int>(nullable: false),
                    Rating = table.Column<int>(nullable: true),
                    WinPercentage = table.Column<int>(nullable: true),
                    Wins = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stats", x => x.StatsId);
                    table.ForeignKey(
                        name: "FK_Stats_Player_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Player",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddColumn<int>(
                name: "PointDiff",
                table: "GamePlayer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Team",
                table: "GamePlayer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Won",
                table: "GamePlayer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stats_PlayerId",
                table: "Stats",
                column: "PlayerId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PointDiff",
                table: "GamePlayer");

            migrationBuilder.DropColumn(
                name: "Team",
                table: "GamePlayer");

            migrationBuilder.DropColumn(
                name: "Won",
                table: "GamePlayer");

            migrationBuilder.DropTable(
                name: "Stats");

            migrationBuilder.AddColumn<DateTime>(
                name: "Birthday",
                table: "Player",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "FirebaseId",
                table: "Player",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "GamePlayer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
