using MediatR;
using PageTurners.Application.Repositories;
using PageTurners.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageTurners.Application.Features.BookFeatures.Commands.DeleteBook
{
	public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, int>
	{
		protected readonly IBaseRepository<Book, int> _bookRepository;

		public DeleteBookCommandHandler(IBaseRepository<Book, int> bookRepository)
		{
			_bookRepository=bookRepository;
		}

		public async Task<int> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
		{
			var book = await _bookRepository.GetAsync(request.Id);
			await _bookRepository.DeleteAsync(book);

			return book.Id;
		}
	}
}
