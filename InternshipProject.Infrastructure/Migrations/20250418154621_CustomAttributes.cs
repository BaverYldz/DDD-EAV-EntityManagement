using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InternshipProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CustomAttributes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttributeValues_Attributes_AttributeId",
                table: "AttributeValues");

            migrationBuilder.DropTable(
                name: "Attributes");

            migrationBuilder.CreateTable(
                name: "CustomAttributes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomAttributes", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AttributeValues_CustomAttributes_AttributeId",
                table: "AttributeValues",
                column: "AttributeId",
                principalTable: "CustomAttributes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttributeValues_CustomAttributes_AttributeId",
                table: "AttributeValues");

            migrationBuilder.DropTable(
                name: "CustomAttributes");

            migrationBuilder.CreateTable(
                name: "Attributes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attributes", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AttributeValues_Attributes_AttributeId",
                table: "AttributeValues",
                column: "AttributeId",
                principalTable: "Attributes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
