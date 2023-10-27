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
        Task<User> Get(string id);
        Task<IEnumerable<UserReadDto>> GetAll();
        Task<string> Create(UserCreateDto user);
        Task Update(UserUpdateDto user, string[] roles);
        Task<IEnumerable<string>> GetRoles();
        void Delete(string id);
    }
}
