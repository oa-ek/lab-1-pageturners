using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PageTurners.Application.Repositories;
using PageTurners.Domain.Entities;
using PageTurners.Persistence.Repositories;
using PageTurners.Persistence.Context;

namespace TakeTripAsp.Persistence
{
	public static class DependencyInjection
	{
		public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
		{
			var connectionString = configuration.GetConnectionString("TripConnectionString") ?? throw new InvalidOperationException();
			services.AddDbContext<PageTurnersContext>(option =>
			option.UseSqlServer(connectionString));
		}
	}
}
