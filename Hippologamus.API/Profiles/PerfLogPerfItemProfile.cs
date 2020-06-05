using AutoMapper;
using Hippologamus.Domain.Models;
using Hippologamus.Shared.DTO;

namespace Hippologamus.API.Profiles
{
    public class PerfLogPerfItemProfile : Profile
    {
        public PerfLogPerfItemProfile()
        {
            CreateMap<PerfLogPerfItem, PerfLogPerfItemCollection>();
        }
    }
}