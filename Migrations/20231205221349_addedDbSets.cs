using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessPortal.Migrations
{
    /// <inheritdoc />
    public partial class addedDbSets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodJournal_FoodNutrition_FoodNutritionID",
                table: "FoodJournal");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodJournal_Users_UserID",
                table: "FoodJournal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FoodNutrition",
                table: "FoodNutrition");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FoodJournal",
                table: "FoodJournal");

            migrationBuilder.RenameTable(
                name: "FoodNutrition",
                newName: "FoodsNutrition");

            migrationBuilder.RenameTable(
                name: "FoodJournal",
                newName: "FoodsJournal");

            migrationBuilder.RenameIndex(
                name: "IX_FoodJournal_UserID",
                table: "FoodsJournal",
                newName: "IX_FoodsJournal_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_FoodJournal_FoodNutritionID",
                table: "FoodsJournal",
                newName: "IX_FoodsJournal_FoodNutritionID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FoodsNutrition",
                table: "FoodsNutrition",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FoodsJournal",
                table: "FoodsJournal",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodsJournal_FoodsNutrition_FoodNutritionID",
                table: "FoodsJournal",
                column: "FoodNutritionID",
                principalTable: "FoodsNutrition",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodsJournal_Users_UserID",
                table: "FoodsJournal",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodsJournal_FoodsNutrition_FoodNutritionID",
                table: "FoodsJournal");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodsJournal_Users_UserID",
                table: "FoodsJournal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FoodsNutrition",
                table: "FoodsNutrition");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FoodsJournal",
                table: "FoodsJournal");

            migrationBuilder.RenameTable(
                name: "FoodsNutrition",
                newName: "FoodNutrition");

            migrationBuilder.RenameTable(
                name: "FoodsJournal",
                newName: "FoodJournal");

            migrationBuilder.RenameIndex(
                name: "IX_FoodsJournal_UserID",
                table: "FoodJournal",
                newName: "IX_FoodJournal_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_FoodsJournal_FoodNutritionID",
                table: "FoodJournal",
                newName: "IX_FoodJournal_FoodNutritionID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FoodNutrition",
                table: "FoodNutrition",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FoodJournal",
                table: "FoodJournal",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodJournal_FoodNutrition_FoodNutritionID",
                table: "FoodJournal",
                column: "FoodNutritionID",
                principalTable: "FoodNutrition",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodJournal_Users_UserID",
                table: "FoodJournal",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
