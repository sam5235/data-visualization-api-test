using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace data_visualization_api.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateChartAttribute : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Published",
                table: "Charts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Share",
                table: "Charts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Published",
                table: "Charts");

            migrationBuilder.DropColumn(
                name: "Share",
                table: "Charts");
        }
    }
}
