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
                    { new Guid("2db7599d-d522-4f3c-9589-460e33090757"), new DateTime(2020, 11, 4, 1, 21, 4, 522, DateTimeKind.Local).AddTicks(2230), "Joe Satriani" },
                    { new Guid("a6d7a298-55ba-409c-8fd7-1f24bbf21da9"), new DateTime(2020, 11, 4, 1, 21, 4, 522, DateTimeKind.Local).AddTicks(2552), "Tom Morelo" },
                    { new Guid("fece43b1-0ae5-498f-b5bc-b979c573d7ff"), new DateTime(2020, 11, 4, 1, 21, 4, 522, DateTimeKind.Local).AddTicks(2565), "Steve Vai" },
                    { new Guid("b877459a-94b1-47a0-9201-d01569cbd61f"), new DateTime(2020, 11, 4, 1, 21, 4, 522, DateTimeKind.Local).AddTicks(2566), "Brian May" },
                    { new Guid("d72947f5-9ec7-4125-8e62-d55967f36c52"), new DateTime(2020, 11, 4, 1, 21, 4, 522, DateTimeKind.Local).AddTicks(2568), "Richie Sambora" }
                });

            migrationBuilder.InsertData(
                table: "Game",
                columns: new[] { "Id", "CreationDate", "Name" },
                values: new object[,]
                {
                    { new Guid("a0ecfccd-5a0e-4ed6-bdb3-8ae14fc25a9d"), new DateTime(2020, 11, 4, 1, 21, 4, 519, DateTimeKind.Local).AddTicks(8126), "Mortal Kombat Ultimate 4" },
                    { new Guid("2c23a263-8807-4e73-ab5c-2819446ca172"), new DateTime(2020, 11, 4, 1, 21, 4, 520, DateTimeKind.Local).AddTicks(5628), "GTA V" },
                    { new Guid("c650a681-b2d0-4ce4-b562-96bfa49b26c9"), new DateTime(2020, 11, 4, 1, 21, 4, 520, DateTimeKind.Local).AddTicks(5656), "Super Mario World" },
                    { new Guid("84888a8d-324a-49de-a0c3-21d9750c1948"), new DateTime(2020, 11, 4, 1, 21, 4, 520, DateTimeKind.Local).AddTicks(5658), "Call of Duty - Warzone" },
                    { new Guid("86a039ba-234f-462a-ad97-7db821d9ee7a"), new DateTime(2020, 11, 4, 1, 21, 4, 520, DateTimeKind.Local).AddTicks(5671), "PLAYERUNKNOWN'S BATTLEGROUNDS" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreationDate", "Email", "Name", "Password", "Profile" },
                values: new object[] { new Guid("3396d7c9-461d-4121-9a8e-c5fd657c28c3"), new DateTime(2020, 11, 4, 1, 21, 4, 527, DateTimeKind.Local).AddTicks(948), "admin@test.com", "User Admin", "86de0ef85623ee4d916f4b9d6e19d8b60fcf978753fc7a29dd10df582a87272c", "Admin" });

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
