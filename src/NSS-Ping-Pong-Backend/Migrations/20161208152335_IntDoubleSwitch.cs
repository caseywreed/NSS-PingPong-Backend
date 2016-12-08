using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NSSPingPongBackend.Migrations
{
    public partial class IntDoubleSwitch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "WinPercentage",
                table: "Stats",
                nullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "AvgPointDiff",
                table: "Stats",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "WinPercentage",
                table: "Stats",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AvgPointDiff",
                table: "Stats",
                nullable: true);
        }
    }
}
