using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace data_visualization_api.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChartColumnFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SeletedIndicators",
                table: "Charts",
                newName: "SelectedIndicators");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SelectedIndicators",
                table: "Charts",
                newName: "SeletedIndicators");
        }
    }
}
