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
    public class CommentsRepository : ICommentsRepository
    {
        private PageTurnersContext _context;

        public CommentsRepository(PageTurnersContext context)
        {
            _context = context;
        }

        public Comments GetById(int id)
        {
            return _context.Comment.FirstOrDefault(comment => comment.Id == id);
        }

        public IEnumerable<Comments> GetAll()
        {
            return _context.Comment.ToList();
        }

        public void Add(Comments comment)
        {
            _context.Comment.Add(comment);
            _context.SaveChanges();
        }

        public void Update(Comments comment)
        {
            _context.Comment.Update(comment);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var comment = GetById(id);
            if (comment != null)
            {
                _context.Comment.Remove(comment);
                _context.SaveChanges();
            }
        }
    }

}
