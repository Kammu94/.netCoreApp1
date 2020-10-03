using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication3.Migrations
{
    public partial class UserPassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Values");

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "Values",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "Values",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Values",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Values");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "Values");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Values");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Values",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
