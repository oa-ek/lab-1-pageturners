using MediatR;
using AutoMapper;
using PageTurners.Application.Features.CommentsFeatures.CommentsDtos;
using PageTurners.Application.Repositories;
using PageTurners.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageTurners.Application.Features.CommentsFeatures.Queries.GetCommentsQuery
{
	public class GetCommentsQueryHandler : IRequestHandler<GetCommentsQuery, ReadCommentsDto>
	{
		private readonly IBaseRepository<Comments, int>? _commentsRepository;
		private readonly IMapper _mapper;

		public GetCommentsQueryHandler(IBaseRepository<Comments, int>? commentsRepository, IMapper mapper)
		{
			(_commentsRepository, _mapper) = (commentsRepository, mapper);
		}

		public async Task<ReadCommentsDto> Handle(GetCommentsQuery request, CancellationToken cancellationToken)
		{
			var comment = await _commentsRepository.GetAsync(request.Id);
			return _mapper.Map<Comments, ReadCommentsDto>(comment);
		}

	}
}
