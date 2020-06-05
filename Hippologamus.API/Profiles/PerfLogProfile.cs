using AutoMapper;
using Hippologamus.Domain.Models;
using Hippologamus.Shared.DTO;

namespace Hippologamus.API.Profiles
{
    public class PerfLogProfile : Profile
    {
        public PerfLogProfile()
        {
            CreateMap<PerfLog, PerfLogCollection>();
            CreateMap<PerfLog, PerfLogDetails>();
        }
    }
}