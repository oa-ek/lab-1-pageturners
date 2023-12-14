using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PageTurners.Application.Repositories;
using PageTurners.Domain.Entities;

namespace PageTurners.Application.Features.UserFeatures.Commans.DeleteUser
{
	public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, int>
	{
		private readonly IUserRepository _userRepository;

		public DeleteUserCommandHandler(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public async Task<int> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
		{
			var user = await _userRepository.GetAsync(request.Id);

			await _userRepository.DeleteAsync(user.Id);

			return user.Id;
		}
	}
}