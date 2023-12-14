using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PageTurners.Application.Features.BookFeatures.BookDtos;
using PageTurners.Application.Features.UserFeatures.UserDtos;
using PageTurners.Domain.Entities;

namespace PageTurners.Application.Features.UserFeatures
{
	public class UserMapper : Profile
	{
		public UserMapper() 
		{
			CreateMap<User, CreateUserDto>();
			CreateMap<CreateUserDto, User>();

			CreateMap<User, ReadUserDto>();
			CreateMap<ReadUserDto, User>();

		}
	}
}
