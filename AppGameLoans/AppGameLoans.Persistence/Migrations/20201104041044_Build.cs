using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppGameLoans.Persistence.Migrations
{
    public partial class Build : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Friend",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friend", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 60, nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Profile = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Loan",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    FriendId = table.Column<Guid>(nullable: false),
                    GameId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loan_Friend_FriendId",
                        column: x => x.FriendId,
                        principalTable: "Friend",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Loan_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Friend",
                columns: new[] { "Id", "CreationDate", "Name" },
                values: new object[,]
                {
                    { new Guid("093cc1c2-0e67-4017-a90a-3a0a95867c73"), new DateTime(2020, 11, 4, 1, 10, 44, 261, DateTimeKind.Local).AddTicks(3381), "Joe Satriani" },
                    { new Guid("0fc4fa3b-cf21-4a05-818e-ce226e83baaf"), new DateTime(2020, 11, 4, 1, 10, 44, 261, DateTimeKind.Local).AddTicks(3829), "Tom Morelo" },
                    { new Guid("05940e95-7d28-401b-8596-f9800083c90a"), new DateTime(2020, 11, 4, 1, 10, 44, 261, DateTimeKind.Local).AddTicks(3845), "Steve Vai" },
                    { new Guid("63e0f6eb-4141-491c-9fa8-5dd44e9c4469"), new DateTime(2020, 11, 4, 1, 10, 44, 261, DateTimeKind.Local).AddTicks(3847), "Brian May" },
                    { new Guid("9b45ab2a-bce7-4565-96b2-bc4768932888"), new DateTime(2020, 11, 4, 1, 10, 44, 261, DateTimeKind.Local).AddTicks(3848), "Richie Sambora" }
                });

            migrationBuilder.InsertData(
                table: "Game",
                columns: new[] { "Id", "CreationDate", "Name" },
                values: new object[,]
                {
                    { new Guid("c5ba3c4f-ba5b-46e9-a06b-89a59c181a73"), new DateTime(2020, 11, 4, 1, 10, 44, 258, DateTimeKind.Local).AddTicks(7533), "Mortal Kombat Ultimate 4" },
                    { new Guid("2a14bd95-fabb-49b4-989d-ae992c5bb41c"), new DateTime(2020, 11, 4, 1, 10, 44, 259, DateTimeKind.Local).AddTicks(5387), "GTA V" },
                    { new Guid("beb035c6-13b0-422d-91c6-72cf8b1509f7"), new DateTime(2020, 11, 4, 1, 10, 44, 259, DateTimeKind.Local).AddTicks(5419), "Super Mario World" },
                    { new Guid("af7973bd-6628-42e3-9697-36eac3b496e5"), new DateTime(2020, 11, 4, 1, 10, 44, 259, DateTimeKind.Local).AddTicks(5422), "Call of Duty - Warzone" },
                    { new Guid("bc89ca7a-4369-4fcd-a08d-460f589fb3a8"), new DateTime(2020, 11, 4, 1, 10, 44, 259, DateTimeKind.Local).AddTicks(5424), "PLAYERUNKNOWN'S BATTLEGROUNDS" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreationDate", "Email", "Name", "Password", "Profile" },
                values: new object[] { new Guid("49e6fb8c-6776-4361-bad1-9cdcb1dd3872"), new DateTime(2020, 11, 4, 1, 10, 44, 268, DateTimeKind.Local).AddTicks(2535), "usertest@test.com", "User Test", "9abaa0e01aa437fb9b8b1912838581325d63c8af4b5ae69160d45aa528bc39e3", "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Loan_FriendId",
                table: "Loan",
                column: "FriendId");

            migrationBuilder.CreateIndex(
                name: "IX_Loan_GameId",
                table: "Loan",
                column: "GameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Loan");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Friend");

            migrationBuilder.DropTable(
                name: "Game");
        }
    }
}
