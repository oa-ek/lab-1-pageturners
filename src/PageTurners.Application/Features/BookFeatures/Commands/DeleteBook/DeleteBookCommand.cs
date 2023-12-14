using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using PageTurners.Application.Features.BookFeatures.BookDtos;

namespace PageTurners.Application.Features.BookFeatures.Commands.DeleteBook
{
	public class DeleteBookCommand : IRequest<int>
	{
		public int Id { get; set; }
	}
}