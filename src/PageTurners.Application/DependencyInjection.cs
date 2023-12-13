using System.Reflection;
using MediatR;
using Castle.Core.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace PageTurners.Application
{
	public static class DependencyInjection
	{
		public static void AddApplication(this IServiceCollection servises)
		{
			servises.AddAutoMapper(Assembly.GetExecutingAssembly());
			servises.AddMediatR(Assembly.GetExecutingAssembly());
		}
	}
}
