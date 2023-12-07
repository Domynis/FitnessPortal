using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessPortal.Migrations
{
    /// <inheritdoc />
    public partial class changedFoodIDAttribute : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FoodID",
                table: "FoodsJournal");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FoodID",
                table: "FoodsJournal",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
