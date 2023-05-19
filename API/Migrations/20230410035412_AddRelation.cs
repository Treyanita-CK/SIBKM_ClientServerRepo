using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class AddRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "education_id",
                table: "tb_tr_profilings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "university_id",
                table: "tb_m_educations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_profilings_education_id",
                table: "tb_tr_profilings",
                column: "education_id",
                unique: true,
                filter: "[education_id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_educations_university_id",
                table: "tb_m_educations",
                column: "university_id");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_m_educations_tb_m_universities_university_id",
                table: "tb_m_educations",
                column: "university_id",
                principalTable: "tb_m_universities",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_tr_profilings_tb_m_educations_education_id",
                table: "tb_tr_profilings",
                column: "education_id",
                principalTable: "tb_m_educations",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_tr_profilings_tb_m_employees_employee_nik",
                table: "tb_tr_profilings",
                column: "employee_nik",
                principalTable: "tb_m_employees",
                principalColumn: "nik",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_m_educations_tb_m_universities_university_id",
                table: "tb_m_educations");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_tr_profilings_tb_m_educations_education_id",
                table: "tb_tr_profilings");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_tr_profilings_tb_m_employees_employee_nik",
                table: "tb_tr_profilings");

            migrationBuilder.DropIndex(
                name: "IX_tb_tr_profilings_education_id",
                table: "tb_tr_profilings");

            migrationBuilder.DropIndex(
                name: "IX_tb_m_educations_university_id",
                table: "tb_m_educations");

            migrationBuilder.AlterColumn<int>(
                name: "education_id",
                table: "tb_tr_profilings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "university_id",
                table: "tb_m_educations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
