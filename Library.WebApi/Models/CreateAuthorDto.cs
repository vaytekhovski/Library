using System;
using AutoMapper;
using Library.App.Authors.Commands.CreateAuthor;
using Library.App.Common.Mapping;

namespace Library.WebApi.Models
{
	public class CreateAuthorDto : IMapWith<CreateAuthorDto>
	{
		public string FullName { get; set; }
		public string Biography { get; set; }
		public DateTime? DateOfBirth { get; set; }
		public DateTime? DateOfDeath { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<CreateAuthorDto, CreateAuthorCommand>()
				.ForMember(a => a.FullName, opt => opt.MapFrom(aDto => aDto.FullName))
				.ForMember(a => a.Biography, opt => opt.MapFrom(aDto => aDto.Biography))
				.ForMember(a => a.DateOfBirth, opt => opt.MapFrom(aDto => aDto.DateOfBirth))
				.ForMember(a => a.DateOfDeath, opt => opt.MapFrom(aDto => aDto.DateOfDeath));

        }
	}
}

