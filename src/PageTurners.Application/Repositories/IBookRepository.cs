using PageTurners.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageTurners.Application.Repositories
{
	public interface IBookRepository : IBaseRepository<Book>
	{
		Task<IEnumerable<Book>> FindByTitlePartSync(string text);
	}
}
