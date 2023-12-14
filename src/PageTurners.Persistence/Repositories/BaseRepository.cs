using Microsoft.EntityFrameworkCore;
using PageTurners.Application.Repositories;
using PageTurners.Domain.Common;
using PageTurners.Domain.Context;
using PageTurners.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageTurners.Persistence.Repositories
{
	public class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey>
		where TEntity : BaseEntity<TKey>
	{
		protected readonly PageTurnersContext Context;

		public BaseRepository(PageTurnersContext context)
		{
			Context = context;
		}

		public async Task<TEntity> CreateAsync(TEntity entity)
		{
			await Context.Set<TEntity>().AddAsync(entity);
			await Context.SaveChangesAsync();
			return entity;
		}

		public async Task UpdateAsync(TEntity entity)
		{
			Context.Set<TEntity>().Update(entity);
			await Context.SaveChangesAsync();
		}

		public async Task DeleteAsync(TEntity entity)
		{
			/*entity.Created = DateTime.UtcNow;*/
			Context.Set<TEntity>().Update(entity);
			await Context.SaveChangesAsync();
		}

		public async Task<TEntity> GetAsync(TKey key)
		{
			return await Context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id.Equals(key));
		}

		public async Task<IEnumerable<TEntity>> GetAllAsync()
		{
			return await Context.Set<TEntity>().ToListAsync();
		}

		public async Task SaveAsync()
		{
			await Context.SaveChangesAsync();
		}
	}
}
