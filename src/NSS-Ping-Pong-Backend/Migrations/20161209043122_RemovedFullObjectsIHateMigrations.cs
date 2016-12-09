using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NSSPingPongBackend.Migrations
{
    public partial class RemovedFullObjectsIHateMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GamePlayer_Player_PlayerId",
                table: "GamePlayer");

            migrationBuilder.DropIndex(
                name: "IX_GamePlayer_PlayerId",
                table: "GamePlayer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_GamePlayer_PlayerId",
                table: "GamePlayer",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_GamePlayer_Player_PlayerId",
                table: "GamePlayer",
                column: "PlayerId",
                principalTable: "Player",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
