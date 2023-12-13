using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PageTurners.Domain.Common;

namespace PageTurners.Application.Repositories
{
	public interface IBaseRepository<TEntity, TKey>
	   where TEntity : BaseEntity<TKey>
	{
		Task<IEnumerable<TEntity>> GetAllAsync();
		Task<TEntity> GetAsync(TKey key);
		Task<TEntity> CreateAsync(TEntity entity);
		Task UpdateAsync(TEntity entity);
		Task DeleteAsync(TEntity entity);
		Task SaveAsync();
	}
}
