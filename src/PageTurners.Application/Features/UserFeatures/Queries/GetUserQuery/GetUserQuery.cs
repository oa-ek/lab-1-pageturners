using MediatR;
using PageTurners.Application.Features.UserFeatures.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PageTurners.Application.Features.UserFeatures.Queries.GetUserQuery
{
	public class GetUserQuery : IRequest<ReadUserDto>
	{
		public int Id { get; set; }
	}
}
