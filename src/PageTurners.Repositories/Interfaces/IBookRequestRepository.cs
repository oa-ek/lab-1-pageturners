using PageTurners.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageTurners.Repositories.Interfaces
{
    public interface IBookRequestRepository
    {
        BookRequest GetById(int id);
        Task<BookRequest> GetByIdA(int id);
        IEnumerable<BookRequest> GetAll();
        void Add(BookRequest request);
        void Update(BookRequest request);
        void Delete(int id);
    }

}
