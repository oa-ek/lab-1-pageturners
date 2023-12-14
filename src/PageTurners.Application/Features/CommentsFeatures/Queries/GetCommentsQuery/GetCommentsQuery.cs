using MediatR;
using PageTurners.Application.Features.CommentsFeatures.CommentsDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PageTurners.Application.Features.CommentsFeatures.Queries.GetCommentsQuery
{
	public class GetCommentsQuery : IRequest<ReadCommentsDto>
	{
		public int Id { get; set; }
	}
}