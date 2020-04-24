using Microsoft.EntityFrameworkCore.Migrations;

namespace Travel.Web.Migrations
{
    public partial class AddIndexInNameOnCountry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Countrys_Name",
                table: "Countrys",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Countrys_Name",
                table: "Countrys");
        }
    }
}
