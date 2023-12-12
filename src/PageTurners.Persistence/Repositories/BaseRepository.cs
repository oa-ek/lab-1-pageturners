using Microsoft.EntityFrameworkCore;
using PageTurners.Application.Repositories;
using PageTurners.Domain.Common;
using PageTurners.Domain.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageTurners.Persistence.Repositories
{
	public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
	{
		protected readonly PageTurnersContext Context;

		public BaseRepository(PageTurnersContext context)
		{
			Context=context;
		}

		public async Task CreateAsync (T entity)
		{
			await Context.AddAsync(entity);
		}

		public async Task UpdateAsync(T entity) 
		{ 
			Context.Update(entity);
		}

		public async Task DeleteAsync (T entity)
		{
			entity.Created = DateTime.UtcNow;
			Context.Update(entity);
		}

		public async Task<T> GetAsync(int id)
		{
			return await Context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task<List<T>> GetAllAsync()
		{
			return await Context.Set<T>().ToListAsync();
		}

		public async Task SaveAsync()
		{
			await Context.SaveChangesAsync();
		}
	}
}
