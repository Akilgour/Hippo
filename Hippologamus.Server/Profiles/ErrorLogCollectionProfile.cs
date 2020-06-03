using AutoMapper;
using Hippologamus.DTO.DTO;
using Hippologamus.Server.Models;

namespace Hippologamus.Server.Profiles
{
    public class ErrorLogCollectionProfile : Profile
    {
        public ErrorLogCollectionProfile()
        {
            CreateMap<ErrorLogCollectionResponce, ErrorLogPagedList>()
                .ForMember(dest => dest.ErrorLogs, opt => opt.MapFrom(src => src.Value));

            CreateMap<ErrorLogCollection, ErrorLogList>();
        }
    }
}