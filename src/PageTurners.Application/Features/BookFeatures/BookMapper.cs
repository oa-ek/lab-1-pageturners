using AutoMapper;
using PageTurners.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PageTurners.Application.Features.BookFeatures.BookDtos;

namespace PageTurners.Application.Features.BookFeatures
{
	public class BookMapper : Profile
	{
		public BookMapper()
		{
			CreateMap<Book, CreateBookDto>();
			CreateMap<CreateBookDto, Book>();

			CreateMap<Book, ReadBookDto>();
			CreateMap<ReadBookDto, Book>();
		}
	}
}
