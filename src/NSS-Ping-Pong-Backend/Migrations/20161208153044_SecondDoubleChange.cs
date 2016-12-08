using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NSSPingPongBackend.Migrations
{
    public partial class SecondDoubleChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "TeamTwoScore",
                table: "Game",
                nullable: false);

            migrationBuilder.AlterColumn<double>(
                name: "TeamOneScore",
                table: "Game",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TeamTwoScore",
                table: "Game",
                nullable: false);

            migrationBuilder.AlterColumn<int>(
                name: "TeamOneScore",
                table: "Game",
                nullable: false);
        }
    }
}
