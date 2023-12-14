using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PageTurners.Application.Features.CommentsFeatures.CommentsDtos;
using PageTurners.Application.Repositories;
using PageTurners.Domain.Entities;

namespace PageTurners.Application.Features.CommentsFeatures.Queries.GetAllCommentsQuery
{
	public class GetAllCommentsQueryHandler : IRequestHandler<GetAllCommentsQuery, IEnumerable<ReadCommentsDto>>
	{
		protected readonly IBaseRepository<Comments, int>? _commentsRepository;
		protected readonly IMapper _mapper;

		public GetAllCommentsQueryHandler(IBaseRepository<Comments,int>? commentsRepository, IMapper mapper)
		{
			(_commentsRepository, _mapper) = (commentsRepository, mapper);
		}

		public async Task<IEnumerable<ReadCommentsDto>> Handle (GetAllCommentsQuery request, CancellationToken cancellationToken)
		{
			return _mapper.Map<IEnumerable<Comments>, IEnumerable<ReadCommentsDto>>(await _commentsRepository.GetAllAsync());
		}
	}
}
