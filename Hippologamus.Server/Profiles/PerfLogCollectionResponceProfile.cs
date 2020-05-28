using AutoMapper;
using Hippologamus.DTO.DTO;
using Hippologamus.Server.Models;
using Hippologamus.Server.Profiles.PerfLogCollectionResponceProfileMapper;

namespace Hippologamus.Server.Profiles
{
    public class PerfLogCollectionResponceProfile : Profile
    {
        public PerfLogCollectionResponceProfile()
        {
            CreateMap<PerfLogCollectionResponce, PerfLogPagedList>()
                 .ForMember(dest => dest.PerfLogs, opt => opt.MapFrom(src => src.Value))
                 .ForMember(dest => dest.ShowPerviousPageButton, opt => opt.MapFrom(src => SetShowPerviousPageButton.Resolve(src.Pagination.CurrentPage)));

            CreateMap<PerfLogCollection, PerfLogList>();
                 

            CreateMap<RootLink, Links>();
        }
    }
}