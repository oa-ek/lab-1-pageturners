using MediatR;
using PageTurners.Application.Features.BookFeatures.BookDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageTurners.Application.Features.BookFeatures.Queries.GetBookQuery
{
	public class GetBookQuery : IRequest<ReadBookDto>
	{
		public int Id { get; set; }
	}
}
