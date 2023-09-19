using PageTurners.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageTurners.Repositories.Interfaces
{
    public interface ICommentsRepository
    {
        Comments GetById(int id);
        IEnumerable<Comments> GetAll();
        void Add(Comments comment);
        void Update(Comments comment);
        void Delete(int id);
    }
}
