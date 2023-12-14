using AutoMapper;
using MediatR;
using PageTurners.Application.Features.UserFeatures.Queries.GetUserQuery;
using PageTurners.Application.Features.UserFeatures.UserDtos;
using PageTurners.Application.Repositories;
using PageTurners.Domain.Entities;
/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageTurners.Application.Features.BookFeatures.Queries.GetBookQuery
{
	public class GetUserQueryHandler : IRequestHandler<GetUserQuery, ReadUserDto>
	{
		/*protected readonly IBaseRepository<User, int>? _userReposiroty;
		protected readonly IMapper _mapper;

		public GetUserQueryHandler(IBaseRepository<User, int>? userReposiroty, IMapper mapper)
		{
			_userReposiroty=userReposiroty;
			_mapper=mapper;
		}

		public async Task<ReadUserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
		{
			return _mapper.Map<User, ReadUserDto>(await _userReposiroty.GetAsync(request.Id));
		}
	}

}*/
