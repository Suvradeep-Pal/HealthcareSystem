using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Healthcare.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedPatientTableWithCorrection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Patients",
                newName: "Last_Name");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Patients",
                newName: "First_Name");

            migrationBuilder.RenameColumn(
                name: "DateOfBirth",
                table: "Patients",
                newName: "Date_Of_Birth");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Last_Name",
                table: "Patients",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "First_Name",
                table: "Patients",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "Date_Of_Birth",
                table: "Patients",
                newName: "DateOfBirth");
        }
    }
}
