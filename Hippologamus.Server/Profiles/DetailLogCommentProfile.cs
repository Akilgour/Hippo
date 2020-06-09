using AutoMapper;
using Hippologamus.Server.Models;
using Hippologamus.Shared.DTO;

namespace Hippologamus.Server.Profiles
{
    public class DetailLogCommentProfile : Profile
    {
        public DetailLogCommentProfile()
        {
            CreateMap<DetailLogCommentEdit, DetailLogCommentCreate>();
            CreateMap< DetailLogCommentCollection, DetailLogCommentList>();
        }
    }
}
