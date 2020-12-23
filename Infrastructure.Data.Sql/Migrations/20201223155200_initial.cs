using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Sql.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chats",
                columns: table => new
                {
                    chatId = table.Column<string>(nullable: false),
                    roomId = table.Column<string>(nullable: true),
                    createdBy = table.Column<string>(nullable: true),
                    createdOn = table.Column<DateTime>(nullable: false),
                    content = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => x.chatId);
                });

            migrationBuilder.CreateTable(
                name: "Participants",
                columns: table => new
                {
                    participantId = table.Column<string>(nullable: false),
                    roomId = table.Column<string>(nullable: true),
                    userId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participants", x => x.participantId);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    roomId = table.Column<string>(nullable: false),
                    title = table.Column<string>(nullable: true),
                    learningContent = table.Column<string>(nullable: true),
                    startDate = table.Column<DateTime>(nullable: false),
                    endDate = table.Column<DateTime>(nullable: false),
                    participantCount = table.Column<int>(nullable: false),
                    place = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.roomId);
                });

            migrationBuilder.CreateTable(
                name: "SignIns",
                columns: table => new
                {
                    signInId = table.Column<string>(nullable: false),
                    roomId = table.Column<string>(nullable: true),
                    signInOn = table.Column<DateTime>(nullable: false),
                    participant = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SignIns", x => x.signInId);
                });

            migrationBuilder.CreateTable(
                name: "UserInfos",
                columns: table => new
                {
                    openId = table.Column<string>(nullable: false),
                    nickName = table.Column<string>(nullable: true),
                    avatarUrl = table.Column<string>(nullable: true),
                    country = table.Column<string>(nullable: true),
                    province = table.Column<string>(nullable: true),
                    city = table.Column<string>(nullable: true),
                    language = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfos", x => x.openId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    userId = table.Column<string>(nullable: false),
                    gender = table.Column<int>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    majorIn = table.Column<string>(nullable: true),
                    height = table.Column<int>(nullable: true),
                    weight = table.Column<int>(nullable: true),
                    studyContent = table.Column<string>(nullable: true),
                    expectationAfterGraduation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.userId);
                });

            migrationBuilder.CreateTable(
                name: "HobbyEntity",
                columns: table => new
                {
                    hobbyId = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(nullable: false),
                    isActive = table.Column<bool>(nullable: false),
                    UserEntityuserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HobbyEntity", x => x.hobbyId);
                    table.ForeignKey(
                        name: "FK_HobbyEntity_Users_UserEntityuserId",
                        column: x => x.UserEntityuserId,
                        principalTable: "Users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HobbyEntity_UserEntityuserId",
                table: "HobbyEntity",
                column: "UserEntityuserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chats");

            migrationBuilder.DropTable(
                name: "HobbyEntity");

            migrationBuilder.DropTable(
                name: "Participants");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "SignIns");

            migrationBuilder.DropTable(
                name: "UserInfos");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
