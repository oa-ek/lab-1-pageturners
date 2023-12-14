using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using MediatR;

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
