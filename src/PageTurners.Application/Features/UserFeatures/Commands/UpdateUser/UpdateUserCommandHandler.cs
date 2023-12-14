using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PageTurners.Application.Features.UserFeatures.UserDtos;
using PageTurners.Application.Repositories;
using PageTurners.Domain.Entities;
using PageTurners.Application.Features.UserFeatures.Commans.UpdateUser;

namespace PageTurners.Application.Features.AppUserFeatures.Commands.UpdateUser
{
	public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, ReadUserDto>
	{
		private readonly IUserRepository _userRepository;
		private readonly IMapper _mapper;

		public UpdateUserCommandHandler(
			IUserRepository userRepository,
			IMapper mapper)
		{
			(_userRepository, _mapper) = (userRepository, mapper);
		}

		public async Task<ReadUserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
		{
			var user = await _userRepository.GetAsync(request.Id);
			return _mapper.Map<ReadUserDto>(user);
		}
	}
}