using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using PageTurners.Application.Features.CommentsFeatures.CommentsDtos;

namespace PageTurners.Application.Features.BookFeatures.Commands.CreateBook
{
	public class CreateCommentsCommand : IRequest<CreateCommentsDto>
	{
		public int Id { get; set; }
		public required string Comment { get; set; }
	}
}
