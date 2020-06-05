using AutoMapper;
using Hippologamus.Domain.Models;
using Hippologamus.Shared.DTO;

namespace Hippologamus.API.Profiles
{
    public class PerfLogAssemblyProfile : Profile
    {
        public PerfLogAssemblyProfile()
        {
            CreateMap<PerfLogAssembly, PerfLogAssemblyCollection>();
        }
    }
}