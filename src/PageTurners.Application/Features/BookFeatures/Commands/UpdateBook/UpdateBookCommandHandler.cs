using AutoMapper;
using MediatR;
using PageTurners.Application.Features.BookFeatures.BookDtos;
using PageTurners.Application.Features.BookFeatures.Commands.CreateBook;
using PageTurners.Application.Repositories;
using PageTurners.Domain.Entities;

namespace PageTurners.Application.Features.BookFeatures.Commands.UpdateBook
{
	public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, UpdateBookDto>
	{
		private readonly IBaseRepository<Book, int>? _bookRepository;
		private readonly IMapper _mapper;

		public UpdateBookCommandHandler(IBaseRepository<Book, int>? bookRepository,
			IMapper mapper)
		{
			_bookRepository=bookRepository;
			_mapper=mapper;
		}

		public async Task<ReadBookDto> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
		{

			var book = await _bookRepository.GetAsync(request.Id);

			book.Title = request.Title;
			book.Author = request.Author;
			book.Genre = request.Genre;
			book.Desc = request.Genre;
			book.Edition = request.Edition;
			book.AverageRating = request.AverageRating;
			book.DatePubl = request.DatePubl;

			await _bookRepository.UpdateAsync(book);
			return _mapper.Map<Book, ReadBookDto>(book);
		}
	}
}
