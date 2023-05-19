using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class AddMigrationRelasi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "role_id",
                table: "tb_tr_account_roles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "account_nik",
                table: "tb_tr_account_roles",
                type: "char(5)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(5)");

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_account_roles_account_nik",
                table: "tb_tr_account_roles",
                column: "account_nik");

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_account_roles_role_id",
                table: "tb_tr_account_roles",
                column: "role_id");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_m_accounts_tb_m_employees_employee_nik",
                table: "tb_m_accounts",
                column: "employee_nik",
                principalTable: "tb_m_employees",
                principalColumn: "nik",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_tr_account_roles_tb_m_accounts_account_nik",
                table: "tb_tr_account_roles",
                column: "account_nik",
                principalTable: "tb_m_accounts",
                principalColumn: "employee_nik",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_tr_account_roles_tb_m_roles_role_id",
                table: "tb_tr_account_roles",
                column: "role_id",
                principalTable: "tb_m_roles",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_m_accounts_tb_m_employees_employee_nik",
                table: "tb_m_accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_tr_account_roles_tb_m_accounts_account_nik",
                table: "tb_tr_account_roles");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_tr_account_roles_tb_m_roles_role_id",
                table: "tb_tr_account_roles");

            migrationBuilder.DropIndex(
                name: "IX_tb_tr_account_roles_account_nik",
                table: "tb_tr_account_roles");

            migrationBuilder.DropIndex(
                name: "IX_tb_tr_account_roles_role_id",
                table: "tb_tr_account_roles");

            migrationBuilder.AlterColumn<int>(
                name: "role_id",
                table: "tb_tr_account_roles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "account_nik",
                table: "tb_tr_account_roles",
                type: "char(5)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "char(5)",
                oldNullable: true);
        }
    }
}
