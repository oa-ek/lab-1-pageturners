using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PageTurners.Domain.Common;

namespace PageTurners.Application.Repositories
{
	public interface IBaseRepository<T> where T : BaseEntity
	{
		Task CreateAsync (T entity);
		Task UpdateAsync (T entity);	
		Task DeleteAsync (T entity);
		Task<T> GetAsync (int id);
		Task<List<T>> GetAllAsync ();
	}
}
