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
            seedBook(builder);
            seedComments(builder);
            seedUser(builder);
            seedBookRequest(builder);
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

        static void seedComments(ModelBuilder builder)
        {
            builder.Entity<Comments>().HasData(
                    new Comments
                    {
                        Id = 1,
                        BookId = 3,
                        UserId = 1,
                        Comment = "Дуже цікава історія!"
                    }
                    );
         }

        static void seedUser(ModelBuilder builder)
        {
            builder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "Дарія Петрівна",
                    Login = "dariya89",
                    Email = "dariya89@email.com"
                },
                new User
                {
                    Id = 2,
                    Name = "Іван Сергійович",
                    Login = "ivan123",
                    Email = "ivan123@mail.net"
                },
                new User
                {
                    Id = 3,
                    Name = "Анна Олександрівна",
                    Login = "anna456",
                    Email = "anna456@gmail.com"
                }
                );
        }

        static void seedBookRequest(ModelBuilder builder)
        {
            builder.Entity<BookRequest>().HasData(
                    new BookRequest
                    {
                        Id = 1,
                        Title = "Лабіринт часу",
                        Author = "Юлія Лабурнум",
                        UserId = 2
                    },
                    new BookRequest
                    {
                        Id = 2,
                        Title = "Спадщина Марса",
                        Author = "Андрій Землянський",
                        Desc = "Спадщина Марса - це захоплюючий науково-фантастичний роман, який перенося читача у далеке майбутнє, на таємничу і загадкову планету Марс. Автор, Андрій Землянський, розповідає історію групи вчених і дослідників, які вирушають на Марс, щоб розкрити його давні таємниці.",
                        UserId = 1
                    }
                    );
        }
    }
}
