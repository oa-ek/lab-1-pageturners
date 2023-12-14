using Microsoft.EntityFrameworkCore;
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
    public class BookRequestRepository : IBookRequestRepository
    {
        private readonly PageTurnersContext _context;


        public BookRequestRepository(PageTurnersContext context)
        {
            _context = context;
        }

        public async Task<BookRequest> GetByIdA(int id)
        {
            return await _context.Requests.FirstOrDefaultAsync(request => request.Id == id);
        }

        public BookRequest GetById(int id)
        {
            return _context.Requests.FirstOrDefault(request => request.Id == id);
        }
    
        public IEnumerable<BookRequest> GetAll()
        {
            return _context.Requests.ToList();
        }

        public void Add(BookRequest request)
        {
            _context.Requests.Add(request);
            _context.SaveChanges();
        }

        public void Update(BookRequest request)
        {
            _context.Requests.Update(request);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var request = GetById(id);
            if (request != null)
            {
                _context.Requests.Remove(request);
                _context.SaveChanges();
            }
        }
    }

}
