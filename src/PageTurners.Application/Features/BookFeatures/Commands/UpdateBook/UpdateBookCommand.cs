using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using PageTurners.Application.Features.BookFeatures.BookDtos;

namespace PageTurners.Application.Features.BookFeatures.Commands.UpdateBook
{
	public class UpdateBookCommand : IRequest<ReadBookDto>
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string? Author { get; set; }
		public string Genre { get; set; }
		public string? Desc { get; set; }
		public string Edition { get; set; }
		public double? AverageRating { get; set; }
		public int DatePubl { get; set; }
	}
}
