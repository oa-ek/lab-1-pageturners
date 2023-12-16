using PageTurners.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageTurners.Repositories.Interfaces
{
    public interface IUserBookRepository
    {
        IEnumerable<Book> GetLikedBooksByUserId(string userId);
        void AddLikedBook(string userId, int bookId);
    }
}
