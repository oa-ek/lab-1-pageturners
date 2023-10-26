using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PageTurners.Core.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Edition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AverageRating = table.Column<double>(type: "float", nullable: true),
                    DatePubl = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatePubl = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Edition = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requests_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BookUser",
                columns: table => new
                {
                    ReadBooksId = table.Column<int>(type: "int", nullable: false),
                    UsersReadBooksId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookUser", x => new { x.ReadBooksId, x.UsersReadBooksId });
                    table.ForeignKey(
                        name: "FK_BookUser_AspNetUsers_UsersReadBooksId",
                        column: x => x.UsersReadBooksId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookUser_Books_ReadBooksId",
                        column: x => x.ReadBooksId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookUser1",
                columns: table => new
                {
                    ToReadListId = table.Column<int>(type: "int", nullable: false),
                    UsersReadLaterId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookUser1", x => new { x.ToReadListId, x.UsersReadLaterId });
                    table.ForeignKey(
                        name: "FK_BookUser1_AspNetUsers_UsersReadLaterId",
                        column: x => x.UsersReadLaterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookUser1_Books_ToReadListId",
                        column: x => x.ToReadListId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentatorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_AspNetUsers_CommentatorId",
                        column: x => x.CommentatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comment_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ratings_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ratings_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BookRequestId = table.Column<int>(type: "int", nullable: false),
                    ReviewComment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModeratorId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_AspNetUsers_ModeratorId",
                        column: x => x.ModeratorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reviews_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reviews_Requests_BookRequestId",
                        column: x => x.BookRequestId,
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "38bb0749-e206-497c-974a-0ce947ed11fa", "232097a1-2359-4e4c-a629-fd8b2ead3062", "Moderator", "MODERATOR" },
                    { "8badac42-69eb-41d3-96b7-8a7ef116c566", "24b54164-53b9-45ea-a8f6-0265e7557716", "Admin", "ADMIN" },
                    { "e90aa59b-0838-4572-86f7-da9679827181", "aba09020-4588-4eb4-a896-3f44e45aa960", "Reader", "READER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Login", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Photo", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "73ee5842-5475-4c8a-b9c6-bc40b8b74f18", 0, "5df7c359-c3ec-4818-8062-ac1c0358be2f", new DateTime(2052, 10, 26, 20, 41, 58, 788, DateTimeKind.Local).AddTicks(2348), "admin@pageturners.com", true, false, null, "ivan123", "Іван Сергійович", "ADMIN@PAGETURNERS.COM", "ADMIN@PAGETURNERS.COM", "AQAAAAEAACcQAAAAEGEBbipomf9KOxDGfQyN0WTiEvB/MDP0EBy417tK5KU3gAvWjdRPqtgQNebwvtHyJQ==", null, false, null, "f10348b4-8995-47f5-b6a0-ccba549a2ec8", false, "admin@pageturners.com" },
                    { "e0d8c9c3-eec0-4dc7-b2a6-2bd1b09f9846", 0, "8d51545a-2059-48e1-98c9-5a4ffc53e86f", new DateTime(2044, 10, 26, 20, 41, 58, 788, DateTimeKind.Local).AddTicks(2437), "moderator@pageturners.com", true, false, null, "daria684", "Дарія Петрівна", "MODERATOR@PAGETURNERS.COM", "MODERATOR@PAGETURNERS.COM", "AQAAAAEAACcQAAAAEFaQExYrFCsvpLaojp3XWaqQ+kcOnidf3Iu3FhnZPl09fgnR/qzmcYO84YapkWFwfQ==", null, false, null, "52611960-ea9c-4004-9a4d-ba4f4305379a", false, "moderator@pageturners.com" },
                    { "e14987de-9d3d-4ab6-87b8-f8e4f30addcc", 0, "2679fb4a-b41d-4a26-8de4-3ec6b122ad24", new DateTime(2044, 10, 26, 20, 41, 58, 788, DateTimeKind.Local).AddTicks(2449), "reader@pageturners.com", true, false, null, "anna456", "Анна Олександрівна", "READER@PAGETURNERS.COM", "READER@PAGETURNERS.COM", "AQAAAAEAACcQAAAAEMUiBzZH/e1JCmXZ6VfIIR74YkdZONUlzt334mP1LOQ8U3eBn3J1PeodLxVndEeZEg==", null, false, null, "d4053d82-0f57-4c35-b01d-14b78cf2ba3b", false, "reader@pageturners.com" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "AverageRating", "DatePubl", "Desc", "Edition", "Genre", "Title" },
                values: new object[,]
                {
                    { 1, "Роберт Грін", null, 1998, "Ця книга розглядає стратегії та тактики влади, використовуючи приклади з історії та сучасного бізнесу.", "Viking Press", "Психологія, бізнес", "Ігри влади" },
                    { 2, "Френсіс Скотт Фіцджеральд", null, 1925, "Цей роман розповідає історію багатого і таємничого Джей Гетсбі та його пристрасті до недосяжної коханої Дейзі.", "Charles Scribner's Sons", "Класика, роман", "Великий Гетсбі" },
                    { 3, "Анна Тодд", null, 2014, "Ця книга розповідає про складність переходу від підліткового життя до дорослого, з фокусом на романтичних відносинах.", "Gallery Books", "Роман, молодіжна література", "Після" },
                    { 4, "Джордж Р. Р. Мартін", null, 1996, "Перша книга серії `Пісня льоду і полум'я` розповідає про боротьбу різних родів за трон Залізного Трону у міфічному світі Вестерос.", "Bantam Spectra", "Фентезі, пригоди", "Гра престолів" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "8badac42-69eb-41d3-96b7-8a7ef116c566", "73ee5842-5475-4c8a-b9c6-bc40b8b74f18" },
                    { "38bb0749-e206-497c-974a-0ce947ed11fa", "e0d8c9c3-eec0-4dc7-b2a6-2bd1b09f9846" },
                    { "e90aa59b-0838-4572-86f7-da9679827181", "e14987de-9d3d-4ab6-87b8-f8e4f30addcc" }
                });

            migrationBuilder.InsertData(
                table: "Comment",
                columns: new[] { "Id", "BookId", "Comment", "CommentatorId", "Date" },
                values: new object[,]
                {
                    { 1, 3, "Дуже цікава історія!", "73ee5842-5475-4c8a-b9c6-bc40b8b74f18", new DateTime(2023, 10, 26, 20, 41, 58, 794, DateTimeKind.Local).AddTicks(36) },
                    { 2, 1, "Трохи нудно...", "e0d8c9c3-eec0-4dc7-b2a6-2bd1b09f9846", new DateTime(2023, 10, 26, 20, 41, 58, 794, DateTimeKind.Local).AddTicks(53) }
                });

            migrationBuilder.InsertData(
                table: "Requests",
                columns: new[] { "Id", "Author", "DatePubl", "Desc", "Edition", "Genre", "OwnerId", "Title" },
                values: new object[,]
                {
                    { 1, "Юлія Лабурнум", null, null, null, null, "e0d8c9c3-eec0-4dc7-b2a6-2bd1b09f9846", "Лабіринт часу" },
                    { 2, "Андрій Землянський", null, "Спадщина Марса - це захоплюючий науково-фантастичний роман, який перенося читача у далеке майбутнє, на таємничу і загадкову планету Марс. Автор, Андрій Землянський, розповідає історію групи вчених і дослідників, які вирушають на Марс, щоб розкрити його давні таємниці.", null, null, "73ee5842-5475-4c8a-b9c6-bc40b8b74f18", "Спадщина Марса" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BookUser_UsersReadBooksId",
                table: "BookUser",
                column: "UsersReadBooksId");

            migrationBuilder.CreateIndex(
                name: "IX_BookUser1_UsersReadLaterId",
                table: "BookUser1",
                column: "UsersReadLaterId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_BookId",
                table: "Comment",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_CommentatorId",
                table: "Comment",
                column: "CommentatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_BookId",
                table: "Ratings",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_UserId",
                table: "Ratings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_OwnerId",
                table: "Requests",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_BookRequestId",
                table: "Reviews",
                column: "BookRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ModeratorId",
                table: "Reviews",
                column: "ModeratorId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BookUser");

            migrationBuilder.DropTable(
                name: "BookUser1");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
