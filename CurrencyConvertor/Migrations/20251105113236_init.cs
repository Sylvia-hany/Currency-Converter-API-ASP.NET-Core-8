using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CurrencyConvertor.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conversions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FromCurrency = table.Column<string>(type: "TEXT", fixedLength: true, maxLength: 3, nullable: false),
                    ToCurrency = table.Column<string>(type: "TEXT", fixedLength: true, maxLength: 3, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Result = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conversions", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Conversions");
        }
    }
}
