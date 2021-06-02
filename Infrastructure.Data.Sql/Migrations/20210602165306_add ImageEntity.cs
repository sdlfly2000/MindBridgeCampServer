using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Sql.Migrations
{
    public partial class addImageEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    imageId = table.Column<string>(nullable: false),
                    extension = table.Column<string>(nullable: true),
                    createdBy = table.Column<string>(nullable: true),
                    createdOn = table.Column<DateTime>(nullable: false),
                    status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.imageId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");
        }
    }
}
