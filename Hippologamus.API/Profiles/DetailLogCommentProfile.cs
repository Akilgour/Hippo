using AutoMapper;
using Hippologamus.Domain.Models;
using Hippologamus.Shared.DTO;

namespace Hippologamus.API.Profiles
{
    public class DetailLogCommentProfile : Profile
    {
        public DetailLogCommentProfile()
        {
            CreateMap<DetailLogCommentCreate, DetailLogComment>();
        }
    }
}