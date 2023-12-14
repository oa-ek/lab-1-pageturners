using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using PageTurners.Application.Features.CommentsFeatures.CommentsDtos;

namespace PageTurners.Application.Features.CommentsFeatures.Queries.GetAllCommentsQuery
{
	public class GetAllCommentsQuery : IRequest<IEnumerable<ReadCommentsDto>>
	{
	}
}
