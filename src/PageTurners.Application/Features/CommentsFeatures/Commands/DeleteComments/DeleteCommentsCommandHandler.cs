using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PageTurners.Application.Repositories;
using PageTurners.Domain.Entities;

namespace PageTurners.Application.Features.CommentsFeatures.Commands.DeleteComments
{
	public class DeleteCommentsCommandHandler : IRequestHandler<DeleteCommentsCommand, int>
	{
		private readonly IBaseRepository<Comments, int>? _commentsRepository;

		public DeleteCommentsCommandHandler(IBaseRepository<Comments, int>? commentsRepository)
		{
			_commentsRepository = commentsRepository;
		}

		public async Task<int> Handle(DeleteCommentsCommand request, CancellationToken cancellationToken)
		{
			var comment = await _commentsRepository.GetAsync(request.Id);

			if (comment == null)
			{
				return 0;
			}

			await _commentsRepository.DeleteAsync(comment);

			return comment.Id;
		}
	}
}
