using AutoMapper;
using MediatR;
using PageTurners.Application.Features.UserFeatures.UserDtos;
using PageTurners.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageTurners.Application.Features.UserFeatures.Queries.GetAllUserQuery
{
	public class GetAllUserQueryHandled : IRequestHandler<GetAllUserQuery, IEnumerable<ReadUserDto>>
	{
		private readonly IUserRepository _userRepository;
		private readonly IMapper _mapper;

		public GetAllUserQueryHandled (IUserRepository userRepository, IMapper mapper)
		{
			(_userRepository, _mapper) = (userRepository, mapper);
		}

		public async Task<IEnumerable<ReadUserDto>> Handle (GetAllUserQuery request, CancellationToken cancellationToken)
		{
			return await _userRepository.GetAllAsync();
		}
	}
}
