using AutoMapper;
using Hippologamus.DTO.DTO;
using Hippologamus.Server.Models;

namespace Hippologamus.Server.Profiles
{
    public class RootLinkProfile : Profile
    {
        public RootLinkProfile()
        {
            CreateMap<RootLink, Links>();
        }
    }
}
