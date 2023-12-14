using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PageTurners.Application.Features.UserFeatures.UserDtos;
using PageTurners.Application.Repositories;
using PageTurners.Domain.Entities;

namespace PageTurners.Application.Features.UserFeatures.Commans.CreateUser
{
	public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserDto>
	{
		private readonly IUserRepository _userRepository;
		private IMapper _mapper;

		public CreateUserCommandHandler (IUserRepository userRepository, IMapper mapper)
		{
			_userRepository=userRepository;
			_mapper=mapper;
		}

		public async Task<CreateUserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
		{
			var newUser = new User
			{
				Name = request.Name,
				Login = request.Login,
				DateOfBirth = request.DateOfBirth,
				Photo = request.Photo
			};

			return _mapper.Map<User, CreateUserDto>(newUser);
		}
	}
}
