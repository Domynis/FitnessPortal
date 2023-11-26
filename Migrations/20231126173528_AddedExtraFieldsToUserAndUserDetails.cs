using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessPortal.Migrations
{
    /// <inheritdoc />
    public partial class AddedExtraFieldsToUserAndUserDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Age",
                table: "UsersDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<float>(
                name: "BMI",
                table: "UsersDetails",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Height",
                table: "UsersDetails",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KCalGoal",
                table: "UsersDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Roles",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BMI",
                table: "UsersDetails");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "UsersDetails");

            migrationBuilder.DropColumn(
                name: "KCalGoal",
                table: "UsersDetails");

            migrationBuilder.DropColumn(
                name: "Roles",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "Age",
                table: "UsersDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
