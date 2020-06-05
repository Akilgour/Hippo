using AutoMapper;
using Hippologamus.Domain.Models;
using Hippologamus.Shared.DTO;

namespace Hippologamus.API.Profiles
{
    public class DetailLogProfile : Profile
    {
        public DetailLogProfile()
        {
            CreateMap<DetailLog, DetailLogCollection>();

            CreateMap<DetailLog, ErrorLogCollection>()
                 .ForMember(dest => dest.ExceptionMessage, opt => opt.MapFrom(src => src.Exception));
        }
    }
}