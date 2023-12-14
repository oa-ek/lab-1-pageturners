using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PageTurners.Application.Features.CommentsFeatures.CommentsDtos;
using PageTurners.Domain.Entities;
using AutoMapper;

namespace PageTurners.Application.Features.CommentsFeatures
{
	public class CommentsMapper : Profile
	{
		public CommentsMapper() 
		{
			CreateMap<Comments, CreateCommentsDto>();
			CreateMap<CreateCommentsDto, Comments>();

			CreateMap<Comments, ReadCommentsDto>();
			CreateMap<ReadCommentsDto, Comments>();
		}
	}
}
