using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace data_visualization_api.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChartTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Charts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SelectedChartType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SelectedIndicatorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Thumbnail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartYear = table.Column<int>(type: "int", nullable: true),
                    EndYear = table.Column<int>(type: "int", nullable: true),
                    XAxisLabel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YAxisLabel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChartTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegendOptions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SelectedCountriesData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SelectedIndicators = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SelectedTopics = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Charts", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropTable(
                name: "Charts");
        }
    }
}
