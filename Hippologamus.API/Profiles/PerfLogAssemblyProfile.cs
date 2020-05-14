using AutoMapper;
using Hippologamus.Domain.Models;
using Hippologamus.DTO.DTO;

namespace Hippologamus.API.Profiles
{
    public class PerfLogAssemblyProfile : Profile
    {
        public PerfLogAssemblyProfile()
        {
            CreateMap<PerfLogAssembly, PerfLogAssemblyDisplay>();
        }
    }
}