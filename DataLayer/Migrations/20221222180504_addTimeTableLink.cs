using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class addTimeTableLink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Time",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "TimeOrderId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TimeOrders",
                columns: table => new
                {
                    TimeOrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeOrders", x => x.TimeOrderId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_TimeOrderId",
                table: "Orders",
                column: "TimeOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_TimeOrders_TimeOrderId",
                table: "Orders",
                column: "TimeOrderId",
                principalTable: "TimeOrders",
                principalColumn: "TimeOrderId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_TimeOrders_TimeOrderId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "TimeOrders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_TimeOrderId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "TimeOrderId",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "Time",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
