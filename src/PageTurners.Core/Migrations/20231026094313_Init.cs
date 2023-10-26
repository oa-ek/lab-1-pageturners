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
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Login", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Photo", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "13b4515e-ba84-4c78-8082-8374d351f1c1", 0, "e91726a0-a3eb-4069-a924-a8252b36a2e2", new DateTime(2044, 10, 26, 12, 43, 12, 858, DateTimeKind.Local).AddTicks(7846), "moderator@pageturners.com", false, false, null, "daria684", "Дарія Петрівна", "MODERATOR@PAGETURNERS.COM", "MODERATOR@PAGETURNERS.COM", "AQAAAAEAACcQAAAAEOy90KedOyOSKbwCWIYwtjY4GPh+pOLnVhGJWiqR8z/qWnOxYfm6a0eTe6CtoN8MxA==", null, false, null, "69c2adde-3f61-4beb-81d8-da748588c2da", false, "moderator@pageturners.com" },
                    { "27ad0df9-1f3d-4714-897b-0faf0a9108e1", 0, "50c54be6-67d3-4564-85bc-f846952a6d67", new DateTime(2052, 10, 26, 12, 43, 12, 858, DateTimeKind.Local).AddTicks(7796), "admin@pageturners.com", false, false, null, "ivan123", "Іван Сергійович", "ADMIN@PAGETURNERS.COM", "ADMIN@PAGETURNERS.COM", "AQAAAAEAACcQAAAAEEQrOEIXyxLB5+nvMrjnEvw/5v5pIx0XKHXaaK0bTsY7R60De76g64y0kAuL8x3XUQ==", null, false, null, "a886fa9c-11b4-4b4e-a77f-4a6f956e0409", false, "admin@pageturners.com" },
                    { "4149dd16-7e55-40dc-b114-6447b33d8f15", 0, "82f7d80d-a5f3-4698-953b-1eab82ac8869", new DateTime(2044, 10, 26, 12, 43, 12, 858, DateTimeKind.Local).AddTicks(7856), "reader@pageturners.com", false, false, null, "anna456", "Анна Олександрівна", "READER@PAGETURNERS.COM", "READER@PAGETURNERS.COM", "AQAAAAEAACcQAAAAEFHY+WeTTOzkMbEAahkCb9GOzbI++uCliyopnYJLgNOctZufb1cvMVw7ybXqrR71IQ==", null, false, null, "8e5b58e7-086e-486e-9a5b-e297caeab521", false, "reader@pageturners.com" }
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
                table: "Comment",
                columns: new[] { "Id", "BookId", "Comment", "CommentatorId", "Date" },
                values: new object[,]
                {
                    { 1, 3, "Дуже цікава історія!", "27ad0df9-1f3d-4714-897b-0faf0a9108e1", new DateTime(2023, 10, 26, 12, 43, 12, 864, DateTimeKind.Local).AddTicks(3912) },
                    { 2, 1, "Трохи нудно...", "13b4515e-ba84-4c78-8082-8374d351f1c1", new DateTime(2023, 10, 26, 12, 43, 12, 864, DateTimeKind.Local).AddTicks(3951) }
                });

            migrationBuilder.InsertData(
                table: "Requests",
                columns: new[] { "Id", "Author", "DatePubl", "Desc", "Edition", "Genre", "OwnerId", "Title" },
                values: new object[,]
                {
                    { 1, "Юлія Лабурнум", null, null, null, null, "13b4515e-ba84-4c78-8082-8374d351f1c1", "Лабіринт часу" },
                    { 2, "Андрій Землянський", null, "Спадщина Марса - це захоплюючий науково-фантастичний роман, який перенося читача у далеке майбутнє, на таємничу і загадкову планету Марс. Автор, Андрій Землянський, розповідає історію групи вчених і дослідників, які вирушають на Марс, щоб розкрити його давні таємниці.", null, null, "27ad0df9-1f3d-4714-897b-0faf0a9108e1", "Спадщина Марса" }
                });

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
                name: "Books");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
