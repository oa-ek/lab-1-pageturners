using PageTurners.Domain.Entities;
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
        Task<UserReadDto> GetAsync(string id);
        Task<IEnumerable<UserReadDto>> GetAllAsync();
        Task<string> CreateAsync(UserCreateDto user);
        Task UpdateAsync(UserReadDto user, string[] roles);
        Task<IEnumerable<string>> GetRolesAsync();
        Task DeleteAsync(string id);
    }
}
