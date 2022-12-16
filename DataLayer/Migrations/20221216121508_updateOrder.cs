using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class updateOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Spareparts_SparepartId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_SparepartId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "SparepartId",
                table: "Orders");

            migrationBuilder.AlterColumn<string>(
                name: "Date",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "Time",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Time",
                table: "Orders");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SparepartId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_SparepartId",
                table: "Orders",
                column: "SparepartId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Spareparts_SparepartId",
                table: "Orders",
                column: "SparepartId",
                principalTable: "Spareparts",
                principalColumn: "SparepartId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
