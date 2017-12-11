using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Novus.Migrations
{
    public partial class ChannelEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ThingSpeakId",
                table: "Channels",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ThingSpeakId",
                table: "Channels",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
