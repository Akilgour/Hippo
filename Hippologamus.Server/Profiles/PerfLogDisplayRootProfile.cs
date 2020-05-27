using AutoMapper;
using Hippologamus.DTO.DTO;
using Hippologamus.Server.Models;

namespace Hippologamus.Server.Profiles
{
    public class PerfLogDisplayRootProfile : Profile
    {
        public PerfLogDisplayRootProfile()
        {
            CreateMap<PerfLogCollectionResponce, PerfLogDisplayCollection>();
            CreateMap<PerfLogCollection, PerfLog>();
            CreateMap<RootLink, Links>();
            CreateMap<DTO.DTO.PaginationHeader, Models.PaginationHeader>();
        }
    }
}