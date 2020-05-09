using AutoMapper;
using Hippologamus.Domain.Models;
using Hippologamus.DTO.DTO;

namespace Hippologamus.API.Profiles
{
    public class PerfLogProfile : Profile
    {
        public PerfLogProfile()
        {
            CreateMap<PerfLog, PerfLogDisplay>();
        }
    }
}