using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using PageTurners.Application.Features.UserFeatures.UserDtos;

namespace PageTurners.Application.Features.UserFeatures.Commans.UpdateUser
{
	public class UpdateUserCommand : IRequest<ReadUserDto>
	{
		public int Id { get; set; }
		public string Login { get; set; }
		public string? Name { get; set; }
		public DateTime DateOfBirth { get; set; }
		public string? Photo { get; set; }
	}
}
