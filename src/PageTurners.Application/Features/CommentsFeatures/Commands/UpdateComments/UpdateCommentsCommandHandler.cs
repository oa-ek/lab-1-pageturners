using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PageTurners.Application.Features.CommentsFeatures.Commands.UpdateComments;
using PageTurners.Application.Features.CommentsFeatures.CommentsDtos;
using PageTurners.Application.Repositories;
using PageTurners.Domain.Entities;

namespace PageTurners.Application.Features.CommentsFeatures.Commands.UpdateComments
{
	public class UpdateCommentsCommandHandler : IRequestHandler<UpdateCommentsCommand, ReadCommentsDto>
	{
		private readonly IBaseRepository<Comments, int>? _commentsRepository;
		private readonly IMapper _mapper;

		public UpdateCommentsCommandHandler(IBaseRepository<Comments, int>? commentsRepository, IMapper mapper)
		{
			(_commentsRepository, _mapper) = (commentsRepository, mapper);
		}

		public async Task<ReadCommentsDto> Handle(UpdateCommentsCommand request, CancellationToken cancellationToken)
		{
			var comment = await _commentsRepository.GetAsync(request.Id);

			if (comment == null)
			{
				return null;
			}

			comment.Comment = request.Comment;

			await _commentsRepository.UpdateAsync(comment);

			return _mapper.Map<Comments, ReadCommentsDto>(comment);
		}
	}
}
