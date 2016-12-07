using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NSSPingPongBackend.Migrations
{
    public partial class SecondStatObjectMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stats_Player_PlayerId",
                table: "Stats");

            migrationBuilder.DropIndex(
                name: "IX_Stats_PlayerId",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "Stats");

            migrationBuilder.AddColumn<int>(
                name: "StatsId",
                table: "Player",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Player_StatsId",
                table: "Player",
                column: "StatsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Player_Stats_StatsId",
                table: "Player",
                column: "StatsId",
                principalTable: "Stats",
                principalColumn: "StatsId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Player_Stats_StatsId",
                table: "Player");

            migrationBuilder.DropIndex(
                name: "IX_Player_StatsId",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "StatsId",
                table: "Player");

            migrationBuilder.AddColumn<int>(
                name: "PlayerId",
                table: "Stats",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Stats_PlayerId",
                table: "Stats",
                column: "PlayerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Stats_Player_PlayerId",
                table: "Stats",
                column: "PlayerId",
                principalTable: "Player",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
