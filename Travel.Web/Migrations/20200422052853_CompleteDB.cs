using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Travel.Web.Migrations
{
    public partial class CompleteDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Trips",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalAmount",
                table: "Trips",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "ExpenseTypeId",
                table: "TripDetails",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Document = table.Column<string>(maxLength: 20, nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExpenseTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trips_EmployeeId",
                table: "Trips",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_TripDetails_ExpenseTypeId",
                table: "TripDetails",
                column: "ExpenseTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_TripDetails_ExpenseTypes_ExpenseTypeId",
                table: "TripDetails",
                column: "ExpenseTypeId",
                principalTable: "ExpenseTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Employees_EmployeeId",
                table: "Trips",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TripDetails_ExpenseTypes_ExpenseTypeId",
                table: "TripDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Employees_EmployeeId",
                table: "Trips");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "ExpenseTypes");

            migrationBuilder.DropIndex(
                name: "IX_Trips_EmployeeId",
                table: "Trips");

            migrationBuilder.DropIndex(
                name: "IX_TripDetails_ExpenseTypeId",
                table: "TripDetails");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "ExpenseTypeId",
                table: "TripDetails");
        }
    }
}
