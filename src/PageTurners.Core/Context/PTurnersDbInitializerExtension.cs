using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PageTurners.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageTurners.Core.Context
{
    public static class PTurnersDbInitializerExtension
    {
        public static void Seed(this ModelBuilder builder)
        {
            (string admId, string moderId, string readId) = seedUsersAndRoles(builder);
            seedBook(builder);
            seedComments(builder, new string[] { admId, moderId, readId });
            seedBookRequest(builder, new string[] { admId, moderId, readId });
        }

        static void seedBook(ModelBuilder builder)
        {
            builder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Title = "Ігри влади",
                    Author = "Роберт Грін",
                    Genre = "Психологія, бізнес",
                    Desc = "Ця книга розглядає стратегії та тактики влади, використовуючи приклади з історії та сучасного бізнесу.",
                    Edition = "Viking Press",
                    DatePubl = 1998,

                },

                new Book
                {
                    Id = 2,
                    Title = "Великий Гетсбі",
                    Author = "Френсіс Скотт Фіцджеральд",
                    Genre = "Класика, роман",
                    Desc = "Цей роман розповідає історію багатого і таємничого Джей Гетсбі та його пристрасті до недосяжної коханої Дейзі.",
                    Edition = "Charles Scribner's Sons",
                    DatePubl = 1925
                },

                new Book
                {
                    Id = 3,
                    Title = "Після",
                    Author = "Анна Тодд",
                    Genre = "Роман, молодіжна література",
                    Desc = "Ця книга розповідає про складність переходу від підліткового життя до дорослого, з фокусом на романтичних відносинах.",
                    Edition = "Gallery Books",
                    DatePubl = 2014
                },

                new Book
                {
                    Id = 4,
                    Title = "Гра престолів",
                    Author = "Джордж Р. Р. Мартін",
                    Genre = "Фентезі, пригоди",
                    Desc = "Перша книга серії `Пісня льоду і полум'я` розповідає про боротьбу різних родів за трон Залізного Трону у міфічному світі Вестерос.",
                    Edition = "Bantam Spectra",
                    DatePubl = 1996
                }
                );
        }

        static void seedComments(ModelBuilder builder, string[] comentIds)
        {
            builder.Entity<Comments>().HasData(
                    new Comments
                    {
                        Id = 1,
                        BookId = 3,
                        CommentatorId = comentIds[0],
                        Comment = "Дуже цікава історія!"
                    }
                    );
            builder.Entity<Comments>().HasData(
                    new Comments
                    {
                        Id = 2,
                        BookId = 1,
                        CommentatorId = comentIds[1],
                        Comment = "Трохи нудно..."
                    }
                    );
        }

        static (string, string, string) seedUsersAndRoles (ModelBuilder builder)
        {
            string ADMIN_ROLE_ID = Guid.NewGuid().ToString();
            string MODERATOR_ROLE_ID = Guid.NewGuid().ToString();
            string READER_ROLE_ID = Guid.NewGuid().ToString();

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = ADMIN_ROLE_ID, Name= "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = MODERATOR_ROLE_ID, Name= "Moderator", NormalizedName = "MODERATOR" },
                new IdentityRole { Id = READER_ROLE_ID, Name= "Reader", NormalizedName = "READER" }
                );

            string ADMIN_ID = Guid.NewGuid().ToString();
            string MODERATOR_ID = Guid.NewGuid().ToString();
            string READER_ID = Guid.NewGuid().ToString();

            var admin = new User
            {
                Id = ADMIN_ID,
                DateOfBirth = DateTime.Now.AddYears(29),
                UserName = "admin@pageturners.com",
                Email = "admin@pageturners.com",
                EmailConfirmed = true,
                Name = "Іван Сергійович",
                Login = "ivan123",
                NormalizedEmail = "ADMIN@PAGETURNERS.COM",
                NormalizedUserName = "ADMIN@PAGETURNERS.COM"
            };

            var moderator = new User
            {
                Id = MODERATOR_ID,
                DateOfBirth = DateTime.Now.AddYears(21),
                UserName = "moderator@pageturners.com",
                Email = "moderator@pageturners.com",
                EmailConfirmed = true,
                Name = "Дарія Петрівна",
                Login = "daria684",
                NormalizedEmail = "MODERATOR@PAGETURNERS.COM",
                NormalizedUserName = "MODERATOR@PAGETURNERS.COM"
            };

            var reader = new User
            {
                Id = READER_ID,
                DateOfBirth = DateTime.Now.AddYears(21),
                UserName = "reader@pageturners.com",
                Email = "reader@pageturners.com",
                EmailConfirmed = true,
                Name = "Анна Олександрівна",
                Login = "anna456",
                NormalizedEmail = "READER@PAGETURNERS.COM",
                NormalizedUserName = "READER@PAGETURNERS.COM"
            };

            PasswordHasher<User> hasher = new PasswordHasher<User>();
            admin.PasswordHash = hasher.HashPassword(admin, "admin0passw");
            moderator.PasswordHash = hasher.HashPassword(moderator, "moderator0passw");
            reader.PasswordHash = hasher.HashPassword(reader, "reader0passw");

            builder.Entity<User>().HasData(admin, moderator, reader);

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = ADMIN_ROLE_ID,
                    UserId = ADMIN_ID
                },
                new IdentityUserRole<string>
                {
                    RoleId = ADMIN_ROLE_ID,
                    UserId = MODERATOR_ID
                },
                new IdentityUserRole<string>
                {
                    RoleId = MODERATOR_ROLE_ID,
                    UserId = MODERATOR_ID
                },
                new IdentityUserRole<string>
                {
                    RoleId = READER_ROLE_ID,
                    UserId = READER_ID
                },
                new IdentityUserRole<string>
                {
                    RoleId = READER_ROLE_ID,
                    UserId = MODERATOR_ID
                },
                new IdentityUserRole<string>
                {
                    RoleId = READER_ROLE_ID,
                    UserId = ADMIN_ID
                }
                );
            return (ADMIN_ID, MODERATOR_ID, READER_ID);
        }

        static void seedBookRequest(ModelBuilder builder, string[] reqIds)
        {
            builder.Entity<BookRequest>().HasData(
                    new BookRequest
                    {
                        Id = 1,
                        Title = "Лабіринт часу",
                        Author = "Юлія Лабурнум",
                        OwnerId = reqIds[1]
                    },
                    new BookRequest
                    {
                        Id = 2,
                        Title = "Спадщина Марса",
                        Author = "Андрій Землянський",
                        Desc = "Спадщина Марса - це захоплюючий науково-фантастичний роман, який перенося читача у далеке майбутнє, на таємничу і загадкову планету Марс. Автор, Андрій Землянський, розповідає історію групи вчених і дослідників, які вирушають на Марс, щоб розкрити його давні таємниці.",
                        OwnerId = reqIds[0]
                    }
                    );
        }
    }
}
