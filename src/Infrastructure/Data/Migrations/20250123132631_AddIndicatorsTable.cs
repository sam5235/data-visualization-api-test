using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace data_visualization_api.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddIndicatorsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Indicators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RootIndicatorId = table.Column<int>(type: "int", nullable: false),
                    ShortNameEn = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ShortNameFr = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameFr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionFr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModeEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModeFr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitFr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScaleEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScaleFr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Multiplier = table.Column<double>(type: "float", nullable: false),
                    RoundLevel = table.Column<int>(type: "int", nullable: false),
                    TopicIds = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Indicators", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Indicators");
        }
    }
}
