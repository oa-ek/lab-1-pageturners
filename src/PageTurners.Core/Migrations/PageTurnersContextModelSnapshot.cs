﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PageTurners.Core.Context;

#nullable disable

namespace PageTurners.Core.Migrations
{
    [DbContext(typeof(PageTurnersContext))]
    partial class PageTurnersContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "71faa60a-122e-4c25-8cde-219ac538bd8e",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "fe6f5fc7-384e-4b77-953f-35a362f1cc6e",
                            Name = "Moderator",
                            NormalizedName = "MODERATOR"
                        },
                        new
                        {
                            Id = "68d8afd7-cea0-43f6-8c86-6d31c84a7da4",
                            Name = "Reader",
                            NormalizedName = "READER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "065655a4-3e2d-4637-b0a7-d6ea9f3c9724",
                            RoleId = "71faa60a-122e-4c25-8cde-219ac538bd8e"
                        },
                        new
                        {
                            UserId = "065655a4-3e2d-4637-b0a7-d6ea9f3c9724",
                            RoleId = "fe6f5fc7-384e-4b77-953f-35a362f1cc6e"
                        },
                        new
                        {
                            UserId = "6f08f118-dd03-4f35-a4f5-f025b3dd89d5",
                            RoleId = "fe6f5fc7-384e-4b77-953f-35a362f1cc6e"
                        },
                        new
                        {
                            UserId = "d06989fc-83f9-46b7-9384-39379ed2566a",
                            RoleId = "fe6f5fc7-384e-4b77-953f-35a362f1cc6e"
                        },
                        new
                        {
                            UserId = "d06989fc-83f9-46b7-9384-39379ed2566a",
                            RoleId = "71faa60a-122e-4c25-8cde-219ac538bd8e"
                        },
                        new
                        {
                            UserId = "d06989fc-83f9-46b7-9384-39379ed2566a",
                            RoleId = "68d8afd7-cea0-43f6-8c86-6d31c84a7da4"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("PageTurners.Core.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("AverageRating")
                        .HasColumnType("float");

                    b.Property<string>("CoverPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DatePubl")
                        .HasColumnType("int");

                    b.Property<string>("Desc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Edition")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Роберт Грін",
                            CoverPath = "\\images\\book\\no_cover.jpg",
                            DatePubl = 1998,
                            Desc = "Ця книга розглядає стратегії та тактики влади, використовуючи приклади з історії та сучасного бізнесу.",
                            Edition = "Viking Press",
                            Genre = "Психологія, бізнес",
                            Title = "Ігри влади"
                        },
                        new
                        {
                            Id = 2,
                            Author = "Френсіс Скотт Фіцджеральд",
                            CoverPath = "\\images\\book\\no_cover.jpg",
                            DatePubl = 1925,
                            Desc = "Цей роман розповідає історію багатого і таємничого Джей Гетсбі та його пристрасті до недосяжної коханої Дейзі.",
                            Edition = "Charles Scribner's Sons",
                            Genre = "Класика, роман",
                            Title = "Великий Гетсбі"
                        },
                        new
                        {
                            Id = 3,
                            Author = "Анна Тодд",
                            CoverPath = "\\images\\book\\no_cover.jpg",
                            DatePubl = 2014,
                            Desc = "Ця книга розповідає про складність переходу від підліткового життя до дорослого, з фокусом на романтичних відносинах.",
                            Edition = "Gallery Books",
                            Genre = "Роман, молодіжна література",
                            Title = "Після"
                        },
                        new
                        {
                            Id = 4,
                            Author = "Джордж Р. Р. Мартін",
                            CoverPath = "\\images\\book\\no_cover.jpg",
                            DatePubl = 1996,
                            Desc = "Перша книга серії `Пісня льоду і полум'я` розповідає про боротьбу різних родів за трон Залізного Трону у міфічному світі Вестерос.",
                            Edition = "Bantam Spectra",
                            Genre = "Фентезі, пригоди",
                            Title = "Гра престолів"
                        });
                });

            modelBuilder.Entity("PageTurners.Core.Entities.BookRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CoverPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DatePubl")
                        .HasColumnType("int");

                    b.Property<string>("Desc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Edition")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OwnerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Requests");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Юлія Лабурнум",
                            CoverPath = "\\images\\book\\no_cover.jpg",
                            DatePubl = 0,
                            OwnerId = "6f08f118-dd03-4f35-a4f5-f025b3dd89d5",
                            Title = "Лабіринт часу"
                        },
                        new
                        {
                            Id = 2,
                            Author = "Андрій Землянський",
                            CoverPath = "\\images\\book\\no_cover.jpg",
                            DatePubl = 0,
                            Desc = "Спадщина Марса - це захоплюючий науково-фантастичний роман, який перенося читача у далеке майбутнє, на таємничу і загадкову планету Марс. Автор, Андрій Землянський, розповідає історію групи вчених і дослідників, які вирушають на Марс, щоб розкрити його давні таємниці.",
                            OwnerId = "065655a4-3e2d-4637-b0a7-d6ea9f3c9724",
                            Title = "Спадщина Марса"
                        });
                });

            modelBuilder.Entity("PageTurners.Core.Entities.Comments", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CommentatorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("CommentatorId");

                    b.ToTable("Comment");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BookId = 3,
                            Comment = "Дуже цікава історія!",
                            CommentatorId = "065655a4-3e2d-4637-b0a7-d6ea9f3c9724",
                            Date = new DateTime(2023, 12, 18, 9, 19, 42, 892, DateTimeKind.Local).AddTicks(2701)
                        },
                        new
                        {
                            Id = 2,
                            BookId = 1,
                            Comment = "Трохи нудно...",
                            CommentatorId = "6f08f118-dd03-4f35-a4f5-f025b3dd89d5",
                            Date = new DateTime(2023, 12, 18, 9, 19, 42, 892, DateTimeKind.Local).AddTicks(2818)
                        });
                });

            modelBuilder.Entity("PageTurners.Core.Entities.ModeratorReview", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BookRequestId")
                        .HasColumnType("int");

                    b.Property<string>("ModeratorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ReviewComment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("BookRequestId");

                    b.HasIndex("ModeratorId");

                    b.HasIndex("UserId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("PageTurners.Core.Entities.Rating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("PageTurners.Core.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Photo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "065655a4-3e2d-4637-b0a7-d6ea9f3c9724",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "17c7b6ea-a214-4f16-8e31-8812943d5cf1",
                            DateOfBirth = new DateTime(2052, 12, 18, 9, 19, 42, 275, DateTimeKind.Local).AddTicks(5446),
                            Email = "admin@pageturners.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            Login = "ivan123",
                            Name = "Іван Сергійович",
                            NormalizedEmail = "ADMIN@PAGETURNERS.COM",
                            NormalizedUserName = "ADMIN@PAGETURNERS.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEIqUCrKFLVuHnbIappzJ8PWucLRPRAbnwQ15bYkjjoTGOHf/VIj+Rs4ZuCTMYNNqYg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "8cb70caa-a6f8-4576-abc3-c137e37dec54",
                            TwoFactorEnabled = false,
                            UserName = "admin@pageturners.com"
                        },
                        new
                        {
                            Id = "6f08f118-dd03-4f35-a4f5-f025b3dd89d5",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "accff168-e269-44c8-b7be-d62f8135d34a",
                            DateOfBirth = new DateTime(2044, 12, 18, 9, 19, 42, 275, DateTimeKind.Local).AddTicks(5536),
                            Email = "moderator@pageturners.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            Login = "daria684",
                            Name = "Дарія Петрівна",
                            NormalizedEmail = "MODERATOR@PAGETURNERS.COM",
                            NormalizedUserName = "MODERATOR@PAGETURNERS.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEJfrIlHx9C08m8lN0KLykgL/KsBqC9AXJeezdNIycjrojIdq9oWjdle8Fqk/bz9vlg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "0e3861cb-3d78-4246-9f5e-7f7942601c8a",
                            TwoFactorEnabled = false,
                            UserName = "moderator@pageturners.com"
                        },
                        new
                        {
                            Id = "d06989fc-83f9-46b7-9384-39379ed2566a",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "9c5fa2a9-eb16-445d-b2c9-239fcb4daed2",
                            DateOfBirth = new DateTime(2044, 12, 18, 9, 19, 42, 275, DateTimeKind.Local).AddTicks(5557),
                            Email = "reader@pageturners.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            Login = "anna456",
                            Name = "Анна Олександрівна",
                            NormalizedEmail = "READER@PAGETURNERS.COM",
                            NormalizedUserName = "READER@PAGETURNERS.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEEvNtibP5Xvur0A2v9RgXdWspocMSLNWlfgg5hRr4wzSQ1TEihp/sYR5DMXqqZmgRg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "0c830dfc-a816-4ffb-aeaf-939de645ad90",
                            TwoFactorEnabled = false,
                            UserName = "reader@pageturners.com"
                        });
                });

            modelBuilder.Entity("PageTurners.Core.Entities.UserBook", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int?>("BookId1")
                        .HasColumnType("int");

                    b.Property<int>("UserBookId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "BookId");

                    b.HasIndex("BookId");

                    b.HasIndex("BookId1");

                    b.ToTable("UserBooks");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("PageTurners.Core.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("PageTurners.Core.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PageTurners.Core.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("PageTurners.Core.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PageTurners.Core.Entities.BookRequest", b =>
                {
                    b.HasOne("PageTurners.Core.Entities.User", "Owner")
                        .WithMany("BookRequests")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("PageTurners.Core.Entities.Comments", b =>
                {
                    b.HasOne("PageTurners.Core.Entities.Book", "Book")
                        .WithMany("Comment")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PageTurners.Core.Entities.User", "Commentator")
                        .WithMany("Comment")
                        .HasForeignKey("CommentatorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Commentator");
                });

            modelBuilder.Entity("PageTurners.Core.Entities.ModeratorReview", b =>
                {
                    b.HasOne("PageTurners.Core.Entities.BookRequest", "BookRequest")
                        .WithMany("Reviews")
                        .HasForeignKey("BookRequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PageTurners.Core.Entities.User", "Moderator")
                        .WithMany()
                        .HasForeignKey("ModeratorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PageTurners.Core.Entities.User", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("BookRequest");

                    b.Navigation("Moderator");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PageTurners.Core.Entities.Rating", b =>
                {
                    b.HasOne("PageTurners.Core.Entities.Book", "Book")
                        .WithMany("Ratings")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PageTurners.Core.Entities.User", "User")
                        .WithMany("Ratings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PageTurners.Core.Entities.UserBook", b =>
                {
                    b.HasOne("PageTurners.Core.Entities.Book", "Book")
                        .WithMany("UsersReadLater")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PageTurners.Core.Entities.Book", null)
                        .WithMany("UsersReadBooks")
                        .HasForeignKey("BookId1");

                    b.HasOne("PageTurners.Core.Entities.User", "User")
                        .WithMany("ToReadList")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PageTurners.Core.Entities.Book", b =>
                {
                    b.Navigation("Comment");

                    b.Navigation("Ratings");

                    b.Navigation("UsersReadBooks");

                    b.Navigation("UsersReadLater");
                });

            modelBuilder.Entity("PageTurners.Core.Entities.BookRequest", b =>
                {
                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("PageTurners.Core.Entities.User", b =>
                {
                    b.Navigation("BookRequests");

                    b.Navigation("Comment");

                    b.Navigation("Ratings");

                    b.Navigation("Reviews");

                    b.Navigation("ToReadList");
                });
#pragma warning restore 612, 618
        }
    }
}
