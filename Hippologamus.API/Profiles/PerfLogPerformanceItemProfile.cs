using AutoMapper;
using Hippologamus.Domain.Models;
using Hippologamus.DTO.DTO;

namespace Hippologamus.API.Profiles
{
    public class PerfLogPerformanceItemProfile : Profile
    {
        public PerfLogPerformanceItemProfile()
        {
            CreateMap<PerfLogPerformanceItem, PerfLogPerformanceItemDisplay>();
        }
    }
}