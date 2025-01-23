using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.AccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class RemovePrescriptionForeignKey_Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Prescripti__D_ID__3B75D760",
                table: "Prescription");

            migrationBuilder.DropForeignKey(
                name: "FK__Prescripti__P_ID__3A81B327",
                table: "Prescription");

            //migrationBuilder.DropIndex(
            //    name: "IX_Prescription_DoctorId",
            //    table: "Prescription");

            //migrationBuilder.DropIndex(
            //    name: "IX_Prescription_PatientId",
            //    table: "Prescription");

            //migrationBuilder.DropColumn(
            //    name: "DoctorId",
            //    table: "Prescription");

            //migrationBuilder.DropColumn(
            //    name: "PatientId",
            //    table: "Prescription");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "Prescription",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "Prescription",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_DoctorId",
                table: "Prescription",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_PatientId",
                table: "Prescription",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_Doctors_DoctorId",
                table: "Prescription",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_Patients_PatientId",
                table: "Prescription",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "ID");
        }
    }
}
