using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PageTurners.Application.Features.UserFeatures.UserDtos;

namespace PageTurners.Application.Repositories
{
	public interface IUserRepository
	{
		Task<ReadUserDto> GetAsync(int id);
		Task<IEnumerable<ReadUserDto>> GetAllAsync();
		Task<string> CreateAsync(CreateUserDto obj);
		Task UpdateAsync(ReadUserDto obj, string[] roles);
		Task<IEnumerable<string>> GetRoleAsync();
		Task DeleteAsync(int id);
	}
}
