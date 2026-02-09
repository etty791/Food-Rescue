using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodRescue.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUserLink : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "charities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "businesses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_charities_UserId",
                table: "charities",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_businesses_UserId",
                table: "businesses",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_businesses_Users_UserId",
                table: "businesses",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_charities_Users_UserId",
                table: "charities",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_businesses_Users_UserId",
                table: "businesses");

            migrationBuilder.DropForeignKey(
                name: "FK_charities_Users_UserId",
                table: "charities");

            migrationBuilder.DropIndex(
                name: "IX_charities_UserId",
                table: "charities");

            migrationBuilder.DropIndex(
                name: "IX_businesses_UserId",
                table: "businesses");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "charities");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "businesses");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
