using PageTurners.Core.Context;
using PageTurners.Core.Entities;
using PageTurners.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageTurners.Repositories.Repos
{
    public class RatingRepository : IRatingRepository
    {
        private readonly PageTurnersContext _context;

        public RatingRepository(PageTurnersContext context)
        {
            _context = context;
        }

        public Rating GetById(int id)
        {
            return _context.Ratings.FirstOrDefault(rating => rating.Id == id);
        }

        public IEnumerable<Rating> GetAll()
        {
            return _context.Ratings.ToList();
        }

        public void Add(Rating rating)
        {
            _context.Ratings.Add(rating);
            _context.SaveChanges();
        }

        public void Update(Rating rating)
        {
            _context.Ratings.Update(rating);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var rating = GetById(id);
            if (rating != null)
            {
                _context.Ratings.Remove(rating);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Rating> GetAllForBook(int bookId)
        {
            return _context.Ratings
                .Where(r => r.BookId == bookId)
                .ToList();
        }
    }

}
