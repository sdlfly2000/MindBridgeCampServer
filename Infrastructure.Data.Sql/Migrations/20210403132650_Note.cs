using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Sql.Migrations
{
    public partial class Note : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NoteComments",
                columns: table => new
                {
                    commentId = table.Column<string>(nullable: false),
                    noteId = table.Column<string>(nullable: true),
                    createdOn = table.Column<DateTime>(nullable: false),
                    createdBy = table.Column<string>(nullable: true),
                    content = table.Column<string>(nullable: true),
                    rate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteComments", x => x.commentId);
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    noteId = table.Column<string>(nullable: false),
                    createdBy = table.Column<string>(nullable: true),
                    createdOn = table.Column<DateTime>(nullable: false),
                    content = table.Column<string>(nullable: true),
                    title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.noteId);
                });

            migrationBuilder.CreateTable(
                name: "NoteTags",
                columns: table => new
                {
                    tagId = table.Column<string>(nullable: false),
                    noteId = table.Column<string>(nullable: true),
                    createdOn = table.Column<DateTime>(nullable: false),
                    createdBy = table.Column<string>(nullable: true),
                    caption = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteTags", x => x.tagId);
                });

            migrationBuilder.CreateTable(
                name: "NoteViewers",
                columns: table => new
                {
                    viewerId = table.Column<string>(nullable: false),
                    noteId = table.Column<string>(nullable: true),
                    createdOn = table.Column<DateTime>(nullable: false),
                    createdBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteViewers", x => x.viewerId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NoteComments");

            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "NoteTags");

            migrationBuilder.DropTable(
                name: "NoteViewers");
        }
    }
}
