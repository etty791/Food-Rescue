using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodRescue.Data.Migrations
{
    /// <inheritdoc />
    public partial class changeRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CharityID",
                table: "donations");

            migrationBuilder.CreateTable(
                name: "CharityDonation",
                columns: table => new
                {
                    CharitiesId = table.Column<int>(type: "int", nullable: false),
                    DonationsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharityDonation", x => new { x.CharitiesId, x.DonationsId });
                    table.ForeignKey(
                        name: "FK_CharityDonation_charities_CharitiesId",
                        column: x => x.CharitiesId,
                        principalTable: "charities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharityDonation_donations_DonationsId",
                        column: x => x.DonationsId,
                        principalTable: "donations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_donations_BusinessID",
                table: "donations",
                column: "BusinessID");

            migrationBuilder.CreateIndex(
                name: "IX_CharityDonation_DonationsId",
                table: "CharityDonation",
                column: "DonationsId");

            migrationBuilder.AddForeignKey(
                name: "FK_donations_businesses_BusinessID",
                table: "donations",
                column: "BusinessID",
                principalTable: "businesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_donations_businesses_BusinessID",
                table: "donations");

            migrationBuilder.DropTable(
                name: "CharityDonation");

            migrationBuilder.DropIndex(
                name: "IX_donations_BusinessID",
                table: "donations");

            migrationBuilder.AddColumn<int>(
                name: "CharityID",
                table: "donations",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
