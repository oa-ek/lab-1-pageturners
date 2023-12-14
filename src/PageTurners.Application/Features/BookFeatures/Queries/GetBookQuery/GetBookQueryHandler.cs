/*using AutoMapper;
using MediatR;
using PageTurners.Application.Features.BookFeatures.BookDtos;
using PageTurners.Application.Repositories;
using PageTurners.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageTurners.Application.Features.BookFeatures.Queries.GetBookQuery
{
	public class GetBookQueryHandler : IRequestHandler<GetBookQuery, ReadBookDto>
	{
		protected readonly IBaseRepository<Book, int>? _bookReposiroty;
		protected readonly IMapper _mapper;

		public GetBookQueryHandler (IBaseRepository<Book, int>? bookReposiroty, IMapper mapper)
		{
			_bookReposiroty=bookReposiroty;
			_mapper=mapper;
		}

		public async Task<ReadBookDto> Handle(GetBookQuery request, CancellationToken cancellationToken)
		{
			return _mapper.Map<Book, ReadBookDto>(await _bookReposiroty.GetAsync(request.Id));
		}
	}
	
}*/
