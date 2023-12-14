using PageTurners.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageTurners.Repositories.Interfaces
{
    public interface IRatingRepository
    {
        Rating GetById(int id);
        IEnumerable<Rating> GetAll();
        void Add(Rating rating);
        void Update(Rating rating);
        void Delete(int id);
        IEnumerable<Rating> GetAllForBook(int bookId);
    }
}
