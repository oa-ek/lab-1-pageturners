using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PageTurners.Application.Features.UserFeatures.UserDtos;

namespace PageTurners.Application.Features.UserFeatures.Commans.DeleteUser
{
	public class DeleteUserCommand : IRequest<int>
	{
		public int Id { get; set; }
	}
}
