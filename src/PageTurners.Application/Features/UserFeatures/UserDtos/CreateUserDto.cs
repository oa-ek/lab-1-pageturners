using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageTurners.Application.Features.UserFeatures.UserDtos
{
	public class CreateUserDto
	{
		public int Id { get; set; }
		public string Login { get; set; }
		public string? Name { get; set; }
		public DateTime DateOfBirth { get; set; }
		public string? Photo { get; set; }
	}
}
