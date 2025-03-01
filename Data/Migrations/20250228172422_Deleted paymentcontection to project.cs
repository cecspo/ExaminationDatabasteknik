using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Deletedpaymentcontectiontoproject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_Payment_PaymentId",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Project_PaymentId",
                table: "Project");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Project_PaymentId",
                table: "Project",
                column: "PaymentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Payment_PaymentId",
                table: "Project",
                column: "PaymentId",
                principalTable: "Payment",
                principalColumn: "Id");
        }
    }
}
