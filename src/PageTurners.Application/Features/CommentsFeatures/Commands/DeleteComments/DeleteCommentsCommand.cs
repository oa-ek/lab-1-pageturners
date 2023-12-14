using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using PageTurners.Application.Features.CommentsFeatures.CommentsDtos;

namespace PageTurners.Application.Features.CommentsFeatures.Commands.DeleteComments
{
	public class DeleteCommentsCommand : IRequest<int>
	{
		public int Id { get; set; }
	}
}
