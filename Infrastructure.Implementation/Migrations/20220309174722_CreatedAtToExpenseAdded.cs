using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.MsSql.Migrations
{
    public partial class CreatedAtToExpenseAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Commentary",
                table: "Expenses",
                newName: "Comment");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAtUtc",
                table: "Expenses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAtUtc",
                table: "Expenses");

            migrationBuilder.RenameColumn(
                name: "Comment",
                table: "Expenses",
                newName: "Commentary");
        }
    }
}
