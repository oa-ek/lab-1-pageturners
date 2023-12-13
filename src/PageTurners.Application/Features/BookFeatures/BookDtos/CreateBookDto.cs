using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageTurners.Application.Features.BookFeatures.BookDtos
{
	public class CreateBookDto
	{
		public int Id { get; set; }
		public required string Title { get; set; }
		public string? Author { get; set; }
		public required string Genre { get; set; }
		public string? Desc { get; set; }
		public string Edition { get; set; }
		public double? AverageRating { get; set; }
		public int DatePubl { get; set; }
	}
}
