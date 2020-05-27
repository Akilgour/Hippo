using AutoMapper;
using Hippologamus.DTO.DTO;
using Hippologamus.Server.Models;

namespace Hippologamus.Server.Profiles
{
    public class PerfLogCollectionResponceProfile : Profile
    {
        public PerfLogCollectionResponceProfile()
        {
            CreateMap<PerfLogCollectionResponce, PerfLogPagedList>()
                 .ForMember(dest => dest.PerfLogs, opt => opt.MapFrom(src => src.Value));
            CreateMap<PerfLogCollection, PerfLogList>();
            CreateMap<RootLink, Links>();
        }
    }
}