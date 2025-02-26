using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace data_visualization_api.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedChartSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SelectedIndicators",
                table: "Charts");

            migrationBuilder.AlterColumn<string>(
                name: "SelectedTopics",
                table: "Charts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SeletedIndicators",
                table: "Charts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SeletedIndicators",
                table: "Charts");

            migrationBuilder.AlterColumn<string>(
                name: "SelectedTopics",
                table: "Charts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "SelectedIndicators",
                table: "Charts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
