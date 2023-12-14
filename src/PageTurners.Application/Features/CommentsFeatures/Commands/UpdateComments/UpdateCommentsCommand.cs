using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using PageTurners.Application.Features.CommentsFeatures.CommentsDtos;

namespace PageTurners.Application.Features.CommentsFeatures.Commands.UpdateComments
{
	public class UpdateCommentsCommand : IRequest<ReadCommentsDto>
	{
		public int Id { get; set; }
		public required string Comment { get; set; }
	}
}
