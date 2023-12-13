using AutoMapper;
using MediatR;
using PageTurners.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PageTurners.Domain.Entities;
using PageTurners.Application.Repositories;
using PageTurners.Application.Features.BookFeatures.Queries;
using PageTurners.Application.Features.BookFeatures.BookDtos;
using AutoMapper;
using MediatR;

namespace PageTurners.Application.Features.BookFeatures.Queries.GetAllBookQuery
{
	public class GetAllBookQueryHandler
	   : IRequestHandler<GetAllBookQuery, IEnumerable<ReadBookDto>>
	{
		protected readonly IBaseRepository<Book, int> _bookRepository;
		protected readonly IMapper _mapper;

		public GetAllBookQueryHandler(IBaseRepository<Book, int> bookRepository, IMapper mapper)
		{
			(_bookRepository, _mapper) = (bookRepository, mapper);
		}

		public async Task<IEnumerable<ReadBookDto>> Handle(
			GetAllBookQuery request,
			CancellationToken cancellationToken)
		{
			return _mapper.Map<IEnumerable<Book>, IEnumerable<ReadBookDto>>(await _bookRepository.GetAllAsync());
		}
	}
}
