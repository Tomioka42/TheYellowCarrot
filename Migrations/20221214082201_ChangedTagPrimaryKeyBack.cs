using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TheYellowCarrot.Migrations
{
    /// <inheritdoc />
    public partial class ChangedTagPrimaryKeyBack : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Tags_TagName",
                table: "Recipes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tags",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_TagName",
                table: "Recipes");

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Name",
                keyValue: "Glutenfri");

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Name",
                keyValue: "Laktosfri");

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Name",
                keyValue: "Vegan");

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Name",
                keyValue: "Vegetarian");

            migrationBuilder.DropColumn(
                name: "TagName",
                table: "Recipes");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Tags",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "TagId",
                table: "Tags",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tags",
                table: "Tags",
                column: "TagId");

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "TagId", "Name" },
                values: new object[,]
                {
                    { 1, "Vegetarian" },
                    { 2, "Vegan" },
                    { 3, "Glutenfri" },
                    { 4, "Laktosfri" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_TagId",
                table: "Recipes",
                column: "TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Tags_TagId",
                table: "Recipes",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "TagId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Tags_TagId",
                table: "Recipes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tags",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_TagId",
                table: "Recipes");

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyColumnType: "int",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyColumnType: "int",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyColumnType: "int",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyColumnType: "int",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "TagId",
                table: "Tags");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Tags",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "TagName",
                table: "Recipes",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tags",
                table: "Tags",
                column: "Name");

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "RecipeId",
                keyValue: 1,
                column: "TagName",
                value: null);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "RecipeId",
                keyValue: 2,
                column: "TagName",
                value: null);

            migrationBuilder.InsertData(
                table: "Tags",
                column: "Name",
                values: new object[]
                {
                    "Glutenfri",
                    "Laktosfri",
                    "Vegan",
                    "Vegetarian"
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_TagName",
                table: "Recipes",
                column: "TagName");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Tags_TagName",
                table: "Recipes",
                column: "TagName",
                principalTable: "Tags",
                principalColumn: "Name");
        }
    }
}
