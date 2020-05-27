using AutoMapper;
using Hippologamus.DTO.DTO;
using Hippologamus.Server.Models;

namespace Hippologamus.Server.Profiles
{
    public class PerfLogDisplayRootProfile : Profile
    {
        public PerfLogDisplayRootProfile()
        {
            CreateMap<PerfLogDisplayRoot, PerfLogDisplayCollection>();
            CreateMap<PerfLogDisplay, PerfLog>();
            CreateMap<RootLink, Links>();
        }
    }
}