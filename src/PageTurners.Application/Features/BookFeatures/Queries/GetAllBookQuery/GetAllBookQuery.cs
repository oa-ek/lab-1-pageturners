using MediatR;
using PageTurners.Application.Features.BookFeatures.BookDtos;

namespace PageTurners.Application.Features.BookFeatures.Queries.GetAllBookQuery
{
	public class GetAllBookQuery : IRequest<IEnumerable<ReadBookDto>>
	{
	}
}
