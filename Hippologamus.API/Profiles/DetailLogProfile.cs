using AutoMapper;
using Hippologamus.Domain.Models;
using Hippologamus.DTO.DTO;

namespace Hippologamus.API.Profiles
{
    public class DetailLogProfile : Profile
    {
        public DetailLogProfile()
        {
            CreateMap<DetailLog, DetailLogDisplay>();
        }
    }
}