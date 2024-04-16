using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankApplication.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddAmountFieldInUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Amount",
                table: "users",
                type: "double",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "users");
        }
    }
}
