using PageTurners.Core.Entities;
using PageTurners.Repositories.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageTurners.Repositories.Interfaces
{
    public interface IUserRepository
    {
        User GetById(string id);
        Task<IEnumerable<UserReadDto>> GetAll();
        void Add(User user);
        void Update(User user);
        void Delete(string id);
    }
}
