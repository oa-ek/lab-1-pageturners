using PageTurners.Core.Context;
using PageTurners.Core.Entities;
using PageTurners.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace PageTurners.Repositories.Repos
{
    public class UserBookRepository : IUserBookRepository
    {
        private readonly PageTurnersContext _context;

        public UserBookRepository(PageTurnersContext context)
        {
            _context = context;
        }

        public IEnumerable<Book> GetLikedBooksByUserId(string userId)
        {
            return _context.UserBooks
                .Where(ub => ub.UserId == userId)
                .Select(ub => ub.Book)
                .ToList();
        }

        public void AddLikedBook(string userId, int bookId)
        {
            var existingUserBook = _context.UserBooks
                .FirstOrDefault(ub => ub.UserId == userId && ub.BookId == bookId);

            if (existingUserBook == null)
            {
                _context.UserBooks.Add(new UserBook { UserId = userId, BookId = bookId });
                _context.SaveChanges();
            }
        }
    }
}
