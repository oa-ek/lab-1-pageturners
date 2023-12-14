using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PageTurners.Application.Features.BookFeatures.BookDtos;
using PageTurners.Application.Features.CommentsFeatures.Commands.CreateComments;
using PageTurners.Application.Features.CommentsFeatures.CommentsDtos;
using PageTurners.Application.Repositories;
using PageTurners.Domain.Entities;

namespace PageTurners.Application.Features.CommentsFeatures.Commands.CreateComments
{
	public class CreateCommentsCommandHandler : IRequestHandler<CreateCommentsCommand, CreateCommentsDto>
	{
		private readonly IBaseRepository<Book, int>? _bookRepository;
		private readonly IBaseRepository<Comments, int>? _commentsRepository;
		private readonly IMapper _mapper;

		public CreateCommentsCommandHandler(IBaseRepository<Book, int>? bookRepository,
			IBaseRepository<Comments, int>? commentsRepository,
			IMapper mapper)
		{
			(_bookRepository, _commentsRepository, _mapper) = (bookRepository, commentsRepository, mapper);
		}

		public async Task<CreateCommentsDto> Handle(CreateCommentsCommand request, CancellationToken cancellationToken)
		{
			var book = await _bookRepository.GetAsync(request.Id);
			if (book == null)
			{
				return null;
			}

			var comment = new Comments
			{
				Comment = request.Comment,
			};

			book.Comment.Add(comment);

			await _bookRepository.SaveAsync();

			return _mapper.Map<Comments, CreateCommentsDto>(comment);
		}
	}
}
