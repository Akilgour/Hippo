using AutoMapper;
using Hippologamus.Shared.DTO;
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
