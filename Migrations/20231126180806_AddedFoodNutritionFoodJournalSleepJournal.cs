using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessPortal.Migrations
{
    /// <inheritdoc />
    public partial class AddedFoodNutritionFoodJournalSleepJournal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FoodNutrition",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    Kcal = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodNutrition", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SleepJournal",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    From = table.Column<DateTime>(type: "datetime2", nullable: false),
                    To = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SleepJournal", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SleepJournal_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FoodJournal",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<float>(type: "real", nullable: false),
                    KcalTotal = table.Column<float>(type: "real", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FoodID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FoodNutritionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodJournal", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FoodJournal_FoodNutrition_FoodNutritionID",
                        column: x => x.FoodNutritionID,
                        principalTable: "FoodNutrition",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodJournal_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoodJournal_FoodNutritionID",
                table: "FoodJournal",
                column: "FoodNutritionID");

            migrationBuilder.CreateIndex(
                name: "IX_FoodJournal_UserID",
                table: "FoodJournal",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_SleepJournal_UserID",
                table: "SleepJournal",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodJournal");

            migrationBuilder.DropTable(
                name: "SleepJournal");

            migrationBuilder.DropTable(
                name: "FoodNutrition");
        }
    }
}
