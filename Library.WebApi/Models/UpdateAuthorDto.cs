using System;
using AutoMapper;
using Library.App.Authors.Commands.CreateAuthor;
using Library.App.Authors.Commands.UpdateAuthor;
using Library.App.Common.Mapping;

namespace Library.WebApi.Models
{
    public class UpdateAuthorDto : IMapWith<UpdateAuthorDto>
    {
        public Guid Id { get; set; }
        public DateTime? DateOfDeath { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateAuthorDto, UpdateAuthorCommand>()
                .ForMember(a => a.Id, opt => opt.MapFrom(aDto => aDto.Id))
                .ForMember(a => a.DateOfDeath, opt => opt.MapFrom(aDto => aDto.DateOfDeath));

        }
    }
}

