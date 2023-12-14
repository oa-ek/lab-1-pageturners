using MediatR.Pipeline;
using PageTurners.Application.Features.BookFeatures.BookDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PageTurners.Application.Repositories;
using PageTurners.Domain.Entities;
using MediatR;
using AutoMapper;

namespace PageTurners.Application.Features.BookFeatures.Commands.CreateBook
{
	public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, CreateBookDto>
	{
		private readonly IBaseRepository<Book, int>? _bookRepository;
		private readonly IBaseRepository<Comments, int>? _commentsRepository;
		private readonly IBaseRepository<Rating, int>? _ratingRepository;
		private readonly IMapper _mapper;

		public CreateBookCommandHandler(IBaseRepository<Book, int>? bookRepository,
			IBaseRepository<Comments, int>? commentsRepository,
			IBaseRepository<Rating, int>? ratingRepository, 
			IMapper mapper)
		{
			_bookRepository=bookRepository;
			_commentsRepository=commentsRepository;
			_ratingRepository=ratingRepository;
			_mapper=mapper;
		}

		public async Task<CreateBookDto> Handle(CreateBookCommand request, CancellationToken cancellationToken)
		{
			var book = new Book
			{
				Title = request.Title,
				Author = request.Author,
				Genre = request.Genre,
				Desc = request.Genre,
				Edition = request.Edition,
				AverageRating = request.AverageRating,
				DatePubl = request.DatePubl
			};

			var comment = await _commentsRepository.GetAsync(request.Id);
			if (comment != null && !book.Comment.Contains(comment))
			{
				book.Comment.Add(comment);
			}

			var rating = await _ratingRepository.GetAsync(request.Id);
			if (rating != null && !book.Ratings.Contains(rating))
			{
				book.Ratings.Add(rating);
			}

			await _bookRepository.CreateAsync(book);
			return _mapper.Map<Book, CreateBookDto>(book);
		}
	}
}
