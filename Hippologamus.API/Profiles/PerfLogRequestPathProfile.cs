using AutoMapper;
using Hippologamus.Domain.Models;
using Hippologamus.DTO.DTO;

namespace Hippologamus.API.Profiles
{
    public class PerfLogRequestPathProfile : Profile
    {
        public PerfLogRequestPathProfile()
        {
            CreateMap<PerfLogRequestPath, PerfLogRequestPathCollection>();
        }
    }
}